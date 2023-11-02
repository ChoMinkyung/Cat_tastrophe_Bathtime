/*
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemWheel : MonoBehaviour
{
    //...

    private Vector3 normalScale = new Vector3(1, 1, 1);
    private Vector3 enlargedScale = new Vector3(1.3f, 1.3f, 1.3f);

    // Start is called before the first frame update
    void Start()
    {
        DeactivateMenu();
        DeactivateKineticEnergyMenu();
    }

    //...

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            hasRightMouseClicked = false;
        }

        if (Input.GetMouseButtonDown(2)) // ���콺 �� ��ư ����â Ȱ��ȭ
        {
            isActive = !isActive;
            if (isActive && !isMenuActive)
                ActivateMenu();
            else
                DeactivateMenu();
        }

        if (isActive)
        {
            float mouseDistance = Vector3.Distance(Input.mousePosition, center.position);
            float itemMaxDistance = Vector3.Distance(itemMax.position, center.position);
            float itemMinDistance = Vector3.Distance(itemMin.position, center.position);

            // �߾����κ����� ���콺 �Ÿ��� ��谪 �ȿ� �ִ��� Ȯ��
            if (mouseDistance < itemMaxDistance && mouseDistance > itemMinDistance)
            {
                // ...
            }
            else
            {
                ResetItemName();
                ResetItemSlots();
            }

            if (Input.GetMouseButtonDown(1))
            {
                DeactivateMenu();
            }
        }

        if (isMenuActive)
        {
            if (Input.GetMouseButtonDown(1))
            {
                DeactivateKineticEnergyMenu();
                ActivateMenu();
            }
            else if (Input.GetMouseButtonDown(2))
            {
                DeactivateKineticEnergyMenu();
                DeactivateMenu();
            }

            // ...
        }
    }

    void ActivateMenu()
    {
        Debug.Log(isActive);
        itemMenu.SetActive(true);
    }

    void DeactivateMenu()
    {
        Debug.Log("���� ���");
        isActive = false;
        itemMenu.SetActive(false);
    }

    void ActivateKineticEnergyMenu()
    {
        isMenuActive = true;
        kineticEnergyMenu.SetActive(true);
    }

    void DeactivateKineticEnergyMenu()
    {
        Debug.Log("� ������ ���� ���");
        isMenuActive = false;
        kineticEnergyMenu.SetActive(false);
    }

    void ResetItemName()
    {
        itemName.text = "MENU";
        itemExplanation.text = " ";
    }

    void ResetItemSlots()
    {
        foreach (Transform t in itemSlotArray)
        {
            t.transform.localScale = normalScale; // ��� �̹��� ũ�� (1, 1, 1)�� ����
        }
    }
}


*/