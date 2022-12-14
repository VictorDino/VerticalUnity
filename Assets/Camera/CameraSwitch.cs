using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    [SerializeField]
    private Canvas cameraCanvas;

    [SerializeField]
    private Canvas aimCanvas;

    private CinemachineVirtualCamera vCamera;
    private InputAction aimAction;

    private int priorityBoostAmount = 10;

    private void Awake()
    {
        vCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aim"];
    }

    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CanceledAim();
    }

    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CanceledAim();
    }

    private void StartAim()
    {
        vCamera.Priority += priorityBoostAmount;
        aimCanvas.enabled = true;
        cameraCanvas.enabled = false;
    }

    private void CanceledAim()
    {
        vCamera.Priority -= priorityBoostAmount;
        aimCanvas.enabled = false;
        cameraCanvas.enabled = true;
    }

}
