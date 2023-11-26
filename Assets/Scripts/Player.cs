using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {
    Portal portal;
    void Start() {
        portal=GetComponent<Portal>();
    }

    void Update() {
        Mover();
    }

    private void Mover() {              //�÷��̾� ������
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.A)) {
            moveDirection += Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            moveDirection += Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            moveDirection += Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            moveDirection += Vector3.up;
        }
        transform.Translate(moveDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision) {       //�浹 ����
        if (collision.gameObject.tag == "Bomb") {
            print("���� ����");
            print("�޴� ȣ��");
            SceneManager.LoadScene(0);
        } else if (collision.gameObject.tag == "Disruptor") {
            print("���ز�");
            print("�޴� ȣ��");
            
        } else if (collision.gameObject.tag == "Portal") {
            print(portal);

        } else if (collision.gameObject.tag == "Item") {
            print("������ ���");

        }
    }


}
