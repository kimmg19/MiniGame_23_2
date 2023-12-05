using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disruptor : MonoBehaviour
{
    public float moveSpeed = 2f; // 이동 속도
    private Vector2[] moveDirections = { Vector2.up, Vector2.down }; // 상하 이동 방향
    private Vector2 currentTarget; // 현재 목표 위치
    [SerializeField]
    Vector2 startPos; // 시작 위치
    private bool moveUp = true; // 현재는 위로 이동 중인지 여부

    void Start()
    {
        // 초기 위치 설정
        transform.position = startPos;
        SetNewTarget();
    }

    void Update()
    {
        // 목표 위치로 이동
        transform.position = Vector2.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);

        // 목표 위치에 도착했을 때 새로운 목표 위치 설정
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
