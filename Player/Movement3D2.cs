using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D2 : MonoBehaviour  //Ÿ�Ӿ��� �÷��̾� ��ũ��Ʈ
{
    private float done = 60.0F;
    public Animator animator;
    public int JumpPower;
    public float movespeed;
    public Transform PlayerCenter;
    private Rigidbody charRigidbody;
    public float rotatespeed = 10.0f;
    private bool IsJumping;
    public bool isMove;
    void Start()
    {
        charRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        IsJumping = false;
        isMove = true;
    }
    void Update()
    {
        if (isMove)
        {
            float h1 = Input.GetAxisRaw("Fire1");
            float v1 = Input.GetAxisRaw("Fire2");

            if (h1 != 0)
            {
                animator.SetBool("Walk", true);
            }
            else if (v1 != 0)
            {
                animator.SetBool("Walk", true);

            }
            else
            {
                animator.SetBool("Walk", false);
            }
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                if (!IsJumping)
                {
                    IsJumping = true;
                    charRigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
                }
                else
                {
                    IsJumping = false;
                }
            }
            Vector3 Dir = new Vector3(h1, 0, v1).normalized; // new Vector3(h, 0, v)�� ���� ���̰� �Ǿ����Ƿ� dir�̶�� ������ �ְ� ���� ���ϰ� ����� �� �ְ� ��



            // �ٶ󺸴� �������� ȸ�� �� �ٽ� ������ �ٶ󺸴� ������ ���� ���� ����
            if (!(h1 == 0 && v1 == 0))
            {


                // �̵��� ȸ���� �Բ� ó��
                transform.position += Dir * movespeed * Time.deltaTime;


                // ȸ���ϴ� �κ�. Point 1.
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Dir), Time.deltaTime * rotatespeed);



            }
        }
        done -= Time.deltaTime;
        if (done > 0F)
        {
            isMove = true;
        }
        else if(done < 0F)
        {
            isMove = false;
        }
        if (PlayerCenter.position.x <= 10 && PlayerCenter.position.z >= 157)
        {
            isMove = false;
        }
    }
}
