using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace UI
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(ScrollRect))]

    public class UIPagingViewController : MonoBehaviour,IBeginDragHandler,IEndDragHandler
    {
        [SerializeField]
        protected GameObject gbj_ContentRoot = null;

        [SerializeField]
        protected UIPageControl pageControl;

        [SerializeField]
        private float animationDuration = 0.3f;

        private float Key1InTangent = 0f;
        private float Key1OutTangent = 1f;
        private float Key2InTangent = 1f;
        private float Key2OutTangent = 0f;

        private bool isAnimating = false; //�ִϸ��̼� ��� ������ ��Ÿ���� �÷���
        private Vector2 destPosition; //�������� ��ũ�� ��ġ
        private Vector2 initialPosition; //�ڵ� ��ũ���� ������ ���� ��ũ�� ��ġ
        private AnimationCurve animationCurve; //�ڵ� ��ũ�ѿ� ���õ� �ִϸ��̼� Ŀ��
        private int prevPageIndex = 0; //���� �������� �ε���
        private Rect currentViewRect; //��ũ�� ���� �簢�� ũ��

        public RectTransform CachedRectTransform
        {
            get
            {
                return GetComponent<RectTransform>();
            }
        }

        public ScrollRect CachedScrollRect
        {
            get
            {
                return GetComponent<ScrollRect>();
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            isAnimating = false; //�ִϸ��̼� ���߿� �÷��׸� �����Ѵ�.
        }

        //�巡�װ� ���� �� ȣ��ȴ�
        public void OnEndDrag(PointerEventData eventData)
        {
            GridLayoutGroup grid = CachedScrollRect.content.GetComponent<GridLayoutGroup>();

            //���� ���� ���ν�ũ�� �並 �����
            CachedScrollRect.StopMovement();

            //GridLayoutGroup�� cellSize�� spacing�� �̿��Ͽ� ���������� ���� ����Ѵ�.
            float pageWidth = -(grid.cellSize.x + grid.spacing.x);

            //��ũ���� ���� ��ġ�κ��� ���� �������� �ε����� ����Ѵ�
            int pageIndex = Mathf.RoundToInt((CachedScrollRect.content.anchoredPosition.x) / pageWidth);

            if(pageIndex == prevPageIndex && Mathf.Abs(eventData.delta.x)>=4)
            {
                // �����ӵ� �̻����� �巡���� ��� �ش� �������� �� ������ �����Ų��.
                CachedScrollRect.content.anchoredPosition += new Vector2(eventData.delta.x, 0.0f);
                pageIndex += (int)Mathf.Sign(-eventData.delta.x);
            }

            //ù������ �Ǵ� �� �������� ��쿡�� �� �̻� ��ũ������ �ʵ��� �Ѵ�.
            if(pageIndex <0)
            {
                pageIndex = 0;
            }
            else if(pageIndex > grid.transform.childCount -1 )
            {
                pageIndex = grid.transform.childCount - 1;
            }

            prevPageIndex = pageIndex; // ���� �������� �ε����� �����Ѵ�.

            //�������� ��ũ�� ��ġ�� ����Ѵ�.
            float destX = pageIndex * pageWidth;
            destPosition = new Vector2(destX, CachedScrollRect.content.anchoredPosition.y);

            //������ ���� ��ũ�� ��ġ�� �����صд�
            initialPosition = CachedScrollRect.content.anchoredPosition;

            //�ִϸ��̼� Ŀ�긦 �ۼ��Ѵ�.
            Keyframe keyframe1 = new Keyframe(Time.time, 0.0f, Key1InTangent, Key1OutTangent);
            Keyframe keyframe2 = new Keyframe(Time.time + animationDuration, 1.0f, Key2InTangent, Key2OutTangent);
            animationCurve = new AnimationCurve(keyframe1, keyframe2);

            //�ִϸ��̼� ��� ������ ��Ÿ���� �÷��׸� �����Ѵ�.
            isAnimating = true;

            //������ ��Ʈ�� ǥ�ø� �����Ѵ�.
            if (pageControl != null)
                pageControl.SetCurrentPage(pageIndex);
        }

        //�� ������ ���� Update �޼��尡 ó���� ������ ȣ��ȴ�
        void LateUpdate()
        {
            if(isAnimating)
            {
                if(Time.time >= animationCurve.keys[animationCurve.length-1].time)
                {
                    //�ִϸ��̼� Ŀ���� ������ Ű�������� �������� �ִϸ��̼��� ������.
                    CachedScrollRect.content.anchoredPosition = destPosition;
                    isAnimating = false;
                    return;
                }

                //�ִϸ��̼� Ŀ�긦 ����Ͽ� ���� ��ũ�� ��ġ�� ����ؼ� ��ũ�� �並 �̵���Ų��.
                Vector2 newPosition = initialPosition + (destPosition - initialPosition) * animationCurve.Evaluate(Time.time);
                CachedScrollRect.content.anchoredPosition = newPosition;
            }
        }

        //�ν��Ͻ��� �ε��� �� Awake �޼��尡 ó���� ������ ȣ��ȴ�
        void Start()
        {
            UpdateView();

            if(pageControl != null)
            {
                if (gbj_ContentRoot != null)
                    pageControl.SetNumberOfPages(gbj_ContentRoot.transform.childCount);
                pageControl.SetCurrentPage(0); //������ ��Ʈ�� ǥ�ø� �ʱ�ȭ �Ѵ�
            }
        }

        //�� �����Ӹ��� ȣ��ȴ�
        void Update()
        {
            if(CachedRectTransform.rect.width != currentViewRect.width || CachedRectTransform.rect.height !=currentViewRect.height)
            {
                //��ũ�� ���� ���̳� ���̰� ��ȭ�ϸ� Scroll Content�� Padding�� �����Ѵ�.
                UpdateView();
            }
        }

        //Scroll Content�� Padding�� �����ϴ� �޼���
        private void UpdateView()
        {
            //��ũ�� ���� �簢�� ũ�⸦ �����صд�
            currentViewRect = CachedRectTransform.rect;

            //GridLayoutGroup�� cellSize�� ����Ͽ� Scroll Content�� padding�� ����Ͽ� �����Ѵ�
            GridLayoutGroup grid = CachedScrollRect.content.GetComponent<GridLayoutGroup>();
            int paddingH = Mathf.RoundToInt((currentViewRect.width - grid.cellSize.x) / 2.0f);
            int paddingV = Mathf.RoundToInt((currentViewRect.height - grid.cellSize.y) / 2.0f);
            grid.padding = new RectOffset(paddingH, paddingH, paddingV, paddingV);
        }
    }
}


