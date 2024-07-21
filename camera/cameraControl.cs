using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cameraControl : MonoBehaviour  //듀얼모드 카메라 스크립트
{

    public GameObject Target;               // 카메라가 따라다닐 타겟
    public Transform PlayerCenter;
    public Transform target;

    public float offsetX = 0.0f;            // 카메라의 x좌표
    public float offsetY = 3.0f;           // 카메라의 y좌표
    public float offsetZ = -10.0f;          // 카메라의 z좌표
    
    public float CameraSpeed = 10.0f;       // 카메라의 속도
    
    Vector3 TargetPos;                      // 타겟의 위치
   
    string a = "Player1";
    public float timer = 0;

    public bool b = true;
    // Update is called once per frame
    void FixedUpdate()
    {
        timer+=Time.deltaTime;

        if (timer >= 0.75)
        {
            if(b)
            {
                Target = GameObject.FindGameObjectWithTag(a);
                target = Target.transform;
                PlayerCenter = target;
                b = false;
            }
        }
        
        
        // 타겟의 x, y, z 좌표에 카메라의 좌표를 더하여 카메라의 위치를 결정
        TargetPos = new Vector3(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ
            );

       
        // 카메라의 움직임을 부드럽게 하는 함수(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);

        if (PlayerCenter.position.x <= 4 && PlayerCenter.position.z >= 130)
        {

            transform.RotateAround(target.position, Vector3.up, 20 * Time.deltaTime);



        }
        
    }
}
