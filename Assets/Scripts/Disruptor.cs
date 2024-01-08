using UnityEngine;

public class Disruptor : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveRange = 2f;
    private Vector2[] moveDirections = { Vector2.up, Vector2.down };
    private Vector2 currentTarget;
    [SerializeField]
    private bool moveUp = true;

    // 프리팹 배열 선언
    public GameObject[] disruptorPrefabs;

    void Start()
    {
        SetNewTarget();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);

        if ((Vector2)transform.position == currentTarget)
        {
            SetNewTarget();
        }
    }

    void SetNewTarget()
    {
        if (moveUp)
            SetNewTargetUp();
        else
            SetNewTargetDown();
    }

    void SetNewTargetUp()
    {
        // 프리팹을 선택하여 인스턴스화
        GameObject prefabInstance = Instantiate(disruptorPrefabs[0], transform.position, Quaternion.identity);
        currentTarget = (Vector2)transform.position + Vector2.up * moveRange;
        moveUp = false;
    }

    void SetNewTargetDown()
    {
        // 프리팹을 선택하여 인스턴스화
        GameObject prefabInstance = Instantiate(disruptorPrefabs[1], transform.position, Quaternion.identity);
        currentTarget = (Vector2)transform.position + Vector2.down * moveRange;
        moveUp = true;
    }

    // 플레이어와 부딪쳤을 때 호출되는 메서드
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().OnPlayerCollision(GetComponent<Collider2D>());
        }
    }
}
