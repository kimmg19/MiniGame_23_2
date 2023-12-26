using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    float gridValue;    //�÷��̾� �̵� ��ġ ��.
    [SerializeField]
    float maxPos=3.6f;       //�÷��̾� �̵� ���� ����.

    void Start() {
        transform.position = Vector3.zero;                        //�÷��̾� �ʱ� ��ġ ����        
#if UNITY_EDITOR
        gridValue = UnityEditor.EditorSnapSettings.move.x;        //�÷��̾� �׸��� ��ġ��ŭ �̵�.
#endif
    }

    void Update() {
        Mover();
    }

    void Mover() {              //�÷��̾� ������
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
        //�÷��̾� �̵� ����-�׸��� ��ġ��ŭ, ���� 9*9������
        Vector3 newPosition = transform.position + moveDirection;
        newPosition.x = Mathf.Clamp(newPosition.x, -maxPos, maxPos);
        newPosition.y = Mathf.Clamp(newPosition.y, -maxPos, maxPos);
        transform.position = newPosition;
    }

    void OnTriggerEnter2D(Collider2D collision) {       //�浹 ����
        if (collision.CompareTag("Bomb")) {
            print("���� ����");
            print("Game Over");
            SceneManager.LoadScene(0);
        } else if (collision.CompareTag("Disruptor")) {
            print("���ز�");
            print("Game Over");
            SceneManager.LoadScene(0);
        } else if (collision.CompareTag("Item")) {
            print("������ ���");
        } else if (collision.CompareTag("Obstacle"))
        {
            print("��ֹ��� �浹");
            print("Game Over");
            SceneManager.LoadScene(0);
        }

    }
}
