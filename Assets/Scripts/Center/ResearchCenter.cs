using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchCenter : MonoBehaviour
{                                                                   
    [Header("�÷��̾� �ڸ�")]
    [SerializeField] public Subtitle subtitle;

    [Header("����Ʈ �ڸ�")]
    [SerializeField] public QuestSubtitle questSubtitle;

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


    private void Start()
    {
        switches.InitSwitch(false);

        cctv.OnCCTV += ShutBarrier; // CCTV �ѱ�
        barrier.OnBarrier += ShutDoor; // �庮 ��������
        door.OnCloseDoor += OnSwitch; // �� �ݱ�
        switches.OnSwitch += UnlockDoor; // ����ġ ����Ʈ
        door.OnOpenDoor += ClearStage; // �� ����
    }

    public void ShutBarrier()
    {
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
    }

    public void UnlockDoor()
    {
        inputHandler.gameObject.SetActive(false);
        cameraController.SetDoorCamera();
        StartCoroutine(door.OpenDoor());
        subtitle.ShowSubtitle("ī������ : �س´�! ���� ���Ⱦ�!", delayTime : 1f);
    }

    public void ClearStage()
    {
        inputHandler.gameObject.SetActive(true);
        cameraController.SetPlayCamera();
        subtitle.ShowSubtitle("ī������ : CCTV�� ���� ��Ű�� ��ġ�� ������!", delayTime: 2f); ;
    }
}
