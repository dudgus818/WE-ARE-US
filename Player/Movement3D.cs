using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Movement3D : MonoBehaviour //듀얼모드 플레이어 1 스크립트
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
            Debug.Log("리스폰");
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
            Vector3 inputDir = new Vector3(h, 0, v).normalized; // new Vector3(h, 0, v)가 자주 쓰이게 되었으므로 dir이라는 변수에 넣고 향후 편하게 사용할 수 있게 함




            // 바라보는 방향으로 회전 후 다시 정면을 바라보는 현상을 막기 위해 설정
            if (!(h == 0 && v == 0))
            {
                // 이동과 회전을 함께 처리
                transform.position += inputDir * moveSpeed * Time.deltaTime;
                // 회전하는 부분. Point 1.
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(inputDir), Time.deltaTime * rotateSpeed);


            }

           

        }
        if (PlayerCenter.position.x >= 23 && PlayerCenter.position.z >= 37 && PlayerCenter.position.y >= 32)
        {
            isMove = false;
        }
    }
    
  
}
