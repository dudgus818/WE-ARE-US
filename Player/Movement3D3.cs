using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D3 : MonoBehaviour //듀얼모드 플레이어 2 스크립트
{
    public Animator animator;
    public Transform PlayerCenter;
    private Rigidbody charRigidbody;
    public GameObject die;

    public int JumpPower;
    public float movespeed;
    public float rotatespeed = 10.0f;

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
        PlayerCenter = GetComponent<Transform>();
        die = GameObject.FindGameObjectWithTag(a);

        IsJumping = false;
        isMove = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == a)
        {
            PlayerCenter.position = new Vector3(17, 3, -61);
            Debug.Log("리스폰");
        }
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
                    JumpSound();
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
        if (PlayerCenter.position.x >= 23 && PlayerCenter.position.z >= 37 && PlayerCenter.position.y >=32)
        {
            isMove = false;
        }
    }
}
