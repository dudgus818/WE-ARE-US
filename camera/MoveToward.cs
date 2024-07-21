using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToward : MonoBehaviour
{
    /* ���� �������� �̵��ϴ� ��ũ��Ʈ�Դϴ�. */

    public Camera cam; //����ī�޶�
    private float speed = 0.5f; // �̵��ӵ�

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
