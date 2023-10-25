using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;

    [SerializeField]
    private float limitTime = 36000; // ���� �ð� 10��

    private void Start()
    {
        /*StartCoroutine(TimerCouroutine());*/
    }

    private void Update()
    {
        limitTime -= Time.deltaTime * 60;

        timerText.text = Mathf.Floor(limitTime / 3600).ToString("00") + ":" + Mathf.Floor((limitTime / 60) % 60).ToString("00");

        if (limitTime == 0)
            Debug.Log("���� ����");

        //yield return null;
        //StartCoroutine(TimerCouroutine());
    }
}

/*
if (gameTime == 0)
    Debug.Log("���� ����");

ToString(D2) : 2�� �� 02�� ǥ��
*/