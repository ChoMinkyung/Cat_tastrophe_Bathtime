using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    public TextMeshProUGUI endingText;
    public GameObject button;

    public Image topImage;
    public Image bottomImage;
    
    [Header("����� �� �̵��� �� �̸�")]
    public string sceneName;

    private string endingContent = "�׳� ������ ���� ... ?";

    private float progress = 0f;

    private void Start()
    {
        StartCoroutine(Typing());
        button.SetActive(false);
    }

    IEnumerator Typing()
    {
        endingText.text = null;

        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < endingContent.Length; i++)
        {
            endingText.text += endingContent[i];
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.5f);
        endingText.gameObject.SetActive(false);

        while(progress < 1f)
        {
            progress += Time.deltaTime * 1.3f;
            topImage.fillAmount = Mathf.Lerp(1f, 0f, progress);
            bottomImage.fillAmount = Mathf.Lerp(1f, 0f, progress);
            yield return null;
        }

        // �ڸ��� ���� �� ��ư Ȱ��ȭ
        yield return new WaitForSeconds(0.2f);
        button.SetActive(true);
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnClickEnd()
    {
        SceneManager.LoadScene("HanKyeol_Lobby");
    }

}
