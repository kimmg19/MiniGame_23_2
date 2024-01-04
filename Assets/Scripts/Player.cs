using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    float gridValue;
    [SerializeField] float maxPos = 3.6f;
    [SerializeField] Vector2 playerPos;

    private bool isInvincible = false;
    public float invincibilityDuration = 3f;

    void Start() {
#if UNITY_EDITOR
        gridValue = UnityEditor.EditorSnapSettings.move.x;
#endif
    }

    void Update() {
        Mover();
    }

    void Mover() {
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.A)) {
            moveDirection += Vector3.left * gridValue;
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            moveDirection += Vector3.right * gridValue;
            transform.localEulerAngles = new Vector3(0, 0, 180);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            moveDirection += Vector3.down * gridValue;
            transform.localEulerAngles = new Vector3(0, 0, 90);
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            moveDirection += Vector3.up * gridValue;
            transform.localEulerAngles = new Vector3(0, 0, -90);
        }

        Vector3 newPosition = transform.position + moveDirection;
        newPosition.x = Mathf.Clamp(newPosition.x, -maxPos, maxPos);
        newPosition.y = Mathf.Clamp(newPosition.y, -maxPos, maxPos);
        transform.position = newPosition;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Bomb")) {
            Debug.Log("���� ����");
            Debug.Log("Game Over");
            SceneManager.LoadScene(0);
        } else if (collision.CompareTag("InvincibilityItem")) {
            Debug.Log("������ ���");
            if (isInvincible) {
                Debug.Log("�̹� ���� �����Դϴ�.");
            } else {
                StartCoroutine(ActivateInvincibility());
            }
        }
    }

    private IEnumerator ActivateInvincibility() {
        isInvincible = true;
        Debug.Log("���� ���·� ��ȯ");

        // ���������϶� ó���ڵ�

        yield return new WaitForSeconds(invincibilityDuration);

        isInvincible = false;
        Debug.Log("���� ���� ����");
    }

    public void OnPlayerCollision(Collider2D disruptorCollider) {
        if (isInvincible) {
            Debug.Log("���� ���·� �ε����� ����");
        } else {
            Debug.Log("���ز� �ε�����");
            SceneManager.LoadScene(0);
            // �ε������� ó���ڵ�
        }
    }
}
