using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

//한번 순간 이동 후 seconds 만큼 기다려야 다시 작동
public class Portal : MonoBehaviour {
    [SerializeField]
    GameObject[] toObj;     //순간이동할 위치
    float seconds = 3f;


    private void OnTriggerEnter2D(Collider2D collision) {        //순간이동
        if (collision.CompareTag("Player")) {
            if (collision.transform.position == toObj[0].transform.position) {
                collision.transform.position = toObj[1].transform.position;
            } else {
                collision.transform.position = toObj[0].transform.position;

            }
            //콜라이더 비활성화
            toObj[0].GetComponent<Collider2D>().enabled = false;
            toObj[1].GetComponent<Collider2D>().enabled = false;
            toObj[0].GetComponent<SpriteRenderer>().color = Color.black;
            toObj[1].GetComponent<SpriteRenderer>().color = Color.black;

            print("쿨타임");
            Invoke("Enabled", seconds);
        }
    }
    private void Enabled() {
        //콜라이더 활성화
        toObj[0].GetComponent<Collider2D>().enabled = true;
        toObj[1].GetComponent<Collider2D>().enabled = true;
        toObj[0].GetComponent<SpriteRenderer>().color = Color.white;
        toObj[1].GetComponent<SpriteRenderer>().color = Color.white;
        print("쿨타임 종료");

    }

}


