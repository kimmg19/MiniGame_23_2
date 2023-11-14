using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float playerMove = 1f;
    void Update() {
        Mover();
    }

    private void Mover() {
        if (Input.GetKeyDown(KeyCode.A)) {
            transform.Translate(-playerMove, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            transform.Translate(playerMove, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            transform.Translate(0, -playerMove, 0);
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            transform.Translate(0, playerMove, 0);
        }
    }


}
