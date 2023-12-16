using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputCenter : MonoBehaviour
{
    [Header("UI ��ǲ �ڵ�")]
    public UIInputHandler uiHandle;

    [Header("����â")]
    public Setting setting;

    [Header("��ô�� �˾�")]
    public CleanlinessPopUpObserver clean;

    [Header("ũ�ν� ���")]
    public CrossHairSelection crossHair;

    private void Start()
    {
        uiHandle.OnPausePopUp += ActivePausePopUp;
        if (clean != null)
        {
            uiHandle.OnCleanlinessPopUpTrue += ActiveCleanPopUp;
            uiHandle.OnCleanlinessPopUpFalse += DeactiveCleanPopUp;
        }
        uiHandle.OnSelectSoapRifle += OnSoapRifle;
        uiHandle.OnSelectSplashBuster += OnSplashBuster;
        uiHandle.OnselectBubbleGun += OnBubbleGun;
    }

    public void ActivePausePopUp()
    {
        setting.UpdatePause();
    }

    public void ActiveCleanPopUp()
    {
        clean.ActivateCleanliness();
    }

    public void DeactiveCleanPopUp()
    {
        clean.DeactivateCleanliness();
    }

    public void OnSoapRifle()
    {
        crossHair.SelectSoapRifle();
    }

    public void OnSplashBuster()
    {
        crossHair.SelectSplashBuster();
    }

    public void OnBubbleGun()
    {
        crossHair.SelectBubbleGun();
    }
}
