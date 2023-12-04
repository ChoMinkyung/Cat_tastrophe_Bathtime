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

    [Header("��")]
    [SerializeField] public Barrier barrier;

    [Header("��")]
    [SerializeField] public Door door;

    [Header("ī�޶� ����")]
    [SerializeField] public ResearchCameraController cameraController;
    
    [Header("�⺻ �Է� ����")]
    [SerializeField] public InputCenter inputCenter;


    private void Start()
    {
        cctv.OnCCTV += ShutBarrier; // CCTV �ѱ�
        barrier.OnBarrier += ShutDoor; // �庮 ��������
        door.OnCloseDoor += OnSwitch; // �� �ݱ�
    }

    public void ShutBarrier()
    {
        inputCenter.gameObject.SetActive(false);
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
        inputCenter.gameObject.SetActive(true);
        cameraController.SetPlayCamera();
        questSubtitle.ShowQuestSubtitle("��ư�� ��� �÷� ���� ��������", 0.09f);
    }
}
