using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponTest : MonoBehaviour
{
    private Transform weaponContainer; // ���� �����̳�

    /*public GameObject softRifle; 
    public GameObject bubbleGun; 
    public GameObject splashBuster; */

    private float softRifleBulletCount = 10;
    private float bubbleGunBulletCount = 400;
    private float splashBusterBulletCount = 40; // 8�߾�

    public TextMeshProUGUI softRifleText;
    public TextMeshProUGUI bubbleGunText;
    public TextMeshProUGUI splashBusterText;

    private bool isSoftRifleSelected = false;
    private bool isBubbleGunSelected = false;
    private bool isSplashBusterSelected = false;

    public Image softRifleImage;
    public Image bubbleGunImage;
    public Image splashBusterImage;

    void Start()
    {
        // ���� ���� �� �ʱ� ���� ����
        weaponContainer = gameObject.transform;
        SelectWeapon(0);
        
        isSoftRifleSelected = true;
        isBubbleGunSelected = false;
        isSplashBusterSelected = false;
    }

    void Update()
    {
        // Ű(��: ���� 1, 2, 3)�� ���� ���� ����
        if (Input.GetKeyDown(KeyCode.Alpha1)) // SoftRifle
        {
            Debug.Log("1");
            SelectWeapon(0);

            isSoftRifleSelected = true;
            isBubbleGunSelected = false;
            isSplashBusterSelected = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // BubbleGun
        {
            Debug.Log("2");
            SelectWeapon(1);

            isSoftRifleSelected = false;
            isBubbleGunSelected = true;
            isSplashBusterSelected = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // SplashBuster
        {
            Debug.Log("3");
            SelectWeapon(2);

            isSoftRifleSelected = false;
            isBubbleGunSelected = false;
            isSplashBusterSelected = true;
        }


        if (isSoftRifleSelected)
            SelectSoftRifle();
        else if (isBubbleGunSelected)
            SelectBubbleGun();
        else if (isSplashBusterSelected)
            SelectSplashBuster();
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

    void SelectSoftRifle() // ������ : 8��
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(softRifleBulletCount > 0)
            {
                softRifleBulletCount--;
                softRifleImage.fillAmount = softRifleBulletCount / 10;
                softRifleText.text = softRifleBulletCount + " / 10";
            }



            /*if(softRifleBulletCount == 0)
            {
                StartCoroutine(Delaytime(8, 0));
            }*/
        }
    }


    void SelectBubbleGun() // ������ : 8��
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (bubbleGunBulletCount > 0)
            {
                bubbleGunBulletCount--;
                bubbleGunImage.fillAmount = bubbleGunBulletCount / 400;
                bubbleGunText.text = bubbleGunBulletCount + " / 400";
            }

            /*if (bubbleGunBulletCount == 0)
            {
                StartCoroutine(Delaytime(8, 1));
            }*/
        }
    }

    void SelectSplashBuster() // ������ : 6��
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (splashBusterBulletCount > 0)
            {
                splashBusterBulletCount -= 8;
                splashBusterImage.fillAmount = splashBusterBulletCount / 40;
                splashBusterText.text = splashBusterBulletCount + " / 40";
            }

            /*if (splashBusterBulletCount == 0)
            {
                StartCoroutine(Delaytime(6, 2));
            }*/
        }
    }

    
    private IEnumerator Delaytime(float delayTime, int weaponNum)
    {
        yield return new WaitForSeconds(delayTime);

        switch (weaponNum)
        {
            case 0:
                softRifleBulletCount = 10;
                Debug.Log(softRifleBulletCount);
                softRifleText.text = softRifleBulletCount + " / 10";
                break;
            case 1:
                bubbleGunBulletCount = 400;
                Debug.Log(bubbleGunBulletCount);
                softRifleText.text = bubbleGunBulletCount + " / 400";
                break;
            case 2:
                splashBusterBulletCount = 40;
                Debug.Log(splashBusterBulletCount);
                splashBusterText.text = splashBusterBulletCount + " / 40";
                break;

        }
    }

}


/*Transform child = weaponContainer.GetChild(i);
Vector3 newPosition = Vector3.up;
newPosition.y = Vector3.up.y * i * 100 - 300; // ���⸦ ���Ʒ��� ������� ��ġ
child.localPosition = newPosition;*/