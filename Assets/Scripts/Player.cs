using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    float gridValue;    //플레이어 이동 수치 값.
    [SerializeField]
    float maxPos=3.6f;       //플레이어 이동 제한 변수.

    void Start() {
        transform.position = Vector3.zero;                        //플레이어 초기 위치 설정        
#if UNITY_EDITOR
        gridValue = UnityEditor.EditorSnapSettings.move.x;        //플레이어 그리드 수치만큼 이동.
#endif
    }

    void Update() {
        Mover();
    }

    void Mover() {              //플레이어 움직임
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
        //플레이어 이동 제한-그리드 수치만큼, 현재 9*9에서만
        Vector3 newPosition = transform.position + moveDirection;
        newPosition.x = Mathf.Clamp(newPosition.x, -maxPos, maxPos);
        newPosition.y = Mathf.Clamp(newPosition.y, -maxPos, maxPos);
        transform.position = newPosition;
    }

    void OnTriggerEnter2D(Collider2D collision) {       //충돌 관리
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
        } else if (collision.CompareTag("Obstacle"))
        {
            print("장애물과 충돌");
            print("Game Over");
            SceneManager.LoadScene(0);
        }

    }
}
