using System.Collections;
using UnityEngine;

public class InvincibilityItem : MonoBehaviour {
    public float invincibilityDuration = 3f;    //3�� ���� ����ȿ��
    private bool isInvincible = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            ApplyInvincibility(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void ApplyInvincibility(GameObject player) {
        if (!isInvincible) {
            isInvincible = true;
            StartCoroutine(DisableInvincibilityAfterDelay(player));
        }
    }

    private IEnumerator DisableInvincibilityAfterDelay(GameObject player) {
        

        yield return new WaitForSeconds(invincibilityDuration);
        

        isInvincible = false;

        Debug.Log("���� ȿ�� ����");

    }
}
