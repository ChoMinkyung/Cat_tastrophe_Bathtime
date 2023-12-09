using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObserver : MonoBehaviour, IObserver, IAttackable
{
    [Header("������")]
    public BattleCatDamageData data;

    private float damage = 5f;
    private bool safeCheck = false;

    private void Awake()
    {
        damage = data.damage;
    }

    public void Notify(ISubject subject)
    {
        var safeSubject = subject as SafeSubject;
        if (safeSubject != null)
        {
            safeCheck = safeSubject.safeCheck;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && safeCheck == false)
        {
            Debug.Log("�ĵ� ����");
            GetDamage();
        }
    }

    public float GetDamage()
    {
        return damage;
    }
}
