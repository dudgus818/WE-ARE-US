using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cameraControl : MonoBehaviour  //����� ī�޶� ��ũ��Ʈ
{

    public GameObject Target;               // ī�޶� ����ٴ� Ÿ��
    public Transform PlayerCenter;
    public Transform target;

    public float offsetX = 0.0f;            // ī�޶��� x��ǥ
    public float offsetY = 3.0f;           // ī�޶��� y��ǥ
    public float offsetZ = -10.0f;          // ī�޶��� z��ǥ
    
    public float CameraSpeed = 10.0f;       // ī�޶��� �ӵ�
    
    Vector3 TargetPos;                      // Ÿ���� ��ġ
   
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
        
        
        // Ÿ���� x, y, z ��ǥ�� ī�޶��� ��ǥ�� ���Ͽ� ī�޶��� ��ġ�� ����
        TargetPos = new Vector3(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ
            );

       
        // ī�޶��� �������� �ε巴�� �ϴ� �Լ�(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);

        if (PlayerCenter.position.x <= 4 && PlayerCenter.position.z >= 130)
        {

            transform.RotateAround(target.position, Vector3.up, 20 * Time.deltaTime);



        }
        
    }
}
