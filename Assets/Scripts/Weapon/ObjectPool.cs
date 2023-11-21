using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    // Ǯ�� ���� �����͸� ��� �ִ� Ŭ����
    public class Pool 
    {
        public string tag;
        public GameObject prefab; 
        public int poolSize;
    }

    public List<Pool> poolList;                                    // Ǯ�� ����ϴ� ����Ʈ
    private Dictionary<string, Queue<GameObject>> poolDictionary;  // �������� ������Ʈ Ǯ ����

    private void Awake() // Ǯ�� ��� ��ųʸ� �ʱ�ȭ
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
    }


    // ���ο� Ǯ ����
    public void CreatePool()
    {

    }

    // Ǯ 
    public GameObject SpawnFromPool()
    {
        return null;
    }

    // ������Ʈ�� Ǯ�� �ٽ� ��ȯ
    public void ReturnToPool()
    {

    }
}
