using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CleanlinessPopUpObserver : MonoBehaviour, IObserver
{
    // �˾� â
    public GameObject popUp;

    // �˾� â �ؽ�Ʈ
    public TextMeshProUGUI upperBody;
    public TextMeshProUGUI lowerBody;
    public TextMeshProUGUI rearPawRight;
    public TextMeshProUGUI rearPawLeft;
    public TextMeshProUGUI forePawRight;
    public TextMeshProUGUI forePawLeft;
    public TextMeshProUGUI back;

    // ĵ���� 
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
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            popUp.SetActive(false);
        }
        
    }

    public void CleanCat(CatStatsSubject subject)
    {
        upperBody.text = "��ü : " + subject.GetPartsCleanliness(PartsEnums.UPPERBODY).ToString("00") + "%";
        lowerBody.text = "��ü : " + subject.GetPartsCleanliness(PartsEnums.LOWERBODY).ToString("00") + "%";
        rearPawRight.text = "�չ� : " + subject.GetPartsCleanliness(PartsEnums.REARPAWRIGHT).ToString("00") + "%";
        rearPawLeft.text = "�չ� : " + subject.GetPartsCleanliness(PartsEnums.REARPAWLEFT).ToString("00") + "%";
        forePawRight.text = "�޹� : " + subject.GetPartsCleanliness(PartsEnums.FOREPAWRIGHT).ToString("00") + "%";
        forePawLeft.text = "�޹� : " + subject.GetPartsCleanliness(PartsEnums.FOREPAWRIGHT).ToString("00") + "%";
        back.text = "�� : " + subject.GetPartsCleanliness(PartsEnums.BACK).ToString("00") + "%";
    }
}
