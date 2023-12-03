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


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !hasShow)
        {
            if(!subtitleText.gameObject.activeSelf)
            {
                hasShow = true;
                subtitleText.gameObject.SetActive(true);
                StartCoroutine(Typing(subtitleContent));
            }
        }
    }

    IEnumerator Typing(string txt)
    {
        subtitleText.text = null;
        SoundManager.Instance.PlaySFX("Keyboard");

        // ���� �� ���̸� �� �ٲ�
        if (txt.Contains("  "))
            txt = txt.Replace("  ", "\n");

        for (int i = 0; i < txt.Length; i++)
        {
            subtitleText.text += txt[i];
            yield return new WaitForSeconds(typingSpeed);
        }
        SoundManager.Instance.StopSFX();

        yield return new WaitForSeconds(1f);
        subtitleText.gameObject.SetActive(false);
    }
}
