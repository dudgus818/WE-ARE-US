using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraController : MonoBehaviour  //Ÿ�Ӿ��� ī�޶� ��ũ��Ʈ
{


    public GameObject Target;               // ī�޶� ����ٴ� Ÿ��
    private float done = 60.0F;
    public float offsetX = 0.0f;            // ī�޶��� x��ǥ
    public float offsetY = 10.0f;           // ī�޶��� y��ǥ
    public float offsetZ = -10.0f;          // ī�޶��� z��ǥ
    public Transform PlayerCenter;
    public float CameraSpeed = 10.0f;       // ī�޶��� �ӵ�
    Vector3 TargetPos;                      // Ÿ���� ��ġ
    public Transform target;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        // Ÿ���� x, y, z ��ǥ�� ī�޶��� ��ǥ�� ���Ͽ� ī�޶��� ��ġ�� ����
        TargetPos = new Vector3(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ
            );

        done -= Time.deltaTime;
        // ī�޶��� �������� �ε巴�� �ϴ� �Լ�(Lerp)
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
