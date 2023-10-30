using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemWheel : MonoBehaviour
{
    public Transform center; // �߾��� �������� ���콺 ���� ���
    public Transform selectObject; // ���õ� �� ȸ��

    public GameObject itemMenu;
    bool isActive; // �޴��� Ȱ�� ����

    public TextMeshProUGUI itemName; // ������ �̸�
    public TextMeshProUGUI itemExplanation; // ������ ����

    public string[] itemNameArray;
    public string[] itemExplanationArray;

    public Transform[] itemSlotArray; // ������ �̹��� Ȯ��

    public Transform min, max; // �� ���

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
            if (isActive)
                itemMenu.SetActive(true);
            else
                itemMenu.SetActive(false);
        }

        if (isActive)
        {
            // �߾����κ����� ���콺 �Ÿ��� ��谪 �ȿ� �ִ��� Ȯ��
            if (Vector3.Distance(Input.mousePosition, center.position) < Vector3.Distance(max.position, center.position) && Vector3.Distance(Input.mousePosition, center.position) > Vector3.Distance(min.position, center.position))
            {
                // ���� ��� 
                Vector2 delta = center.position - Input.mousePosition; // �߾ӿ������� ���콺 ��ġ�� ����
                float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg; // ���� ���ϴ� ���� 
                angle += 180; // ������ -180���� 180�̹Ƿ� 180 ������ (���� ���� ó���ϱ� ���ؼ�)

                int currentItem = 0; // ������ ��ȣ Ȯ��

                for (int i = 0; i < 360; i += 60)
                {
                    if (angle >= i + 30 && angle < i + 90)
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
    }
}

// Atan2�� ��ȯ���� ���� �̱� ������ �������� ����ϱ� ���ؼ� Mathf.Rad2Deg �� �̿�
// Mathf.Rad2Deg�� ������ ������ ��ȯ���ִ� ����� ��Ÿ����, �װ��� 360 / ( PI * 2 )�� ����.


