using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject character1; // ù ��° ĳ���� GameObject
    public GameObject character2; // �� ��° ĳ���� GameObject

    private GameObject currentCharacter; // ���� ���õ� ĳ���� GameObject

    public CameraFollow1 cameraFollow; // ī�޶� ���󰡴� ��ũ��Ʈ

    private void Start()
    {
        // ó������ ù ��° ĳ���Ͱ� ���õǵ��� ����
        SetCurrentCharacter(character1);
    }

    private void Update()
    {
        // ĳ���� ���� ��ư�� ������ ĳ���͸� ���
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCharacter();
        }
    }

    private void SetCurrentCharacter(GameObject character)
    {
        if (currentCharacter != null)
        {
            // ������ ���õ� ĳ���͸� ��Ȱ��ȭ
            currentCharacter.SetActive(false);
        }

        currentCharacter = character;

        // ���õ� ĳ���͸� Ȱ��ȭ
        currentCharacter.SetActive(true);

        // ī�޶� ��ũ��Ʈ�� Ÿ���� ���� ���õ� ĳ���ͷ� ����
        cameraFollow.target = currentCharacter.transform;
    }

    private void ToggleCharacter()
    {
        // ���� ���õ� ĳ���Ϳ� ���� �ٸ� ĳ���͸� ����
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
