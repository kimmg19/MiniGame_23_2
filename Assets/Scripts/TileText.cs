using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileText : MonoBehaviour {
    public LayerMask objectLayer;
    TextMeshPro text;
    public float radius_Bomb;        //탐지할 지뢰의 범위

    void Start() {
        text = GetComponentInChildren<TextMeshPro>();     //Tile 오브젝트 밑에 Text 오브젝트 Get       

        ShowBombs();
    }

    void ShowBombs() {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, radius_Bomb, objectLayer);       //레이어를 통해 주변 지뢰 탐지.
        if (colls.Length == 0) {
            text.text = string.Empty;
        } else {
            text.text = colls.Length.ToString();
        }
    }
}
