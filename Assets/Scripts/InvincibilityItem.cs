using UnityEngine;

public class InvincibilityItem : MonoBehaviour
{
    public float invincibilityDuration = 5f; // ���� ȿ�� ���� �ð� �켱 5�� ����
    private bool isInvincible = false; // ���� ���� ����
    private Vector3 initialPosition; // �������� ���� ��ġ ����

    void Start()
    {
        initialPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isInvincible)
        {
            // �÷��̾�� �浹�ϸ� ���� ȿ�� ����
            ApplyInvincibility();
            // �������� ���� �ڸ��� �̵�
            transform.position = initialPosition;
            // �������� ��Ȱ��ȭ�Ͽ� ������� ��
            gameObject.SetActive(false);
        }

        // disruptor�� ���ڿ� �浹�ϸ� ������ ���� ��ġ�� �̵�
        if ((other.CompareTag("Disruptor") || other.CompareTag("Mine")) && isInvincible)
        {
            transform.position = initialPosition;
        }
    }

    void ApplyInvincibility()
    {
        isInvincible = true;

        // ���� ȿ���� ������ �ð� �Ŀ� ����
        Invoke("EndInvincibility", invincibilityDuration);
    }

    void EndInvincibility()
    {
        isInvincible = false;
    }
}
