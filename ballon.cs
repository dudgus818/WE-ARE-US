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
        // �浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if (other.gameObject.tag == "Player1"| other.gameObject.tag == "Player2")
        {
            // ���� ���� ������Ʈ���� PlayerController ������Ʈ ��������
            cameraControl cameraControl = other.gameObject.GetComponent<cameraControl>();
            
            // �������κ��� PlayerController ������Ʈ �������� �� �����ߴٸ�
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
