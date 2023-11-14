using UnityEngine;
using UnityEngine.AI;

public class ChaseCat : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;

    private string targetTag = "ChaseRoad";

    private Transform[] targets;
    private int currentTargetIndex = 0;
    private NavMeshAgent agent;
    private bool allTargetsReached = false;

    void Start()
    {
        // ChaseRoad �±׷� �� ��� �������� ã�� �迭�� �Ҵ�
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);
        targets = new Transform[targetObjects.Length];

        for (int i = 0; i < targetObjects.Length; i++)
        {
            targets[i] = targetObjects[i].transform;
        }

        agent = transform.parent.GetComponent<NavMeshAgent>();

        if (targets.Length > 0)
        {
            SetNextDestination();
        }
        else
        {
            Debug.LogError("No targets with tag '" + targetTag + "' found!");
        }
    }

    void Update()
    {
        // �������� �����ϸ� ���� �������� �̵�
        if (agent.remainingDistance < 0.5f && !allTargetsReached)
        {
            SetNextDestination();
        }

        // ��� �������� �� �������� ���� ����
        if (allTargetsReached)
        {
            Debug.Log("All targets reached!");
            // ���⿡ �߰����� ������ �߰��� �� �ֽ��ϴ�.
        }
    }

    void SetNextDestination()
    {
        // ���� �������� �迭���� �����ϰ� NavMeshAgent�� ����
        if (currentTargetIndex < targets.Length)
        {
            agent.SetDestination(targets[currentTargetIndex].position);
            currentTargetIndex++;
        }
        else
        {
            allTargetsReached = true;
        }
    }
}