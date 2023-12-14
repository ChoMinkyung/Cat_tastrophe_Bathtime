using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Setting : MonoBehaviour
{
    [Header("�Ͻ����� �˾�")]
    public GameObject pausePopUp;
    [Header("����â �˾�")]
    public GameObject settingPopUp;

    [Header("��ô�� �˾�")]
    public GameObject clean;
    [Header("������ ��")]
    public GameObject itemWheel;

    [Header("�κ��")]
    public string lobbyName; 

    [Header("�÷��� ī�޶�")]
    public CinemachineVirtualCamera playCamera;

    public UIController uiController;
    public CursorEvent cursor;

    public delegate void PausePopupHandle();
    public event PausePopupHandle OnPausePopupTrue;
    public event PausePopupHandle OnPausePopupFalse;

    public void UpdatePause()
    {
        if (pausePopUp.activeSelf) // �Ͻ����� �˾� Ȱ��ȭ 
        {
            PlayerPrefs.SetInt("Pause", 0);

            cursor.CursorOff();
            pausePopUp.SetActive(false);
            Time.timeScale = 1f;
            OnPausePopupFalse?.Invoke();

            if (playCamera.gameObject.activeSelf)
            {
                uiController.ShowUI();
                itemWheel.SetActive(true);
            }
        }
        else if (!pausePopUp.activeSelf && !settingPopUp.activeSelf) // �� �� ��Ȱ��ȭ
        {
            PlayerPrefs.SetInt("Pause", 1);

            cursor.CursorOn();
            pausePopUp.SetActive(true);
            Time.timeScale = 0f;
            OnPausePopupTrue?.Invoke();

            uiController.RemoveUI();
            itemWheel.SetActive(false);

            if (clean.gameObject != null)
                clean.SetActive(false);
        }
        else if (settingPopUp.activeSelf) // ����â Ȱ��ȭ
        {
            PlayerPrefs.SetInt("Pause", 0);

            cursor.CursorOff();
            settingPopUp.SetActive(false);
            Time.timeScale = 1f;
            OnPausePopupFalse?.Invoke();

            if (playCamera.gameObject.activeSelf)
            {
                itemWheel.SetActive(true);
                uiController.ShowUI();
            }
        }
    }

    public void OnClickResume()
    {
        SoundManager.Instance.PlaySFX("Click");
        cursor.CursorOff();
        pausePopUp.SetActive(false);
        if (playCamera.gameObject.activeSelf)
        {
            itemWheel.SetActive(true);
            uiController.ShowUI();
        }
        Time.timeScale = 1f;
        OnPausePopupFalse?.Invoke();
    }

    public void OnClickSetting()
    {
        SoundManager.Instance.PlaySFX("Click");
        pausePopUp.SetActive(false);
        settingPopUp.SetActive(true);
    }

    public void OnClickExit()
    {
        SoundManager.Instance.PlaySFX("Click");
        Time.timeScale = 1f;
        SceneManager.LoadScene(lobbyName);
    }

    public void ClosePopUp()
    {
        SoundManager.Instance.PlaySFX("Click");
        cursor.CursorOff();
        settingPopUp.SetActive(false);
        Time.timeScale = 1f;
        OnPausePopupFalse?.Invoke();

        if (playCamera.gameObject.activeSelf)
        {
            itemWheel.SetActive(true);
            uiController.ShowUI();
        }
    }
    
}
