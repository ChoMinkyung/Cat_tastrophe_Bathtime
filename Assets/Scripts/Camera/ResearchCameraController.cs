using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ResearchCameraController : MonoBehaviour
{
    Camera mainCamera;

    [SerializeField] public CinemachineVirtualCamera iMacCamera;
    [SerializeField] public CinemachineVirtualCamera doorCamera;
    [SerializeField] public CinemachineVirtualCamera playCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void SetIMacCamera()
    {
        PlayerPrefs.SetInt("Camera", 20);
        iMacCamera.gameObject.SetActive(true);
        doorCamera.gameObject.SetActive(false);
        playCamera.gameObject.SetActive(false);

        Camera.main.cullingMask = ~(1 << LayerMask.NameToLayer("Item"));
    }

    public void SetDoorCamera()
    {
        PlayerPrefs.SetInt("Camera", 20);
        iMacCamera.gameObject.SetActive(false);
        doorCamera.gameObject.SetActive(true);
        playCamera.gameObject.SetActive(false);

        Camera.main.cullingMask = Camera.main.cullingMask & ~(1 << LayerMask.NameToLayer("Item"));
        Camera.main.cullingMask = Camera.main.cullingMask & ~(1 << LayerMask.NameToLayer("Enemy"));
        Camera.main.cullingMask = Camera.main.cullingMask & ~(1 << LayerMask.NameToLayer("Object"));
    }

    public void SetPlayCamera()
    {
        PlayerPrefs.SetInt("Camera", 10);
        iMacCamera.gameObject.SetActive(false);
        doorCamera.gameObject.SetActive(false);
        playCamera.gameObject.SetActive(true);

        // CullingMask�� Everything���� ����
        Camera.main.cullingMask = -1;
    }

}
