using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    private Transform weaponContainer; // ���� �����̳�

    void Start()
    {
        // ���� ���� �� �ʱ� ���� ����
        weaponContainer = gameObject.transform;
        SelectWeapon(2);
    }

    void Update()
    {
        // Ű(��: ���� 1, 2, 3)�� ���� ���� ����
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1");
            SelectWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("2");
            SelectWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("3");
            SelectWeapon(2);
        }
    }

    void SelectWeapon(int weaponNum)
    {
        // ������ ���⸦ �θ� �����̳��� ���� �Ʒ��� �̵�
        weaponContainer.GetChild(weaponNum).GetComponent<RectTransform>().anchoredPosition = new Vector3(50, -250, 0);


        int j = 1;

        // ��� ���� ��ġ ������
        for (int i = 0; i < weaponContainer.childCount; i++)
        {
            if (i == weaponNum) continue;

            weaponContainer.GetChild(i).GetComponent<RectTransform>().anchoredPosition = new Vector3(50, -250 + j * 100, 0);

            j++;
        }
    }


}


            /*Transform child = weaponContainer.GetChild(i);
            Vector3 newPosition = Vector3.up;
            newPosition.y = Vector3.up.y * i * 100 - 300; // ���⸦ ���Ʒ��� ������� ��ġ
            child.localPosition = newPosition;*/