using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileText : MonoBehaviour {
    public LayerMask objectLayer;
    TextMeshPro text;
    public float radius_Bomb;        //Ž���� ������ ����

    void Start() {
        text = GetComponentInChildren<TextMeshPro>();     //Tile ������Ʈ �ؿ� Text ������Ʈ Get       

        ShowBombs();
    }

    void ShowBombs() {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, radius_Bomb, objectLayer);       //���̾ ���� �ֺ� ���� Ž��.
        if (colls.Length == 0) {
            text.text = string.Empty;
        } else {
            text.text = colls.Length.ToString();
        }
    }
}
