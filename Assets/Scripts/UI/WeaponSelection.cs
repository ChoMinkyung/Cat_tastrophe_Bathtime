using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    public GameObject weaponPopUP; // ���� ����â �˾�
    private bool isActive = false;

    public delegate void SelectWeapons(string message);
    public static SelectWeapons onSelected = null;

    public string[] weaponList; // ���� ���

    void Start()
    {
        weaponPopUP.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)) // ���콺 �� ��ư ����â Ȱ��ȭ
        {
            isActive = !isActive;
            weaponPopUP.SetActive(isActive);
        }
    }

    private void SelectWeapon(string weaponName)
    {
        Debug.Log(weaponName + " ���� ");
    }
}

