using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraController : MonoBehaviour  //타임어택 카메라 스크립트
{


    public GameObject Target;               // 카메라가 따라다닐 타겟
    private float done = 60.0F;
    public float offsetX = 0.0f;            // 카메라의 x좌표
    public float offsetY = 10.0f;           // 카메라의 y좌표
    public float offsetZ = -10.0f;          // 카메라의 z좌표
    public Transform PlayerCenter;
    public float CameraSpeed = 10.0f;       // 카메라의 속도
    Vector3 TargetPos;                      // 타겟의 위치
    public Transform target;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        // 타겟의 x, y, z 좌표에 카메라의 좌표를 더하여 카메라의 위치를 결정
        TargetPos = new Vector3(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ
            );

        done -= Time.deltaTime;
        // 카메라의 움직임을 부드럽게 하는 함수(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);

        if (PlayerCenter.position.x >= 10 && PlayerCenter.position.z >= 157)
        {

            transform.RotateAround(target.position, Vector3.up, 20 * Time.deltaTime);



        }
        else if(done < 0F)
        {
            transform.RotateAround(target.position, Vector3.up, 20 * Time.deltaTime);
        }
    }
}
