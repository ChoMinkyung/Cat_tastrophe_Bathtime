using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour
{
    private RectTransform crossHair;

    public float restingSize = 315; // �������� ���� ���� ũ��
    public float aimSize = 240;  // ���� �� ũ��
    public float speed;
    private float currentSize;

    private void Start()
    {
        crossHair = GetComponent<RectTransform>();

        crossHair.sizeDelta = new Vector2(restingSize, restingSize);
    }

    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            currentSize = Mathf.Lerp(currentSize, aimSize, Time.deltaTime * speed);
        }
        else
        {
            currentSize = Mathf.Lerp(currentSize, restingSize, Time.deltaTime * speed);
        }
        crossHair.sizeDelta = new Vector2(currentSize, currentSize);
    }
}

