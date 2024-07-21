using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCR : MonoBehaviour
{
    float GetDegree(Vector2 from, Vector2 to)    //두 점의 각도를 반환
    {
        return Mathf.Atan2(from.y - to.y, to.x - from.x) * Mathf.Rad2Deg;
    }
    Vector3 moveVec;
    Vector3 trVec;
    GameObject Player;
    public Transform legR;
    public Transform legL;
    public Transform PlayerCenter;
    float RadiusR;
    float RadiusL;
    private Camera PCamera;
    

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<GameObject>();
        PCamera = Camera.main;
        RadiusR = legR.position.x - legL.position.x;
        RadiusL = legL.position.x - legR.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        

       /* if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            transform.eulerAngles = new Vector3(0, 30 + GetDegree(new Vector2(legL.position.x, legL.position.z), new Vector2(legR.position.x, legR.position.z)), 0);
            //기준선으로부터 캐릭터의 위치 방향의 각도로 캐릭터의 각도를 변경

            legL.position = legL.position;
            Vector3 tempDir = new Vector3(legR.position.x - legL.position.x, 0, legR.position.z - legL.position.z);
            //기준선으로부터 캐릭터의 방향 벡터를 구함

            Vector3 tempPos = tempDir.normalized * RadiusL;    //노말라이즈 한 값에 반지름을 곱해 목표 좌표를 구함

            transform.position = Vector3.Lerp(transform.position, new Vector3(legL.position.x + tempPos.x, legR.position.y, legL.position.z + tempPos.z), Time.deltaTime * 2);
            //목표 좌표를 향해 보간 실시
            transform.position = new Vector3(legR.position.x + tempPos.x, PlayerCenter.position.y, legR.position.z + tempPos.z);
           

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        { 
            transform.eulerAngles = new Vector3(0, -30 + GetDegree(new Vector2(legL.position.x, legL.position.z), new Vector2(legR.position.x, legR.position.z)), 0);
            legR.position = legR.position;
            //기준선으로부터 캐릭터의 위치 방향의 각도로 캐릭터의 각도를 변경

             Vector3 tempDir = new Vector3(legL.position.x - legR.position.x, 0, legL.position.z - legR.position.z);
            //기준선으로부터 캐릭터의 방향 벡터를 구함
            Vector3 tempPos = tempDir.normalized * RadiusL;    //노말라이즈 한 값에 반지름을 곱해 목표 좌표를 구함

            transform.position = Vector3.Lerp(transform.position, new Vector3(legR.position.x + tempPos.x, legL.position.y, legR.position.z + tempPos.z), Time.deltaTime * 2);
            //목표 좌표를 향해 보간 실시
            transform.position = new Vector3(legL.position.x + tempPos.x, PlayerCenter.position.y, legL.position.z + tempPos.z);

        }*/
       


        if (PlayerCenter.position.y <= -5)
        {
            Debug.Log("플레이어 -10 입니다");
            transform.position = new Vector3(5, 2, 0);
            
        }
    }


}
