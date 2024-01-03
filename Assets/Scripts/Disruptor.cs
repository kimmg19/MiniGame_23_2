using UnityEngine;

public class Disruptor : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector2[] moveDirections = { Vector2.up, Vector2.down };
    private Vector2 currentTarget;
    [SerializeField]
    private bool moveUp = true;

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
        currentTarget = (Vector2)transform.position + Vector2.up * 2;
        moveUp = false;
    }

    void SetNewTargetDown()
    {
        currentTarget = (Vector2)transform.position + Vector2.down * 2;
        moveUp = true;
    }

    // 플레이어와 부딪쳤을 때 호출되는 메서드
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 부딪힌 경우에는 플레이어 스크립트에서 정의한 OnPlayerCollision 메서드를 호출
            collision.gameObject.GetComponent<Player>().OnPlayerCollision(GetComponent<Collider2D>());
        }
    }
}
