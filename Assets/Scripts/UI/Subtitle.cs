using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*
 ����

A �ߵ����� ��ũ��Ʈ (���̷��� óġ)
B ����Ÿ��Ʋ
C �� ���� ��ũ��Ʈ (�� ����)

A ���ǿϷ� > ����
A ���ԵǾ��ִ� �̺�Ʈ ����
�̺�Ʈ > �Լ�(B ����Ÿ��Ʋ �ڸ� ���� �Լ�)
 
void ClearVirus()
{
    StartCoroutine(subtitle.Typing("���̷��� ��� óġ�ߴ� !"))
}

void SceneStart()
{
    StartCoroutine(subtitle.Typing("�� ���� !"))
}

 */
public class Subtitle : MonoBehaviour
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
            if (!subtitleText.gameObject.activeSelf)
            {
                hasShow = true;
                subtitleText.gameObject.SetActive(true);
                StartCoroutine(Typing(subtitleContent, typingSpeed));
            }
        }
    }

    IEnumerator Typing(string txt, float speed = 0.1f, float delayTime = 0)
    {
        subtitleText.text = null;


        // ���� �� ���̸� �� �ٲ�
        if (txt.Contains("  "))
            txt = txt.Replace("  ", "\n");
        
        yield return new WaitForSeconds(delayTime);

        for (int i = 0; i < txt.Length; i++)
        {
            subtitleText.text += txt[i];
            yield return new WaitForSeconds(speed);
        }

        yield return new WaitForSeconds(1f);
        subtitleText.gameObject.SetActive(false);
    }

    public void ShowSubtitle(string content, float speed = 0.1f, float delayTime = 0)
    {
        if (!subtitleText.gameObject.activeSelf)
        {
            hasShow = true;
            subtitleText.gameObject.SetActive(true);
            StartCoroutine(Typing(content, speed, delayTime));
        }
    }
}
