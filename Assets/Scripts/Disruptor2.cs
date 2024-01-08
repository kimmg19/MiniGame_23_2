using UnityEngine;

public class Disruptor2 : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveRange = 2f;
    private Vector2[] moveDirections = { Vector2.right, Vector2.left }; // 방향을 좌우로 변경
    private Vector2 currentTarget;
    [SerializeField]
    private bool moveRight = true; 

    // 스프라이트 배열 선언
    public Sprite[] disruptorSprites;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (moveRight)
            SetNewTargetRight();
        else
            SetNewTargetLeft();
    }

    void SetNewTargetRight()
    {
        // 우측 방향 이미지 설정
        spriteRenderer.sprite = disruptorSprites[0];
        currentTarget = (Vector2)transform.position + Vector2.right * moveRange;
        moveRight = false;
    }

    void SetNewTargetLeft()
    {
        // 좌측 방향 이미지 설정
        spriteRenderer.sprite = disruptorSprites[1];
        currentTarget = (Vector2)transform.position + Vector2.left * moveRange;
        moveRight = true;
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
