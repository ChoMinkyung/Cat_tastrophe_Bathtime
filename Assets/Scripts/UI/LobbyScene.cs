using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LobbyScene : MonoBehaviour
{
    public void OnClickStart()
    {
        Debug.Log("���� ����");
        SceneManager.LoadScene("HanKyeol_Loading");

    }

    public void OnClickSetting()
    {
        Debug.Log("�ɼ�");
    }

    public void OnClickExit()
    {
#if UNITY_EDITOR // ��ó�� ���ù�
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // �����Ϳ��� �۵� �� ��
#endif
    }
}


