using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
    public Image[] starImages; // �� �̹��� �迭
    public float filledAlpha = 1f; // ä���� �� �̹����� Alpha ��
    public float blurredAlpha = 0.5f; // �帴�� �� �̹����� Alpha ��

    private float clearTime; // ���� Ŭ���� �ð�

    private void Start()
    {
        // �ʱ�ȭ �� ��� �� �̹����� �帴�ϰ� ����
        for (int i = 0; i < starImages.Length; i++)
        {
            starImages[i].color = new Color(1f, 1f, 1f, blurredAlpha);
        }

        // ���� ������ ���޵� Ŭ���� �ð��� ������
        clearTime = PlayerPrefs.GetFloat("ClearTime");

        // Ŭ���� �ð��� ���� �� �̹����� ä��
        if (clearTime < 60f)
        {
            FillStars(3);
        }
        else if (clearTime < 90f)
        {
            FillStars(2);
        }
        else
        {
            FillStars(1);
        }
    }

    // �� �̹����� ������ ������ŭ ä��� �޼���
    private void FillStars(int count)
    {
        for (int i = 0; i < count; i++)
        {
            starImages[i].color = new Color(1f, 1f, 1f, filledAlpha);
        }
    }
    public void OnclickButton()
    {
        SceneManager.LoadScene("Start");
    }
}
   

