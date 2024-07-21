using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToward : MonoBehaviour
{
    /* 시점 방향으로 이동하는 스크립트입니다. */

    public Camera cam; //메인카메라
    private float speed = 0.5f; // 이동속도

    void Start()
    {
    }

    void Update()
    {
        MoveLookAt();
    }
    void MoveLookAt()
    {
      
        Vector3 dir = cam.transform.localRotation * Vector3.forward;
        
        transform.localRotation = cam.transform.localRotation;
       
        transform.localRotation = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);
        
        gameObject.transform.Translate(dir * 0.1f * Time.deltaTime);
    }
}
