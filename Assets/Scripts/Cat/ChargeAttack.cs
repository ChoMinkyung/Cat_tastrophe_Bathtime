using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAttack : MonoBehaviour
{
    [Header("���� �� �о�� ����")]
    public float speed = 3f;

    private Rigidbody rigidbody;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rigidbody = other.GetComponentInParent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddForce(Vector3.back * speed, ForceMode.Impulse);
            }
        }
    }
}
