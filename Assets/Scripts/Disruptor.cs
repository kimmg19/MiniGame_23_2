using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disruptor : MonoBehaviour
{
    public float moveSpeed = 2f; // 이동 속도
    private Vector2[] moveDirections = { Vector2.up, Vector2.down, Vector2.left, Vector2.right }; // 상하좌우 이동 방향
    private int currentDirectionIndex = 0; // 현재 이동 방향의 인덱스
    private Vector2 currentTarget; // 현재 목표 위치

    void Start()
    {
        // 초기 위치 설정
        transform.position = new Vector2(0, 0);     // 우선 0,0으로 둠
        SetNewTarget();
    }

    void Update()
    {
        // 목표 위치로 이동
        transform.position = Vector2.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);

        // 목표 위치에 도착했을 때 새로운 랜덤 방향과 목표 위치 설정
        if ((Vector2)transform.position == currentTarget)
        {
            SetRandomDirection();
            SetNewTarget();
        }
    }

    void SetRandomDirection()
    {
        // 랜덤한 이동 방향 선택
        currentDirectionIndex = Random.Range(0, moveDirections.Length);

        // 현재 방향이 맵 가장자리로 이동하는지 체크
        CheckEdge();
    }

    void SetNewTarget()
    {
        // 현재 위치에서 상하좌우 중 랜덤 방향으로 이동할 위치 설정
        currentTarget = (Vector2)transform.position + moveDirections[currentDirectionIndex];

        // 현재 방향이 맵 가장자리로 이동하는지 체크
        CheckEdge();
    }

    void CheckEdge()
    {
        // 현재 위치가 맵 가장자리에 도달하면 방향을 반대로 설정
        if (transform.position.x <= -8f || transform.position.x >= 8f || transform.position.y <= -4.5f || transform.position.y >= 4.5f)
        {
            // 현재 방향을 반대로 설정
            currentDirectionIndex = (currentDirectionIndex + 2) % moveDirections.Length;
        }
    }
}
