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

            if (PlayerPrefs.GetInt("Camera") != 20)
            {
                int cameraValue = PlayerPrefs.GetInt("Camera");
                Debug.Log("���� : " + cameraValue);

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

            if (PlayerPrefs.GetInt("Camera") != 20)
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
        
        if (PlayerPrefs.GetInt("Camera") != 20)
            uiController.ShowUI();
        if(PlayerPrefs.GetInt("Camera") == 10)
            itemWheel.SetActive(true);
        
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

        if (PlayerPrefs.GetInt("Camera") != 20)
            uiController.ShowUI();
        if (PlayerPrefs.GetInt("Camera") == 10)
            itemWheel.SetActive(true);
    }
    

}
