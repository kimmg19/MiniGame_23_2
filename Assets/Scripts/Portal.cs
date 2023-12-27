using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

//�ѹ� ���� �̵� �� second ��ŭ ��ٷ��� �ٽ� �۵�
public class Portal : MonoBehaviour {
    [SerializeField]
    GameObject[] toObj;     //�����̵��� ��ġ
    float seconds = 3f;      //��Ż �ݶ��̴� 
    

    private void OnTriggerEnter2D(Collider2D collision) {        //�����̵�
        if (collision.CompareTag("Player")) {
            if (collision.transform.position == toObj[0].transform.position) {
                collision.transform.position = toObj[1].transform.position;
            } else {
                collision.transform.position = toObj[0].transform.position;

            }
            //�ݶ��̴� ��Ȱ��ȭ
            toObj[0].GetComponent<Collider2D>().enabled = false;
            toObj[1].GetComponent<Collider2D>().enabled = false;
            Invoke("Enabled", seconds);
        }
    }
    private void Enabled() {
        //�ݶ��̴� Ȱ��ȭ
        toObj[0].GetComponent<Collider2D>().enabled = true;
        toObj[1].GetComponent<Collider2D>().enabled = true;
    }

}


