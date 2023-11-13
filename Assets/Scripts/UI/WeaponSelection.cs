using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponSelection : MonoBehaviour
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

    public Image softRifleProgress;
    public Image splashBusterProgress;
    public Image bubbleGunProgress;

    public Image softRifleBorder;
    public Image splashBusterBorder;
    public Image bubbleGunBorder;

    void Start()
    {
        // ���� ���� �� �ʱ� ���� ����
        weaponContainer = gameObject.transform;
        SelectWeapon(0);

        isSoftRifleSelected = true;
        isSplashBusterSelected = false;
        isBubbleGunSelected = false;

        softRifleProgress.color = new Color(165 / 255f, 227 / 255f, 255 / 255f);
        softRifleBorder.color = new Color(8 / 255f, 156 / 255f, 210 / 255f);
        
        splashBusterProgress.color = Color.white;
        splashBusterBorder.color = Color.white;
        bubbleGunProgress.color = Color.white;
        bubbleGunBorder.color = Color.white;
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

            softRifleProgress.color = new Color(165 / 255f, 227 / 255f, 255 / 255f);
            softRifleBorder.color = new Color(8 / 255f, 156 / 255f, 210 / 255f);

            bubbleGunProgress.color = Color.white;
            bubbleGunBorder.color = Color.white;
            splashBusterProgress.color = Color.white;
            splashBusterBorder.color = Color.white;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // SplashBuster
        {
            Debug.Log("2");
            SelectWeapon(1);

            isSoftRifleSelected = false;
            isSplashBusterSelected = true;
            isBubbleGunSelected = false;

            splashBusterProgress.color = new Color(165 / 255f, 227 / 255f, 255 / 255f);
            splashBusterBorder.color = new Color(8 / 255f, 156 / 255f, 210 / 255f);

            softRifleProgress.color = Color.white;
            softRifleBorder.color = Color.white;
            bubbleGunProgress.color = Color.white;
            bubbleGunBorder.color = Color.white;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // BubbleGun
        {
            Debug.Log("3");
            SelectWeapon(2);

            isSoftRifleSelected = false;
            isSplashBusterSelected = false;
            isBubbleGunSelected = true;

            bubbleGunProgress.color = new Color(165 / 255f, 227 / 255f, 255 / 255f);
            bubbleGunBorder.color = new Color(8 / 255f, 156 / 255f, 210 / 255f);

            softRifleProgress.color = Color.white;
            softRifleBorder.color = Color.white;
            splashBusterProgress.color = Color.white;
            splashBusterBorder.color = Color.white;

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
        weaponContainer.GetChild(weaponNum).GetComponent<RectTransform>().anchoredPosition = new Vector3(-55, -280, 0);
        // ������ ���� ũ�� Ŀ����
        weaponContainer.GetChild(weaponNum).localScale = new Vector3(1.3f, 1.3f, 1.3f);

        int j = 1;

        // ��� ���� ��ġ ������
        for (int i = 0; i < weaponContainer.childCount; i++)
        {
            if (i == weaponNum) continue;

            weaponContainer.GetChild(i).GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -270 + j * 60, 0);
            weaponContainer.GetChild(i).localScale = Vector3.one;

            j++;
        }
    }

    void SelectSoftRifle() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (softRifleBulletCount > 0)
            {
                softRifleBulletCount--;
                softRifleProgress.fillAmount = softRifleBulletCount / 10;
                softRifleText.text = softRifleBulletCount.ToString();
            }
        }
    }

    void SelectSplashBuster() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (splashBusterBulletCount > 0)
            {
                splashBusterBulletCount -= 8;
                splashBusterProgress.fillAmount = splashBusterBulletCount / 40;
                splashBusterText.text = splashBusterBulletCount.ToString();
            }

        }
    }

    void SelectBubbleGun() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (bubbleGunBulletCount > 0)
            {
                bubbleGunBulletCount--;
                bubbleGunProgress.fillAmount = bubbleGunBulletCount / 400;
                bubbleGunText.text = bubbleGunBulletCount.ToString();
            }
        }
    }

}
