using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    // Ǯ�� ���� �����͸� ��� �ִ� Ŭ����
    public class Pool 
    {
        public string tag;          // Ǯ�� ���� ���� �±�
        public GameObject prefab;   // Ǯ���� ���� ������Ʈ
        public int poolSize;        // Ǯ�� ������ ������Ʈ ��
    }

    public List<Pool> poolList;                                    // Ǯ�� ����ϴ� ����Ʈ
    private Dictionary<string, Queue<GameObject>> poolDictionary;  // �������� ������Ʈ Ǯ ����

    public GameObject objectPool; // �ش� Ǯ�� �θ� �� ������Ʈ (��� Ǯ�� ���� �θ� ����)

    private void Awake() // Ǯ�� ��� ��ųʸ� �ʱ�ȭ
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>(); // key, value
    }


    // ���ο� Ǯ ����
    public void CreatePool(string _tag, GameObject _prefab, int _size)
    {
        if(poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning(tag + "�� �̹� ����.");
            return;
        }

        Pool newPool = new Pool { tag = _tag, prefab = _prefab, poolSize = _size };
        poolList.Add(newPool);

        GetFromPool(new List<Pool> { newPool });
    }

    // Ǯ ����Ʈ�� Ǯ ����
    private void GetFromPool(List<Pool> pools) 
    {
        if (poolList.Count == 0) return;

        GameObject poolParent = new GameObject(poolList[0].tag);
        poolParent.transform.SetParent(objectPool.transform);

        // �� Ǯ�� ���� ������Ʈ ����
        foreach(Pool pool in pools)
        {
            Queue<GameObject> objPool = new Queue<GameObject>();

            for(int i = 0; i < pool.poolSize; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                obj.transform.SetParent(poolParent.transform, false);
                obj.name = pool.tag;
                objPool.Enqueue(obj); // ������ ������Ʈ�� �ش� Ǯ�� ť�� �߰�
            }

            // Ǯ ��ųʸ��� ���
            poolDictionary.Add(pool.tag, objPool);
        }

    }

    // Ǯ���� ������Ʈ�� ã�� ��ġ�� ȸ���� �����ϰ� Ȱ��ȭ�� �� ��ȯ 
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning(tag + "�̷� Ǯ ����");
            return null;
        }

        // Ǯ�� ��������� ���ο� ������Ʈ�� ����
        if (poolDictionary[tag].Count <= 0)
        {
            Pool pool = poolList.Find(x => x.tag == tag);
            GameObject newObject = Instantiate(pool.prefab, position, rotation, transform);
            newObject.name = pool.tag;
            return newObject;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);

        return objectToSpawn;
    }

    // ������Ʈ�� Ǯ�� �ٽ� ��ȯ
    public void ReturnToPool(string tag, GameObject obj)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning(tag + "�̷� Ǯ ����");
            return;
        }

        obj.SetActive(false);

        poolDictionary[tag].Enqueue(obj);
    }
}