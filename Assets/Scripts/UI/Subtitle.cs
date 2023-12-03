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
                StartCoroutine(Typing(subtitleContent));
            }
        }
    }

    IEnumerator Typing(string txt)
    {
        subtitleText.text = null;

        // ���� �� ���̸� �� �ٲ�
        if (txt.Contains("  "))
            txt = txt.Replace("  ", "\n");

        for (int i = 0; i < txt.Length; i++)
        {
            subtitleText.text += txt[i];
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(1f);
        subtitleText.gameObject.SetActive(false);
    }

    public void ShowSubtitle(string content)
    {
        if (!subtitleText.gameObject.activeSelf)
        {
            hasShow = true;
            subtitleText.gameObject.SetActive(true);
            StartCoroutine(Typing(content));
        }
    }
}
