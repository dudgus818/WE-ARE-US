using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShow : MonoBehaviour
{
    public GameObject uiObject; // UI�� ǥ���� ���� ������Ʈ

   

    private void Update()
    {
       if(Input.GetMouseButton(0))
        {
            uiObject.SetActive(true); // UI�� Ȱ��ȭ�Ͽ� ǥ��
        }
       else
        {
            uiObject.SetActive(false); // UI�� ��Ȱ��ȭ�Ͽ� ����
        }
    }
}
