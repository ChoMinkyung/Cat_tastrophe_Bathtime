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

    private string currentText = "";


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            subtitleText.text = "";
            currentText = subtitleContent;
            StartCoroutine(Typing());
            subtitleText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            subtitleText.gameObject.SetActive(false);
        }
    }


    IEnumerator Typing()
    {
        for(int i = 0; i < subtitleContent.Length; i++)
        {
            subtitleText.text += subtitleContent[i];
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
