using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarScore : MonoBehaviour
{
    private float clearTime; // 게임 클리어 시간

    private void Start()
    {
        // 게임 오브젝트에서 타이머 컴포넌트를 찾아 클리어 시간을 가져옴
        Timer timer = FindObjectOfType<Timer>();
        if (timer != null)
        {
            clearTime = timer.GetElapsedTime();
        }
        else
        {
            clearTime = 0f; // 타이머가 없는 경우 기본값으로 0을 설정
        }
        // 저장된 클리어 시간을 다음 씬으로 전달
        PlayerPrefs.SetFloat("ClearTime", clearTime);
    }
}
