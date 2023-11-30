using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;


public class Portal : MonoBehaviour {
    [SerializeField]
    GameObject toObj;   //순간이동할 위치
    

    IEnumerator OnTriggerEnter2D(Collider2D collision) {        //순간이동
        yield return new WaitForSeconds(2f);
            if (collision.CompareTag("Player")) {
                collision.transform.position = toObj.transform.position;
            
        }
    }
}

