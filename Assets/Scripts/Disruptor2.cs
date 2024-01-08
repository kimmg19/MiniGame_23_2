using UnityEngine;

public class Disruptor2 : MonoBehaviour {
    public float moveSpeed = 2f;
    public float moveRange = 2f;
    public GameObject[] disruptorPrefabs; // 여러 프리팹을 저장하는 배열
    private Vector2[] moveDirections = { Vector2.left, Vector2.right };
    private Vector2 currentTarget;
    private GameObject currentPrefab; // 현재 사용 중인 프리팹을 저장하는 변수
    [SerializeField]
    private bool moveLeft = true;

    void Start() {
        SetNewTarget();
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);

        if ((Vector2)transform.position == currentTarget) {
            SetNewTarget();
        }
    }

    void SetNewTarget() {
        if (moveLeft)
            SetNewTargetLeft();
        else
            SetNewTargetRight();
    }

    void SetNewTargetLeft() {
        currentTarget = (Vector2)transform.position + Vector2.left * moveRange;
        moveLeft = false;
        ChangePrefab(); // 프리팹 변경
    }

    void SetNewTargetRight() {
        currentTarget = (Vector2)transform.position + Vector2.right * moveRange;
        moveLeft = true;
        ChangePrefab(); // 프리팹 변경
    }

    void ChangePrefab() {
    int prefabIndex = moveLeft ? 0 : 1; // 왼쪽으로 갈 때는 0번 인덱스, 오른쪽으로 갈 때는 1번 인덱스
    currentPrefab = disruptorPrefabs[prefabIndex];

    // 현재 사용 중인 프리팹의 스프라이트 렌더러를 가져옴
    SpriteRenderer spriteRenderer = currentPrefab.GetComponent<SpriteRenderer>();
    
    if (spriteRenderer != null)
    {
        // 현재 프리팹의 스프라이트를 사용 중인 방향에 따라 설정
        spriteRenderer.flipX = moveLeft;
    }
    else
    {
        Debug.LogError("프리팹에 SpriteRenderer 컴포넌트를 찾을 수 없습니다.");
    }
}




    // 플레이어와 부딪쳤을 때 호출되는 메서드
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            // 부딪힌 경우에는 플레이어 스크립트에서 정의한 OnPlayerCollision 메서드를 호출
            collision.gameObject.GetComponent<Player>().OnPlayerCollision(GetComponent<Collider2D>());
        }
    }

    // 현재 사용 중인 프리팹을 반환하는 메서드
    public GameObject GetCurrentPrefab() {
        return currentPrefab;
    }
}
