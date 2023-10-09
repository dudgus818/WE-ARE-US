using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow1 : MonoBehaviour
{
    public Transform target; // 캐릭터의 Transform 컴포넌트

    public float cameraFollowSpeed = 5f; // 카메라가 캐릭터를 따라가는 속도

    public Vector3 cameraOffset = new Vector3(0f, 2f, -10f); // 카메라 위치 오프셋

    private void LateUpdate()
    {
        if (target == null)
            return;

        // 현재 선택된 캐릭터를 따라가는 카메라 이동
        Vector3 desiredPosition = target.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, cameraFollowSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
