using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] FirstPersonController fpsController;


    [SerializeField] public float ZoomedOutFov = 40.0f;
    [SerializeField] public float ZoomedInFov = 25.0f;
    [SerializeField] public float ZoomedOutSensitivity = 1f;
    [SerializeField] public float ZoomedInSensitivity = 0.5f;

    bool ZoomedInToggle = false;

    private void OnDisable()
    {
        ZoomOut();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if (ZoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();

            }
        }

    }

    private void ZoomOut()
    {
        ZoomedInToggle = false;
        virtualCamera.m_Lens.FieldOfView = ZoomedOutFov;
        fpsController.RotationSpeed = ZoomedOutSensitivity;
    }

    private void ZoomIn()
    {
        ZoomedInToggle = true;
        virtualCamera.m_Lens.FieldOfView = ZoomedInFov;
        fpsController.RotationSpeed = ZoomedInSensitivity;
    }
}
