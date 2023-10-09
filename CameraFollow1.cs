using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow1 : MonoBehaviour
{
    public Transform target; // ĳ������ Transform ������Ʈ

    public float cameraFollowSpeed = 5f; // ī�޶� ĳ���͸� ���󰡴� �ӵ�

    public Vector3 cameraOffset = new Vector3(0f, 2f, -10f); // ī�޶� ��ġ ������

    private void LateUpdate()
    {
        if (target == null)
            return;

        // ���� ���õ� ĳ���͸� ���󰡴� ī�޶� �̵�
        Vector3 desiredPosition = target.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, cameraFollowSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
