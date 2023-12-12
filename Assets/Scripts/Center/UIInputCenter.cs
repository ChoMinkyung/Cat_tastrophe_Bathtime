using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputCenter : MonoBehaviour
{
    [Header("UI ��ǲ �ڵ�")]
    public UIInputHandler uiHandle;

    [Header("�Ͻ����� �˾�")]
    public PausePopUp pause;

    [Header("��ô�� �˾�")]
    public CleanlinessPopUpObserver clean;

    private void Start()
    {
        uiHandle.OnPausePopUp += ActivePausePopUp;
        if (clean != null)
        {
            uiHandle.OnCleanlinessPopUpTrue += ActiveCleanPopUp;
            uiHandle.OnCleanlinessPopUpFalse += DeactiveCleanPopUp;
        }
    }

    public void ActivePausePopUp()
    {
        pause.UpdatePause();
    }

    public void ActiveCleanPopUp()
    {
        clean.ActivateCleanliness();
    }

    public void DeactiveCleanPopUp()
    {
        clean.DeactivateCleanliness();
    }
}
