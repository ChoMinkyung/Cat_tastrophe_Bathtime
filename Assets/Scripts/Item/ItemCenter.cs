using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCenter : MonoBehaviour
{
    public ItemWheel itemWheel;

    private void Start()
    {
        itemWheel.onItemClick += ClickTrue;
    }

    public void ClickTrue(string itemName)
    {
        switch(itemName)
        {
            case "��ȣ��":
                Debug.Log("[ItemCenter] ��ȣ������ ����");
                break;
            case "�̵��ӵ�":
                Debug.Log("[ItemCenter] ������� - �̵��ӵ� ����");
                break;
            case "���ݷ�":
                Debug.Log("[ItemCenter] ������� - ���ݷ� ����");
                break;
            case "�й�ġ":
                Debug.Log("[ItemCenter] �й�ġ ����");
                break;
            case "��":
                Debug.Log("[ItemCenter] �� ����");
                break;
        }
    }
}
