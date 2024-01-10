using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float gridValue;
    float maxPos;

    private bool isInvincible = false;
    public float invincibilityDuration = 3f;

    void Start()
    {
#if UNITY_EDITOR
        gridValue = UnityEditor.EditorSnapSettings.move.x;
#endif
        maxPos = gridValue * 4f;
    }

    void Update()
    {
        Mover();
    }

    void Mover()
    {
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveDirection += Vector3.left * gridValue;
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveDirection += Vector3.right * gridValue;
            transform.localEulerAngles = new Vector3(0, 0, 180);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveDirection += Vector3.down * gridValue;
            transform.localEulerAngles = new Vector3(0, 0, 90);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveDirection += Vector3.up * gridValue;
            transform.localEulerAngles = new Vector3(0, 0, -90);
        }

        Vector3 newPosition = transform.position + moveDirection;
        newPosition.x = Mathf.Clamp(newPosition.x, -maxPos, maxPos);
        newPosition.y = Mathf.Clamp(newPosition.y, -maxPos, maxPos);
        transform.position = newPosition;
    }

    void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Mine"))
    {
        if (isInvincible)
        {
            Debug.Log("무적 상태로 지뢰에 부딪히지 않음");
        }
        else
        {
            Debug.Log("지뢰에 부딪혔음");
            Debug.Log("Game Over");
            SceneManager.LoadScene(0);
        }
    }
    else if (collision.CompareTag("InvincibilityItem"))
    {
        Debug.Log("아이템 사용");
        if (isInvincible)
        {
            Debug.Log("이미 무적 상태입니다.");
        }
        else
        {
            StartCoroutine(ActivateInvincibility());
        }
    }
}


    private IEnumerator ActivateInvincibility()
    {
        isInvincible = true;
        Debug.Log("무적 상태로 전환");

        // 플레이어 색상을 초록색으로 변경
        GetComponent<SpriteRenderer>().color = Color.green;

        // 무적 상태일 때 처리코드

        yield return new WaitForSeconds(invincibilityDuration);

        isInvincible = false;
        Debug.Log("무적 상태 해제");

        // 플레이어 색상을 다시 흰색으로 변경
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void OnPlayerCollision(Collider2D disruptorCollider)
    {
        if (isInvincible)
        {
            Debug.Log("무적 상태로 부딪히지 않음");
        }
        else
        {
            Debug.Log("방해꾼 부딪혔음");
            SceneManager.LoadScene(0);
            // 부딪쳤을때 처리코드
        }
    }
}
