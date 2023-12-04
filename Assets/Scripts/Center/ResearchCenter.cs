using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchCenter : MonoBehaviour
{                                                                   
    [Header("�÷��̾� �ڸ�")]
    [SerializeField] public Subtitle subtitle;

    [Header("����Ʈ �ڸ�")]
    [SerializeField] public QuestSubtitle questSubtitle;

    [Header("UI")]
    [SerializeField] public UIController controllerUI;

    [Header("CCTV ����Ʈ")]
    [SerializeField] public CCTV cctv;

    [Header("�� ������Ʈ")]
    [SerializeField] public Barrier barrier;

    [Header("�� ������Ʈ")]
    [SerializeField] public Door door;

    [Header("����ġ ������Ʈ")]
    [SerializeField] public SwitchesOperation switches;

    [Header("ī�޶� ����")]
    [SerializeField] public ResearchCameraController cameraController;
    
    [Header("�⺻ �Է� ����")]
    [SerializeField] public InputHandler inputHandler;

    [Header("���� ����")]
    public GameObject endPoint;

    private void Start()
    {
        StartCoroutine(StartResearchScene());
        endPoint.SetActive(false);

        switches.InitSwitch(false);
        cctv.OnCCTV += ShutBarrier; // CCTV �ѱ�
        barrier.OnBarrier += ShutDoor; // �庮 ��������
        door.OnCloseDoor += OnSwitch; // �� �ݱ�
        switches.OnSwitch += UnlockDoor; // ����ġ ����Ʈ
        door.OnOpenDoor += ClearStage; // �� ����
    }

    public IEnumerator StartResearchScene()
    {
        controllerUI.RemoveUI();
        inputHandler.gameObject.SetActive(false);
        cameraController.SetIMacCamera();
        subtitle.ShowSubtitle("ī������ : ���� ��ǻ�Ͱ� �־�!  �� ��� ���� �ᰡ����!", delayTime: 1f);

        yield return new WaitForSeconds(6.5f);

        controllerUI.ShowUI();
        cameraController.SetPlayCamera();
        inputHandler.gameObject.SetActive(true);
    }

    public void ShutBarrier()
    {
        controllerUI.RemoveUI();
        inputHandler.gameObject.SetActive(false);
        StartCoroutine(barrier.MoveBarrierCoroutine());
        subtitle.ShowSubtitle("ī������ : ����! ��� ���� ��ɾ�!", speed: 0.09f, delayTime: 2.5f) ;
    }

    public void ShutDoor()
    {
        cameraController.SetDoorCamera();
        StartCoroutine(door.CloseDoor());
        subtitle.ShowSubtitle("ī������ : �̷�! �츮�� �ִ� ����� ����ݾ�!");
    }

    public void OnSwitch()
    {
        inputHandler.gameObject.SetActive(true);
        cameraController.SetPlayCamera();
        subtitle.ShowSubtitle("ī������ : ���� �ִ� ����ġ�� �̿��ϸ� �� �� ������?");
        switches.InitSwitch();
        controllerUI.ShowUI();
    }

    public void UnlockDoor()
    {
        controllerUI.RemoveUI();
        inputHandler.gameObject.SetActive(false);
        cameraController.SetDoorCamera();
        StartCoroutine(door.OpenDoor());
        subtitle.ShowSubtitle("ī������ : �س´�! ���� ���Ⱦ�!", delayTime : 1f);
    }

    public void ClearStage()
    {
        controllerUI.ShowUI();
        inputHandler.gameObject.SetActive(true);
        cameraController.SetPlayCamera();
        subtitle.ShowSubtitle("ī������ : CCTV�� ���� ��Ű�� ��ġ�� ������!", delayTime: 1f);
        endPoint.SetActive(true);
    }
}
