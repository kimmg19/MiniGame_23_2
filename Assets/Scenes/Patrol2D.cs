using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disruptor : MonoBehaviour
{
    public float patrolSpeed = 2f; // ���ز� �̵� �ӵ�
    public float patrolTime = 1f; // �� ��ġ���� �ӹ��� �ð�

    private Vector2[] patrolPoints; // �������� ������ ��ȸ ����
    private int currentPatrolIndex = 0; // ���� ��ȸ ���� ������ �ε���
    private float patrolTimer = 0f; // �ӹ��� �ð� ������ Ÿ�̸�

    void Start()
    {
        // �� ���� ������ ��ġ�� ��ȸ ���� 4�� ����
        GeneratePatrolPoints();

        // �ʱ� ��ġ ����
        transform.position = patrolPoints[0];
    }

    void Update()
    {
        // ��ȸ ���� ���
        if (patrolPoints.Length > 1)
        {
            // ���� ��ȸ �������� �̵�
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPatrolIndex], patrolSpeed * Time.deltaTime);

            // ���� ��ȸ ������ �������� ��
            if (Vector2.Distance(transform.position, patrolPoints[currentPatrolIndex]) < 0.1f)
            {
                // �ӹ��� �ð� ���� ����
                patrolTimer += Time.deltaTime;

                // �ӹ��� �ð��� ������ ���� ��ȸ �������� �̵�
                if (patrolTimer >= patrolTime)
                {
                    patrolTimer = 0f;
                    currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
                }
            }
        }
    }

    void GeneratePatrolPoints()
    {
        // �� ���� ������ ��ġ�� ��ȸ ���� 4�� ����
        patrolPoints = new Vector2[4];
        for (int i = 0; i < 4; i++)
        {
            float x = Random.Range(0f, 9f); // ���� ���� ����
            float y = Random.Range(0f, 9f); // ���� ���� ����
            patrolPoints[i] = new Vector2(x, y);
        }
    }

    /*
     * void OnTriggerEnter2D(Collider2D other)
    {
        // �Ѹǰ� �浹�ϸ� ���� ����
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over");
        }
    }
    */
}
}
