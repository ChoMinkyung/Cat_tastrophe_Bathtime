using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypingEffect : MonoBehaviour
{
    public TextMeshProUGUI subtitleText;
    
    [Header("ǥ���� �ڸ� ����")]
    public string subtitleContent;
    [Header("Ÿ���� �ӵ�")]
    public float typingSpeed;

    private bool isTyping = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTyping)
        {
            isTyping = true;
            subtitleText.gameObject.SetActive(true);
            StartCoroutine(Typing(subtitleContent));
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            subtitleText.gameObject.SetActive(false);
        }
    }*/


    IEnumerator Typing(string txt)
    {
        subtitleText.text = null;

        // ���� �� ���̸� �� �ٲ�
        if (txt.Contains("  "))
            txt = subtitleContent.Replace("  ", "\n");

        for (int i = 0; i < txt.Length; i++)
        {
            subtitleText.text += txt[i];
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        yield return new WaitForSeconds(0.5f);
        subtitleText.gameObject.SetActive(false);
    }
}
