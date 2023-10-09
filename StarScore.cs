using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarScore : MonoBehaviour
{
    private float clearTime; // ���� Ŭ���� �ð�

    private void Start()
    {
        // ���� ������Ʈ���� Ÿ�̸� ������Ʈ�� ã�� Ŭ���� �ð��� ������
        Timer timer = FindObjectOfType<Timer>();
        if (timer != null)
        {
            clearTime = timer.GetElapsedTime();
        }
        else
        {
            clearTime = 0f; // Ÿ�̸Ӱ� ���� ��� �⺻������ 0�� ����
        }
        // ����� Ŭ���� �ð��� ���� ������ ����
        PlayerPrefs.SetFloat("ClearTime", clearTime);
    }
}
