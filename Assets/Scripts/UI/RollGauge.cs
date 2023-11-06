using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollGauge : MonoBehaviour
{
    public int maxGauge = 3;
    private int currentGauge;
    public Image[] gaugeImageList;


    void Start()
    {
        currentGauge = maxGauge;
    }
    void Update()
    {
        IncreaseGauge();

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            DecreaseGauge();
        }
    }

    private void DecreaseGauge()
    {
        if (currentGauge > 0)
        {
            currentGauge--;
            UpdateImage();
        }
    }

    private void IncreaseGauge()
    {

            StartCoroutine(Delaytime());
    }

    private IEnumerator Delaytime()
    {
        yield return new WaitForSeconds(3);

        if (currentGauge < maxGauge)
        {
            currentGauge++;
            UpdateImage();
        }
    }

    private void UpdateImage()
    {
        // ��� ������ �̹����� ��Ȱ��ȭ
        for (int i = 0; i < gaugeImageList.Length; i++)
        {
            gaugeImageList[i].enabled = false;
        }

        // ���� ������ ���� ���� �ش� ������ �̹��� Ȱ��ȭ
        for (int i = 0; i < currentGauge; i++)
        {
            gaugeImageList[i].enabled = true;
        }
    }
}
