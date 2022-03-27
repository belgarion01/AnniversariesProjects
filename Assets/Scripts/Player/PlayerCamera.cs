using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    void Awake()
    {
        if (TryGetComponent(out CinemachineVirtualCamera cinemachineVirtualCamera))
        {
            cinemachineVirtualCamera.Priority = CameraUtility.PLAYER_CAMERA_PRIORITY;
        }
    }
}
