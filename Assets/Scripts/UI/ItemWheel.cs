using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemWheel : MonoBehaviour
{
    public Transform center; // �߾��� �������� ���콺 ���� ���
    public Transform selectObject; // ���õ� �� ȸ��

    public GameObject itemMenu; // ������ �� �޴�
    bool isActive; // �޴��� Ȱ�� ����

    public TextMeshProUGUI itemName; // ������ �̸�
    public TextMeshProUGUI itemExplanation; // ������ ����

    public string[] itemNameArray;
    public string[] itemExplanationArray;

    public Transform[] itemSlotArray; // ������ �̹��� Ȯ��
    public Transform[] energySlotArray; // ������� �̹��� Ȯ��

    public Transform itemMin, itemMax; // ������ �� �� ���
    public Transform energyMin, energyMax; // ������� �� ���

    public GameObject kineticEnergyMenu; // � ������ ���ý� �޴�â
    bool isMenuActive;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        itemMenu.SetActive(false);

        isMenuActive = false;
        kineticEnergyMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2)) // ���콺 �� ��ư ����â Ȱ��ȭ
        {
            isActive = !isActive;
            if (isActive && !isMenuActive)
                itemMenu.SetActive(true);
            if(!isActive)
                itemMenu.SetActive(false);
        }

        if (isActive)
        {
            // �߾����κ����� ���콺 �Ÿ��� ��谪 �ȿ� �ִ��� Ȯ��
            if (Vector3.Distance(Input.mousePosition, center.position) < Vector3.Distance(itemMax.position, center.position) && Vector3.Distance(Input.mousePosition, center.position) > Vector3.Distance(itemMin.position, center.position))
            {
                // ���� ��� 
                Vector2 delta = center.position - Input.mousePosition; // �߾ӿ������� ���콺 ��ġ�� ����
                float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg; // ���� ���ϴ� ���� 
                angle += 180; // ������ -180���� 180�̹Ƿ� 180 ������ (���� ���� ó���ϱ� ���ؼ�)

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

                        if (Input.GetMouseButtonDown(0))
                        { 
                            Debug.Log(angle);
                            Debug.Log(itemNameArray[currentItem] + "����");
                            isActive = false;
                            itemMenu.SetActive(false);

                            // ������� ���ý� ���ο� �˾�â ����
                            if(angle >= 300 && angle < 360)
                            {
                                isMenuActive = true;
                                kineticEnergyMenu.SetActive(true);
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
                    t.transform.localScale = new Vector3(1, 1, 1); // ��� �̹��� ũ�� (1, 1, 1)�� ����
                }

                /*if (Input.GetMouseButtonDown(0))
                {
                    itemName.text = "MENU";
                    itemExplanation.text = " ";

                    isActive = false;
                    itemMenu.SetActive(false);
                }*/
            }

            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("���� ���");
                isActive = false;
                itemMenu.SetActive(false);
            }
        }

        if (isMenuActive)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("� ������ ���� ���");
                isMenuActive = false;
                kineticEnergyMenu.SetActive(false);

                isActive = true;
                itemMenu.SetActive(true);
            }
            else if (Input.GetMouseButtonDown(2))
            {
                Debug.Log("���� ���");
                isMenuActive = false;
                kineticEnergyMenu.SetActive(false);
            }

            if (Vector3.Distance(Input.mousePosition, center.position) < Vector3.Distance(energyMax.position, center.position) && Vector3.Distance(Input.mousePosition, center.position) > Vector3.Distance(energyMin.position, center.position))
            {
                // ���� ��� 
                Vector2 delta2 = center.position - Input.mousePosition; // �߾ӿ������� ���콺 ��ġ�� ����
                float angle2 = Mathf.Atan2(delta2.y, delta2.x) * Mathf.Rad2Deg; // ���� ���ϴ� ���� 
                angle2 += 180;

                if (angle2 > 90 && angle2 < 270)
                {
                    energySlotArray[0].transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
                    energySlotArray[1].transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    energySlotArray[0].transform.localScale = new Vector3(1, 1, 1);
                    energySlotArray[1].transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
                }
                        /*if (Input.GetMouseButtonDown(0))
                        {
                            Debug.Log(energySlotArray[currentItem2] + "����");
                            isMenuActive = false;
                            kineticEnergyMenu.SetActive(false);
                        }*/
                
            }
            else
            {
                foreach (Transform e in energySlotArray)
                {
                    e.transform.localScale = new Vector3(1, 1, 1);
                }
            }

        }

    }
}

// Atan2�� ��ȯ���� ���� �̱� ������ �������� ����ϱ� ���ؼ� Mathf.Rad2Deg �� �̿�
// Mathf.Rad2Deg�� ������ ������ ��ȯ���ִ� ����� ��Ÿ����, �װ��� 360 / ( PI * 2 )�� ����.


