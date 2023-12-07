using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCenter : MonoBehaviour
{
    [Header("�÷��̾�")]
    public GameObject Player;

    [Header("������ �� UI")]
    public ItemWheel itemWheel;
    
    [Header("��ȣ ������")]
    public ProtectEnergyUse energyUse;
    
    [Header("��")]
    public HairBallUse hairBallUse;

    [Header("���� ������")]
    public RandomItem randomItem;

    private void Start()
    {
        itemWheel.onItemClick += ClickTrue;
        randomItem.OnRandomItem += GetRandomItem;
    }

    public void ClickTrue(string itemName)
    {
        switch(itemName)
        {
            case "��ȣ��":
                energyUse.CreateProtectEnergy(Player.transform.position, Player.transform);
                Debug.Log("[ItemCenter] ��ȣ������ ����");
                break;

            case "�̵��ӵ�":
                Debug.Log("[ItemCenter] ������� - �̵��ӵ� ����");
                break;

            case "���ݷ�":
                Debug.Log("[ItemCenter] ������� - ���ݷ� ����");
                break;

            case "�й�ġ":
                if (!hairBallUse.CheckObstacleInFront(Player.transform.position, Player.transform.forward))
                {
                    hairBallUse.CreateHairBall(Player.transform.position, Player.transform.forward);
                }
                else
                {
                    Debug.Log("[ItemCenter] ��ֹ��� �־� ������ �� ����");
                }
                Debug.Log("[ItemCenter] �й�ġ ����");
                break;

            case "��":
                Debug.Log("[ItemCenter] �� ����");
                break;
        }
    }

    public void GetRandomItem(string itemName)
    {
        switch(itemName)
        {
            case "WaterBottle":
                Debug.Log("[ItemCenter] ź�� ����");
                break;
            case "LifeEnergy":
                Debug.Log("[ItemCenter] �÷��̾� HP ����");
                break;
        }
    }
}
