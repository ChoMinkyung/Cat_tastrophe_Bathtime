using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemWheel : MonoBehaviour
{
    public Transform center; // �߾��� �������� ���콺 ���� ���
    public Transform selectObject; // ���õ� �� ȸ��

    public GameObject itemMenu; // ������ �� �޴�
    bool isMenuActive; // �޴��� Ȱ�� ����

    public TextMeshProUGUI itemName; // ������ �̸�
    public TextMeshProUGUI itemExplanation; // ������ ����

    public string[] itemNameArray; 
    public string[] itemExplanationArray;

    public Transform[] itemSlotArray; // ������ �̹��� Ȯ��
    public Transform[] energySlotArray; // ������� �̹��� Ȯ��

    public Transform itemMin, itemMax; // ������ �� �� ���
    public Transform energyMin, energyMax; // ������� �� ���

    public GameObject kineticEnergyMenu; // � ������ ���ý� �޴�â
    bool isEnergyMenuActive; // ������� �޴� Ȱ�� ����

    public TextMeshProUGUI moveSpeed; // �̵��ӵ� ����
    public TextMeshProUGUI attackSpeed; // ���ݼӵ� ����

    bool hasRightMouseClicked = false;


    void Start()
    {
        DeactivateMenu();
        DeactivateEnergyMenu();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(2)) // ���콺 �� ��ư ����â Ȱ��ȭ
        {
            isMenuActive = !isMenuActive;
            
            if (isMenuActive && !isEnergyMenuActive)
                itemMenu.SetActive(true);
            if(!isMenuActive)
                itemMenu.SetActive(false);
        }

        if (Input.GetMouseButtonUp(0))
        {
            hasRightMouseClicked = false;
        }

        if (isMenuActive)
        {
            UpdateMenu();
        }

        if (isEnergyMenuActive)
        {
            UpdateEnergyMenu();
        }
    }



    void ActivateMenu()
    {
        isMenuActive = true;
        itemMenu.SetActive(isMenuActive);
    }

    void DeactivateMenu()
    {
        isMenuActive = false;
        itemMenu.SetActive(false);
    }

    void ActivateEnergyMenu()
    {
        isEnergyMenuActive = true;
        kineticEnergyMenu.SetActive(true);
    }

    void DeactivateEnergyMenu()
    {
        isEnergyMenuActive = false;
        kineticEnergyMenu.SetActive(false);
    }

    float CalculateAngle(Vector3 centerPosition, Vector3 targetPosition)
    {
        Vector2 delta = centerPosition - targetPosition; // �߾ӿ������� ���콺 ��ġ�� ����
        float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg; // ���� ���ϴ� ���� 
        angle += 180; // ������ -180���� 180�̹Ƿ� 180 ������ (���� ���� ó���ϱ� ���ؼ�)

        return angle;
    }

    void UpdateMenu()
    {
        // �߾����κ����� ���콺 �Ÿ��� ��谪 �ȿ� �ִ��� Ȯ��
        if (Vector3.Distance(Input.mousePosition, center.position) < Vector3.Distance(itemMax.position, center.position) && Vector3.Distance(Input.mousePosition, center.position) > Vector3.Distance(itemMin.position, center.position))
        {
            float angle = CalculateAngle(center.position, Input.mousePosition);         

            int currentItem = 0; // ������ ��ȣ Ȯ��

            for (int i = 0; i < 360; i += 60)
            {
                if (angle >= i && angle < i + 60)
                {
                    selectObject.eulerAngles = new Vector3(0, 0, i); // Z�� ������ ȸ��

                    itemName.text = itemNameArray[currentItem];
                    itemExplanation.text = itemExplanationArray[currentItem];

                    foreach (Transform t in itemSlotArray)
                    {
                        t.transform.localScale = new Vector3(1, 1, 1); // ��� �̹��� ũ�� (1, 1, 1)�� ����
                    }
                    itemSlotArray[currentItem].transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);

                    if (Input.GetMouseButtonDown(0) && !hasRightMouseClicked)
                    {
                        hasRightMouseClicked = true;

                        Debug.Log(itemNameArray[currentItem] + "����");
                        DeactivateMenu();

                        // ������� ���ý� ���ο� �˾�â ����
                        if (angle >= 300 && angle < 360)
                        {
                            ActivateEnergyMenu();
                        }
                    }
                }
                currentItem++;
            }
        }
        else
        {
            itemName.text = "MENU";
            itemExplanation.text = " ";

            foreach (Transform t in itemSlotArray)
            {
                t.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("���� ���");
            DeactivateMenu();
        }
    }

    void UpdateEnergyMenu()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("� ������ ���� ���");
            DeactivateEnergyMenu();
            ActivateMenu();
        }
        else if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("���� ���");
            DeactivateEnergyMenu();
            DeactivateMenu();
        }


        if (Vector3.Distance(Input.mousePosition, center.position) < Vector3.Distance(energyMax.position, center.position) && Vector3.Distance(Input.mousePosition, center.position) > Vector3.Distance(energyMin.position, center.position))
        {
            float energyAngle = CalculateAngle(center.position, Input.mousePosition);

            int selectedEnergySlot = (energyAngle > 90 && energyAngle < 270) ? 0 : 1;

            energySlotArray[0].transform.localScale = selectedEnergySlot == 0 ? new Vector3(1.3f, 1.3f, 1.3f) : Vector3.one; //Vector3.one = ��� �࿡ ���� ũ�⸦ 1��
            energySlotArray[1].transform.localScale = selectedEnergySlot == 1 ? new Vector3(1.3f, 1.3f, 1.3f) : Vector3.one;

            moveSpeed.text = selectedEnergySlot == 0 ? "ĳ������ �̵��ӵ��� ������Ų��." : " ";
            attackSpeed.text = selectedEnergySlot == 1 ? "�÷��̾��� ���� �ӵ��� ��½�Ų��." : " ";

            if (Input.GetMouseButtonDown(0) && !hasRightMouseClicked)
            {
                hasRightMouseClicked = true;
                Debug.Log(energySlotArray[selectedEnergySlot] + "����");
                DeactivateEnergyMenu();
            }
        }
        else
        {
            moveSpeed.text = " ";
            attackSpeed.text = " ";

            foreach (Transform t in energySlotArray)
            {
                t.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}

// Atan2�� ��ȯ���� ���� �̱� ������ �������� ����ϱ� ���ؼ� Mathf.Rad2Deg �� �̿�
// Mathf.Rad2Deg�� ������ ������ ��ȯ���ִ� ����� ��Ÿ����, �װ��� 360 / ( PI * 2 )�� ����.


