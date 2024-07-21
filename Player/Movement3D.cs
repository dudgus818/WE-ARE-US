using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Movement3D : MonoBehaviour //����� �÷��̾� 1 ��ũ��Ʈ
{
    private Rigidbody charRigidbody;
    public Animator animator;
    public Transform PlayerCenter;
    public GameObject die;

    public float moveSpeed;
    public float rotateSpeed = 10.0f;
    public int JumpPower;
    
    private bool IsJumping;
    public bool isMove;
    
    string a = "die";

    public AudioSource mySfx;
    public AudioClip jumpSfx;

    public void JumpSound()
    {

        mySfx.PlayOneShot(jumpSfx);
    }
    void Start()
     {
         charRigidbody = GetComponent<Rigidbody>();
         animator = GetComponent<Animator>();
        PlayerCenter=GetComponent<Transform>();
         IsJumping = false;
        isMove = true;
        die = GameObject.FindGameObjectWithTag(a);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == a)
        {
            PlayerCenter.position = new Vector3(17,3,-61);
            Debug.Log("������");
        }
    }

    void FixedUpdate()
    {

        if (isMove)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            if (h != 0)
            {
                animator.SetBool("Walk", true);
            }
            else if (v != 0)
            {
                animator.SetBool("Walk", true);

            }
            else
            {
                animator.SetBool("Walk", false);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (!IsJumping)
                {
                    IsJumping = true;
                    JumpSound();
                    charRigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
                }
                else
                {
                    IsJumping = false;
                }
            }
            Vector3 inputDir = new Vector3(h, 0, v).normalized; // new Vector3(h, 0, v)�� ���� ���̰� �Ǿ����Ƿ� dir�̶�� ������ �ְ� ���� ���ϰ� ����� �� �ְ� ��




            // �ٶ󺸴� �������� ȸ�� �� �ٽ� ������ �ٶ󺸴� ������ ���� ���� ����
            if (!(h == 0 && v == 0))
            {
                // �̵��� ȸ���� �Բ� ó��
                transform.position += inputDir * moveSpeed * Time.deltaTime;
                // ȸ���ϴ� �κ�. Point 1.
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(inputDir), Time.deltaTime * rotateSpeed);


            }

           

        }
        if (PlayerCenter.position.x >= 23 && PlayerCenter.position.z >= 37 && PlayerCenter.position.y >= 32)
        {
            isMove = false;
        }
    }
    
  
}
