using UnityEngine;

public class Disruptor : MonoBehaviour
{
    float gridValue;
    public float moveSpeed = 2f;
    public float moveRange = 2f;
    private Vector2[] moveDirections = { Vector2.up, Vector2.down };
    private Vector2 currentTarget;
    [SerializeField]
    private bool moveUp = true;

    // 프리팹 배열 선언 (이미지만 포함하도록 수정)
    public Sprite[] disruptorSprites;
    private SpriteRenderer spriteRenderer;

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        SetNewTarget();
#if UNITY_EDITOR
        gridValue = UnityEditor.EditorSnapSettings.move.x;
#endif
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
        // 위쪽 방향 이미지 설정
        spriteRenderer.sprite = disruptorSprites[0];
        currentTarget = (Vector2)transform.position + Vector2.up * moveRange* gridValue;
        moveUp = false;
    }

    void SetNewTargetDown()
    {
        // 아래쪽 방향 이미지 설정
        spriteRenderer.sprite = disruptorSprites[1];
        currentTarget = (Vector2)transform.position + Vector2.down * moveRange* gridValue;
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
