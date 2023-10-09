using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
    public Image[] starImages; // 별 이미지 배열
    public float filledAlpha = 1f; // 채워진 별 이미지의 Alpha 값
    public float blurredAlpha = 0.5f; // 흐릿한 별 이미지의 Alpha 값

    private float clearTime; // 게임 클리어 시간

    private void Start()
    {
        // 초기화 시 모든 별 이미지를 흐릿하게 설정
        for (int i = 0; i < starImages.Length; i++)
        {
            starImages[i].color = new Color(1f, 1f, 1f, blurredAlpha);
        }

        // 이전 씬에서 전달된 클리어 시간을 가져옴
        clearTime = PlayerPrefs.GetFloat("ClearTime");

        // 클리어 시간에 따라 별 이미지를 채움
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

    // 별 이미지를 지정된 개수만큼 채우는 메서드
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
   

