using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public static class CameraUtility
{
    public const int PLAYER_CAMERA_PRIORITY = 0;

    public static void SetOverrideCamera(this CinemachineVirtualCamera virtualCamera, bool active)
    {
        virtualCamera.Priority = active ? 1 : -1;
    }
}
