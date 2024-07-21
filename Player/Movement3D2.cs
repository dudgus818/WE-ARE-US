using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D2 : MonoBehaviour  //타임어택 플레이어 스크립트
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
            Vector3 Dir = new Vector3(h1, 0, v1).normalized; // new Vector3(h, 0, v)가 자주 쓰이게 되었으므로 dir이라는 변수에 넣고 향후 편하게 사용할 수 있게 함



            // 바라보는 방향으로 회전 후 다시 정면을 바라보는 현상을 막기 위해 설정
            if (!(h1 == 0 && v1 == 0))
            {


                // 이동과 회전을 함께 처리
                transform.position += Dir * movespeed * Time.deltaTime;


                // 회전하는 부분. Point 1.
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
