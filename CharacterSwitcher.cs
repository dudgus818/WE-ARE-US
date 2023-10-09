using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject character1; // 첫 번째 캐릭터 GameObject
    public GameObject character2; // 두 번째 캐릭터 GameObject

    private GameObject currentCharacter; // 현재 선택된 캐릭터 GameObject

    public CameraFollow1 cameraFollow; // 카메라를 따라가는 스크립트

    private void Start()
    {
        // 처음에는 첫 번째 캐릭터가 선택되도록 설정
        SetCurrentCharacter(character1);
    }

    private void Update()
    {
        // 캐릭터 변경 버튼을 누르면 캐릭터를 토글
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCharacter();
        }
    }

    private void SetCurrentCharacter(GameObject character)
    {
        if (currentCharacter != null)
        {
            // 이전에 선택된 캐릭터를 비활성화
            currentCharacter.SetActive(false);
        }

        currentCharacter = character;

        // 선택된 캐릭터를 활성화
        currentCharacter.SetActive(true);

        // 카메라 스크립트의 타겟을 현재 선택된 캐릭터로 설정
        cameraFollow.target = currentCharacter.transform;
    }

    private void ToggleCharacter()
    {
        // 현재 선택된 캐릭터에 따라 다른 캐릭터를 선택
        if (currentCharacter == character1)
        {
            SetCurrentCharacter(character2);
        }
        else
        {
            SetCurrentCharacter(character1);
        }
    }
}
