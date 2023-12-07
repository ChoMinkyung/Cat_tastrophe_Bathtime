using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CleanlinessPopUpObserver : MonoBehaviour, IObserver
{
    // �˾� â
    [Header("��ô�� �˾�â")]
    public GameObject popUp;

    // �˾� â �ؽ�Ʈ
    [Header("��ü")]
    public TextMeshProUGUI upperBody;
    [Header("��ü")]
    public TextMeshProUGUI lowerBody;
    [Header("�չ�")]
    public TextMeshProUGUI forePawRight;
    public TextMeshProUGUI forePawLeft;
    [Header("�޹�")]
    public TextMeshProUGUI rearPawRight;
    public TextMeshProUGUI rearPawLeft;
    [Header("��")]
    public TextMeshProUGUI back;

    // ĵ���� 
    [Header("���� UI")]
    public CanvasGroup canvas;

    public void Notify(ISubject subject)
    {
        CleanCat(subject as CatStatsSubject);
    }

    void Start()
    {
        popUp.SetActive(false);
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("Pause") == 1) return;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SoundManager.Instance.PlaySFX("Hover");
            popUp.SetActive(true);
            RemoveUI();
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            popUp.SetActive(false);
            ShowUI();
        }
        
    }

    public void CleanCat(CatStatsSubject subject)
    {
        upperBody.text = "��ü : " + (subject.GetPartsCleanliness(PartsEnums.UPPERBODY) / subject.currentMaxLikeability * 100).ToString("00") + "%";
        lowerBody.text = "��ü : " + (subject.GetPartsCleanliness(PartsEnums.LOWERBODY) / subject.currentMaxLikeability * 100).ToString("00") + "%";
        rearPawRight.text = "�޹� : " + (subject.GetPartsCleanliness(PartsEnums.REARPAWRIGHT) / subject.currentMaxLikeability * 100).ToString("00") + "%";
        rearPawLeft.text = "�޹� : " + (subject.GetPartsCleanliness(PartsEnums.REARPAWLEFT) / subject.currentMaxLikeability * 100).ToString("00") + "%";
        forePawRight.text = "�չ� : " + (subject.GetPartsCleanliness(PartsEnums.FOREPAWRIGHT) / subject.currentMaxLikeability * 100).ToString("00") + "%";
        forePawLeft.text = "�չ� : " + (subject.GetPartsCleanliness(PartsEnums.FOREPAWRIGHT) / subject.currentMaxLikeability * 100).ToString("00") + "%";
        back.text = "�� : " + (subject.GetPartsCleanliness(PartsEnums.BACK) / subject.currentMaxLikeability * 100).ToString("00") + "%";
    }

    public void RemoveUI()
    {
        canvas.alpha = 0;
        canvas.interactable = false;
        canvas.blocksRaycasts = false;
    }

    public void ShowUI()
    {
        canvas.alpha = 1;
        canvas.interactable = true;
        canvas.blocksRaycasts = true;
    }
}
