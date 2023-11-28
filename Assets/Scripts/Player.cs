using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private void Start() {
        transform.position = Vector3.zero;
    }
    void Update() {
        Mover();
    }

    private void Mover() {              //플레이어 움직임
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.A)) {
            moveDirection += Vector3.left;
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            moveDirection += Vector3.right;
            transform.localEulerAngles = new Vector3(0, 0, 180);

        }
        if (Input.GetKeyDown(KeyCode.S)) {
            moveDirection += Vector3.down;
            transform.localEulerAngles = new Vector3(0, 0, 90);

        }
        if (Input.GetKeyDown(KeyCode.W)) {
            moveDirection += Vector3.up;
            transform.localEulerAngles = new Vector3(0,0,-90);

        }
        transform.position=transform.position + moveDirection;
    }

    private void OnTriggerEnter2D(Collider2D collision) {       //충돌 관리
        if (collision.CompareTag("Bomb")) {
            print("지뢰 밟음");
            print("Game Over");
            SceneManager.LoadScene(0);
        } else if (collision.CompareTag("Disruptor")) {
            print("방해꾼");
            print("Game Over");
            SceneManager.LoadScene(0);

        } else if (collision.CompareTag("Item")) {
            print("아이템 사용");
        }
    }
}
