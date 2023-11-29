using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponTest : MonoBehaviour
{
    //1�� �� : SoftRifle 
    //2�� �� : SplashBuster
    //3�� �� : BubbleGun

    private Transform weaponContainer; // ���� �����̳�

    private float softRifleBulletCount = 10;
    private float splashBusterBulletCount = 40; // 8�߾�
    private float bubbleGunBulletCount = 400;

    public TextMeshProUGUI softRifleText;
    public TextMeshProUGUI splashBusterText;
    public TextMeshProUGUI bubbleGunText;

    private bool isSoftRifleSelected = false;
    private bool isSplashBusterSelected = false;
    private bool isBubbleGunSelected = false;

    public Image softRifleImage;
    public Image splashBusterImage;
    public Image bubbleGunImage;

    void Start()
    {
        // ���� ���� �� �ʱ� ���� ����
        weaponContainer = gameObject.transform;
        SelectWeapon(0);
        
        isSoftRifleSelected = true;
        isSplashBusterSelected = false;
        isBubbleGunSelected = false;
    }

    void Update()
    {
        // Ű(��: ���� 1, 2, 3)�� ���� ���� ����
        if (Input.GetKeyDown(KeyCode.Alpha1)) // SoftRifle
        {
            Debug.Log("1");
            SelectWeapon(0);

            isSoftRifleSelected = true;
            isSplashBusterSelected = false;
            isBubbleGunSelected = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // SplashBuster
        {
            Debug.Log("2");
            SelectWeapon(1);

            isSoftRifleSelected = false;
            isSplashBusterSelected = true;
            isBubbleGunSelected = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // BubbleGun
        {
            Debug.Log("3");
            SelectWeapon(2);

            isSoftRifleSelected = false;
            isSplashBusterSelected = false; ;
            isBubbleGunSelected = true;
        }


        if (isSoftRifleSelected)
            SelectSoftRifle();
        else if (isSplashBusterSelected)
            SelectSplashBuster();
        else if (isBubbleGunSelected)
            SelectBubbleGun();
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