using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Portal : MonoBehaviour {
    [SerializeField]
    GameObject targetObj,toObj;
    

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            targetObj = collision.gameObject;
            targetObj.transform.position = toObj.transform.position;
        }
    }
    
}

