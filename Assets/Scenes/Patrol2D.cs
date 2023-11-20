using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disruptor : MonoBehaviour
{
    public float patrolSpeed = 2f; // 방해꾼 이동 속도
    public float patrolTime = 1f; // 각 위치에서 머무는 시간

    private Vector2[] patrolPoints; // 랜덤으로 생성된 순회 지점
    private int currentPatrolIndex = 0; // 현재 순회 중인 지점의 인덱스
    private float patrolTimer = 0f; // 머무는 시간 측정용 타이머

    void Start()
    {
        // 맵 내의 랜덤한 위치에 순회 지점 4개 생성
        GeneratePatrolPoints();

        // 초기 위치 설정
        transform.position = patrolPoints[0];
    }

    void Update()
    {
        // 순회 중인 경우
        if (patrolPoints.Length > 1)
        {
            // 현재 순회 지점으로 이동
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPatrolIndex], patrolSpeed * Time.deltaTime);

            // 현재 순회 지점에 도착했을 때
            if (Vector2.Distance(transform.position, patrolPoints[currentPatrolIndex]) < 0.1f)
            {
                // 머무는 시간 측정 시작
                patrolTimer += Time.deltaTime;

                // 머무는 시간이 지나면 다음 순회 지점으로 이동
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
        // 맵 내의 랜덤한 위치에 순회 지점 4개 생성
        patrolPoints = new Vector2[4];
        for (int i = 0; i < 4; i++)
        {
            float x = Random.Range(0f, 9f); // 맵의 가로 범위
            float y = Random.Range(0f, 9f); // 맵의 세로 범위
            patrolPoints[i] = new Vector2(x, y);
        }
    }

    /*
     * void OnTriggerEnter2D(Collider2D other)
    {
        // 팩맨과 충돌하면 게임 종료
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over");
        }
    }
    */
}
}
