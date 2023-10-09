using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ballon : MonoBehaviour
    
{
    string a = "Player1";
    public GameObject target;
    public Text text;
    bool b = false;
    void OnCollisionEnter(Collision other)
    {
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if (other.gameObject.tag == "Player1"| other.gameObject.tag == "Player2")
        {
            // 상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            cameraControl cameraControl = other.gameObject.GetComponent<cameraControl>();
            
            // 상대방으로부터 PlayerController 컴포넌트 가져오는 데 성공했다면
            //if (cameraControl != null)
           //{
                transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
                text.text = " " + 0.ToString("Game Clear\n press 'R' to next stage");
            b= true;
            //}

        }
    }
    private void Update()
    {
        if (b)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Start");
            }
        }
        target = GameObject.FindGameObjectWithTag(a);
    }
}
