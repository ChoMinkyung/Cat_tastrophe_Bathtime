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
        StartCoroutine(TimerCouroutine());
    }

    IEnumerator TimerCouroutine()
    {
        limitTime -= 1;

        timerText.text = Mathf.Floor(limitTime / 3600).ToString("00") + ":" + Mathf.Floor(limitTime % 60).ToString("00");

        yield return new WaitForSeconds(1);

        if (limitTime == 0)
            Debug.Log("���� ����");

        StartCoroutine(TimerCouroutine());
    }
}

