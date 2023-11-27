using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAttack
{
    public class WaveAttack : MonoBehaviour
    {
        [Header("�ּ� ���� ���� ũ��")]
        public float minAttackSize = 1.5f;

        [Header("�ִ� ���� ���� ũ��")]
        public float maxAttackSize = 3.5f;

        [Header("�ּ� ���� ���� ũ��")]
        public float minSafeSize = 1f;

        [Header("�ִ� ���� ���� ũ��")]
        public float maxSafeSize = 3f;

        [Header("ũ�� ���� �ִ� �ð�")]
        public float maxTimer = 3.5f;

        [Header("���� �ӵ�")]
        public float growthSpeed = 1f;

        private bool safeCheck = false;

        private float safeSize = 1f;
        private float attackSize = 1f;
        private float timer = 0f;    
        
        private void OnEnable()
        {
            SetInitialSize();
        }

        void Update()
        {
            timer += Time.deltaTime;

            IncreaseSize();
        }

        private void SetInitialSize()
        {
            transform.Find("SafeBox").localScale = new Vector3(minSafeSize, transform.Find("SafeBox").localScale.y, minSafeSize);
            transform.Find("HitBox").localScale = new Vector3(minAttackSize, transform.Find("HitBox").localScale.y, minAttackSize);

            safeSize = minSafeSize;
            attackSize = minAttackSize;
            timer = 0f;
        }

        private void IncreaseSize()
        {
            if (timer <= maxTimer)
            {
                safeSize = Mathf.Lerp(safeSize, maxSafeSize, Time.deltaTime * growthSpeed);
                transform.Find("SafeBox").localScale = new Vector3(safeSize, transform.Find("SafeBox").localScale.y, safeSize);

                attackSize = Mathf.Lerp(attackSize, maxAttackSize, Time.deltaTime * growthSpeed);
                transform.Find("HitBox").localScale = new Vector3(attackSize, transform.Find("HitBox").localScale.y, attackSize);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}