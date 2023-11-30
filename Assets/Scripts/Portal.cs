using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;


public class Portal : MonoBehaviour {
    [SerializeField]
    GameObject toObj;   //�����̵��� ��ġ
    

    IEnumerator OnTriggerEnter2D(Collider2D collision) {        //�����̵�
        yield return new WaitForSeconds(2f);
            if (collision.CompareTag("Player")) {
                collision.transform.position = toObj.transform.position;
            
        }
    }
}

