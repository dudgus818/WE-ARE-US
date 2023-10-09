using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShow : MonoBehaviour
{
    public GameObject uiObject; // UI를 표시할 게임 오브젝트

   

    private void Update()
    {
       if(Input.GetMouseButton(0))
        {
            uiObject.SetActive(true); // UI를 활성화하여 표시
        }
       else
        {
            uiObject.SetActive(false); // UI를 비활성화하여 숨김
        }
    }
}
