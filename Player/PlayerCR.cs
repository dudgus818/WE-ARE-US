using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCR : MonoBehaviour
{
    float GetDegree(Vector2 from, Vector2 to)    //�� ���� ������ ��ȯ
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
            //���ؼ����κ��� ĳ������ ��ġ ������ ������ ĳ������ ������ ����

            legL.position = legL.position;
            Vector3 tempDir = new Vector3(legR.position.x - legL.position.x, 0, legR.position.z - legL.position.z);
            //���ؼ����κ��� ĳ������ ���� ���͸� ����

            Vector3 tempPos = tempDir.normalized * RadiusL;    //�븻������ �� ���� �������� ���� ��ǥ ��ǥ�� ����

            transform.position = Vector3.Lerp(transform.position, new Vector3(legL.position.x + tempPos.x, legR.position.y, legL.position.z + tempPos.z), Time.deltaTime * 2);
            //��ǥ ��ǥ�� ���� ���� �ǽ�
            transform.position = new Vector3(legR.position.x + tempPos.x, PlayerCenter.position.y, legR.position.z + tempPos.z);
           

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        { 
            transform.eulerAngles = new Vector3(0, -30 + GetDegree(new Vector2(legL.position.x, legL.position.z), new Vector2(legR.position.x, legR.position.z)), 0);
            legR.position = legR.position;
            //���ؼ����κ��� ĳ������ ��ġ ������ ������ ĳ������ ������ ����

             Vector3 tempDir = new Vector3(legL.position.x - legR.position.x, 0, legL.position.z - legR.position.z);
            //���ؼ����κ��� ĳ������ ���� ���͸� ����
            Vector3 tempPos = tempDir.normalized * RadiusL;    //�븻������ �� ���� �������� ���� ��ǥ ��ǥ�� ����

            transform.position = Vector3.Lerp(transform.position, new Vector3(legR.position.x + tempPos.x, legL.position.y, legR.position.z + tempPos.z), Time.deltaTime * 2);
            //��ǥ ��ǥ�� ���� ���� �ǽ�
            transform.position = new Vector3(legL.position.x + tempPos.x, PlayerCenter.position.y, legL.position.z + tempPos.z);

        }*/
       


        if (PlayerCenter.position.y <= -5)
        {
            Debug.Log("�÷��̾� -10 �Դϴ�");
            transform.position = new Vector3(5, 2, 0);
            
        }
    }


}
