using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchCenter : MonoBehaviour
{
    // �Ԥ��� �帧 ���ñ� ��¼�� �� ����

    // �ڸ� ���� ? // ���� �ڸ� ���;��ϴ��� üũ
    // ����Ʈ Ŭ���� ���� .
    //

    [Header("�÷��̾� �ڸ�")]
    [SerializeField] public Subtitle subtitle;

    [Header("����Ʈ �ڸ�")]
    [SerializeField] public QuestSubtitle questSubtitle;

    [Header("CCTV ����Ʈ")]
    [SerializeField] public CCTVOperation cctvOperation;
    
    [Header("ī�޶� ����")]
    [SerializeField] public ResearchCameraController cameraController;
    
    [Header("�⺻ �Է� ����")]
    [SerializeField] public InputCenter inputCenter;



    
    private void Start()
    {
        cctvOperation.OnCloseBarrierTrue += OnBarrierTrue;
        cctvOperation.OnCloseBarrierFalse += OnBarrierFalse;
        cctvOperation.OnCloseDoorTrue += OnDoorTrue;
        cctvOperation.OnCloseDoorFalse += OnDoorFalse;
    }

    public void OnBarrierTrue()
    {
        inputCenter.gameObject.SetActive(false);
        subtitle.ShowSubtitle("ī������ : ����! ��� ���� ��ɾ�!");
    }

    public void OnBarrierFalse()
    {
        inputCenter.gameObject.SetActive(true);
    }

    public void OnDoorTrue()
    {
        inputCenter.gameObject.SetActive(false);
        cameraController.SetDoorCamera();
        subtitle.ShowSubtitle("ī������ : �̷�! �츮�� �ִ� ����� ����ݾ�!");
    }

    public void OnDoorFalse()
    {
        inputCenter.gameObject.SetActive(true);
        cameraController.SetPlayCamera();
        questSubtitle.ShowQuestSubtitle("��ư�� ��� �÷� ���� ��������", 0.1f);

    }
}
