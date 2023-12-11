using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestSubtitle : MonoBehaviour
{
    public TextMeshProUGUI subtitleText;

    [Header("ǥ���� �ڸ� ����")]
    public string subtitleContent;
    [Header("Ÿ���� �ӵ�")]
    public float typingSpeed;

    private bool hasShow = false;

    Coroutine curCoroutine;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !hasShow)
        {
            if(!subtitleText.gameObject.activeSelf)
            {
                hasShow = true;
                subtitleText.gameObject.SetActive(true);
                StartCoroutine(Typing(subtitleContent, typingSpeed));
            }
        }
    }
    public void ShowQuestSubtitle(string content, float speed = 0.07f, float delayTime = 0)
    {
        if (!subtitleText.gameObject.activeSelf)
        {
            hasShow = true;
            subtitleText.gameObject.SetActive(true);
            curCoroutine = StartCoroutine(Typing(content, speed, delayTime));
        }
    }


    IEnumerator Typing(string txt, float speed = 0.07f, float delayTime = 0)
    {
        subtitleText.text = null;

        // ���� �� ���̸� �� �ٲ�
        if (txt.Contains("  "))
            txt = txt.Replace("  ", "\n");

        yield return new WaitForSeconds(delayTime);

        SoundManager.Instance.PlaySFX("Keyboard");
        for (int i = 0; i < txt.Length; i++)
        {
            subtitleText.text += txt[i];
            yield return new WaitForSeconds(speed);
        }
        SoundManager.Instance.StopSFX();

        yield return new WaitForSeconds(1f);
        subtitleText.gameObject.SetActive(false);
    }

    public void StopSubtitle()
    {
        if (curCoroutine != null)
        {
            StopCoroutine(curCoroutine);
            subtitleText.gameObject.SetActive(false);
        }
    }

}
