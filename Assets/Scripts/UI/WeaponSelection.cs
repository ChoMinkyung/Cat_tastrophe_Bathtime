using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponSelection : MonoBehaviour
{
    private Transform weaponContainer; // ���� �����̳�

    private float softRifleBulletCount = 10;
    private float bubbleGunBulletCount = 400;
    private float splashBusterBulletCount = 40; // 8�߾�

    public TextMeshProUGUI softRifleText;
    public TextMeshProUGUI bubbleGunText;
    public TextMeshProUGUI splashBusterText;

    private bool isSoftRifleSelected = false;
    private bool isBubbleGunSelected = false;
    private bool isSplashBusterSelected = false;

    public Image softRifleProgress;
    public Image bubbleGunProgress;
    public Image splashBusterProgress;

    public Image softRifleBorder;
    public Image bubbleGunBorder;
    public Image splashBusterBorder;

    void Start()
    {
        // ���� ���� �� �ʱ� ���� ����
        weaponContainer = gameObject.transform;
        SelectWeapon(0);

        isSoftRifleSelected = true;
        isBubbleGunSelected = false;
        isSplashBusterSelected = false;

        softRifleProgress.color = new Color(127 / 255f, 215 / 255f, 247 / 255f);
        softRifleBorder.color = new Color(90 / 255f, 160 / 255f, 218 / 255f);
        bubbleGunProgress.color = Color.white;
        bubbleGunBorder.color = Color.white;
        splashBusterProgress.color = Color.white;
        splashBusterBorder.color = Color.white;
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

            softRifleProgress.color = new Color(127 / 255f, 215 / 255f, 247 / 255f);
            softRifleBorder.color = new Color(90 / 255f, 160 / 255f, 218 / 255f);

            bubbleGunProgress.color = Color.white;
            bubbleGunBorder.color = Color.white;
            splashBusterProgress.color = Color.white;
            splashBusterBorder.color = Color.white;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // BubbleGun
        {
            Debug.Log("2");
            SelectWeapon(1);

            isSoftRifleSelected = false;
            isBubbleGunSelected = true;
            isSplashBusterSelected = false;

            bubbleGunProgress.color = new Color(127 / 255f, 215 / 255f, 247 / 255f);
            bubbleGunBorder.color = new Color(90 / 255f, 160 / 255f, 218 / 255f);

            softRifleProgress.color = Color.white;
            softRifleBorder.color = Color.white;
            splashBusterProgress.color = Color.white;
            splashBusterBorder.color = Color.white;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // SplashBuster
        {
            Debug.Log("3");
            SelectWeapon(2);

            isSoftRifleSelected = false;
            isBubbleGunSelected = false;
            isSplashBusterSelected = true;

            splashBusterProgress.color = new Color(127 / 255f, 215 / 255f, 247 / 255f);
            splashBusterBorder.color = new Color(90 / 255f, 160 / 255f, 218 / 255f);

            softRifleProgress.color = Color.white;
            softRifleBorder.color = Color.white;
            bubbleGunProgress.color = Color.white;
            bubbleGunBorder.color = Color.white;
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
        weaponContainer.GetChild(weaponNum).GetComponent<RectTransform>().anchoredPosition = new Vector3(-60, -260, 0);
        // ������ ���� ũ�� Ŀ����
        weaponContainer.GetChild(weaponNum).localScale = new Vector3(1.32f, 1.32f, 1.32f);

        int j = 1;

        // ��� ���� ��ġ ������
        for (int i = 0; i < weaponContainer.childCount; i++)
        {
            if (i == weaponNum) continue;

            weaponContainer.GetChild(i).GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -240 + j * 85, 0);
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
}
