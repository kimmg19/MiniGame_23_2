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

    // �÷��̾�� �ε����� �� ȣ��Ǵ� �޼���
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // �ε��� ��쿡�� �÷��̾� ��ũ��Ʈ���� ������ OnPlayerCollision �޼��带 ȣ��
            collision.gameObject.GetComponent<Player>().OnPlayerCollision(GetComponent<Collider2D>());
        }
    }
}
