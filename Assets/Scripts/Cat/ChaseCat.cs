using UnityEngine;
using UnityEngine.AI;

public class ChaseCat : MonoBehaviour
{
    public Animator animator;
    private string targetTag = "ChaseRoad";
    public float jumpHeightThreshold = 0.5f; // Y �� ������ �Ӱ谪

    private Transform[] targets;
    private NavMeshAgent agent;
    private int currentTargetIndex = 0;
    private bool allTargetsReached = false;

    void Start()
    {
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);
        targets = new Transform[targetObjects.Length];

        for (int i = 0; i < targetObjects.Length; i++)
        {
            targets[i] = targetObjects[i].transform;
        }

        agent = GetComponentInParent<NavMeshAgent>();
        animator = GetComponentInParent<Animator>();

        if (targets.Length > 0)
        {
            SetNextDestination();
        }
    }

    void Update()
    {
        if (agent.remainingDistance < 0.5f && !allTargetsReached)
        {
            SetNextDestination();
        }

        if (allTargetsReached)
        {
            Debug.Log("��� ��ǥ ������ �����߽��ϴ�!");
        }
    }

    void SetNextDestination()
    {
        if (currentTargetIndex < targets.Length)
        {
            if (agent.destination != targets[currentTargetIndex].position)
            {
                agent.SetDestination(targets[currentTargetIndex].position);
                currentTargetIndex++;

                if (currentTargetIndex < targets.Length)
                {
                    // ������ ���� Y �� ���� ���
                    float yDifference = Mathf.Abs(transform.position.y - targets[currentTargetIndex].position.y);

                    // Y �� ���̰� Ư�� ���� �̻��̸� ����
                    if (yDifference > jumpHeightThreshold)
                    {
                        Jump();
                    }

                }
                else
                {
                    currentTargetIndex++;
                    SetNextDestination();
                }
            }
            else
            {
                allTargetsReached = true;
            }
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            // üũ: currentTargetIndex�� �迭�� ���� ���� �ִ��� Ȯ��
            if (currentTargetIndex < targets.Length)
            {
                // ������ ���� Y �� ���� ���
                float yDifference = Mathf.Abs(transform.position.y - targets[currentTargetIndex].position.y);

                // Y �� ���̰� Ư�� ���� �̻��̸� ����
                if (yDifference > jumpHeightThreshold)
                {
                    Jump();
                }

                // ���Ŀ� currentTargetIndex ����
                currentTargetIndex++;
            }
            else
            {
                // ��� ��ǥ ���� �ÿ� ó���� ���� �߰�
                allTargetsReached = true;
            }
        }
    }*/

    void Jump()
    {
        animator.SetTrigger("jump");
    }
}
