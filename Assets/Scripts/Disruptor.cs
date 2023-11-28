using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disruptor : MonoBehaviour
{
    public float moveSpeed = 2f; // �̵� �ӵ�
    private Vector2[] moveDirections = { Vector2.up, Vector2.down, Vector2.left, Vector2.right }; // �����¿� �̵� ����
    private int currentDirectionIndex = 0; // ���� �̵� ������ �ε���
    private Vector2 currentTarget; // ���� ��ǥ ��ġ

    void Start()
    {
        // �ʱ� ��ġ ����
        transform.position = new Vector2(0, 0);     // �켱 0,0���� ��
        SetNewTarget();
    }

    void Update()
    {
        // ��ǥ ��ġ�� �̵�
        transform.position = Vector2.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);

        // ��ǥ ��ġ�� �������� �� ���ο� ���� ����� ��ǥ ��ġ ����
        if ((Vector2)transform.position == currentTarget)
        {
            SetRandomDirection();
            SetNewTarget();
        }
    }

    void SetRandomDirection()
    {
        // ������ �̵� ���� ����
        currentDirectionIndex = Random.Range(0, moveDirections.Length);

        // ���� ������ �� �����ڸ��� �̵��ϴ��� üũ
        CheckEdge();
    }

    void SetNewTarget()
    {
        // ���� ��ġ���� �����¿� �� ���� �������� �̵��� ��ġ ����
        currentTarget = (Vector2)transform.position + moveDirections[currentDirectionIndex];

        // ���� ������ �� �����ڸ��� �̵��ϴ��� üũ
        CheckEdge();
    }

    void CheckEdge()
    {
        // ���� ��ġ�� �� �����ڸ��� �����ϸ� ������ �ݴ�� ����
        if (transform.position.x <= -8f || transform.position.x >= 8f || transform.position.y <= -4.5f || transform.position.y >= 4.5f)
        {
            // ���� ������ �ݴ�� ����
            currentDirectionIndex = (currentDirectionIndex + 2) % moveDirections.Length;
        }
    }
}
