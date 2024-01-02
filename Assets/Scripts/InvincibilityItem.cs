using UnityEngine;

public class InvincibilityItem : MonoBehaviour
{
    public float invincibilityDuration = 5f; // 무적 효과 지속 시간 우선 5초 설정
    private bool isInvincible = false; // 무적 상태 여부
    private Vector3 initialPosition; // 아이템을 먹은 위치 저장

    void Start()
    {
        initialPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isInvincible)
        {
            // 플레이어와 충돌하면 무적 효과 적용
            ApplyInvincibility();
            // 아이템을 먹은 자리로 이동
            transform.position = initialPosition;
            // 아이템을 비활성화하여 사라지게 함
            gameObject.SetActive(false);
        }

        // disruptor나 지뢰와 충돌하면 아이템 먹은 위치로 이동
        if ((other.CompareTag("Disruptor") || other.CompareTag("Mine")) && isInvincible)
        {
            transform.position = initialPosition;
        }
    }

    void ApplyInvincibility()
    {
        isInvincible = true;

        // 무적 효과를 지정된 시간 후에 종료
        Invoke("EndInvincibility", invincibilityDuration);
    }

    void EndInvincibility()
    {
        isInvincible = false;
    }
}
