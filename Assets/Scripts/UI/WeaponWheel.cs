using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWheel : MonoBehaviour
{
    public Transform center; // �߾��� �������� ���콺 ���� ���
    public Transform selectObject; // ���õ� �� ȸ��

    public GameObject weaponMenu;

    bool isActive; // �޴��� Ȱ�� ����



    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2)) // ���콺 �� ��ư ����â Ȱ��ȭ
        {
            isActive = !isActive;
            if (isActive)
                weaponMenu.SetActive(true);
            else
                weaponMenu.SetActive(false);

            if(isActive)
            {
                // ���� ��� 
                Vector2 delta = center.position - Input.mousePosition; // �߾ӿ������� ���콺 ��ġ�� ����
                float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg; // ���� ���ϴ� ���� 
                angle += 180; // ������ -180���� 180�̹Ƿ� 180 ������ (���� ���� ó���ϱ� ���ؼ�)

                for(int i = 0; i < 360; i += 90) 
                {
                    if(angle >= i && angle < i + 45)
                    {
                        selectObject.eulerAngles = new Vector3(0, 0, i); // Z�� ������ ȸ��

                    }
                }
            }
        }
    }
}

// Atan2�� ��ȯ���� ���� �̱� ������ �������� ����ϱ� ���ؼ� Mathf.Rad2Deg �� �̿�
// Mathf.Rad2Deg�� ������ ������ ��ȯ���ִ� ����� ��Ÿ����, �װ��� 360 / ( PI * 2 )�� ����.


