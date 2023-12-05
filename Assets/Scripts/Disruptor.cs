using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disruptor : MonoBehaviour
{
    public float moveSpeed = 2f; // �̵� �ӵ�
    private Vector2[] moveDirections = { Vector2.up, Vector2.down }; // ���� �̵� ����
    private Vector2 currentTarget; // ���� ��ǥ ��ġ
    [SerializeField]
    Vector2 startPos; // ���� ��ġ
    private bool moveUp = true; // ����� ���� �̵� ������ ����

    void Start()
    {
        // �ʱ� ��ġ ����
        transform.position = startPos;
        SetNewTarget();
    }

    void Update()
    {
        // ��ǥ ��ġ�� �̵�
        transform.position = Vector2.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);

        // ��ǥ ��ġ�� �������� �� ���ο� ��ǥ ��ġ ����
        if ((Vector2)transform.position == currentTarget)
        {
            if (moveUp)
                SetNewTargetUp();
            else
                SetNewTargetDown();
        }
    }

    void SetNewTargetUp()
    {
        currentTarget = (Vector2)transform.position + Vector2.up;
        moveUp = false;
    }

    void SetNewTargetDown()
    {
        currentTarget = (Vector2)transform.position + Vector2.down;
        moveUp = true;
    }

    void SetNewTarget()
    {
        if (moveUp)
            SetNewTargetUp();
        else
            SetNewTargetDown();
    }
}
