using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

//점 충돌 관리
public class Dot : MonoBehaviour {
    float radius_Dot=0.6f;       //탐지할 점 범위
    float radius_Mine = 1.6f;
    public LayerMask mask_Dot;     //탐지할 layer-Dot
    public TextMeshPro text;

    void Start() {
        NumOfMines();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        ShowTile();
        ShowDots();
    }

    //주변 지뢰 개수
    void NumOfMines() {
        Collider2D[] colls = Physics2D.OverlapBoxAll(transform.position, new Vector2(radius_Mine, radius_Mine), 0);
        List<Collider2D> list = new List<Collider2D>();
        foreach (Collider2D coll in colls) {
            if (coll.CompareTag("Mine")) {
                list.Add(coll);
            }
        }
        if (list.Count == 0) {
            text.text = string.Empty;
        } else {
            text.text = list.Count.ToString();
           
        }
    }

    //점 없애고 숫자타일 보이기
    void ShowTile() {
        text.gameObject.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    //주변 점 지뢰 0개면 점 없애기.
    void ShowDots() {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, radius_Dot, mask_Dot);  //레이러를 통해 주변 Dot 파악
        for (int i = 0; i < colls.Length; i++) {
            if (colls[i].transform.GetChild(0).GetComponent<TextMeshPro>().text == string.Empty) {
                colls[i].GetComponent<Dot>().ShowTile();
                colls[i].GetComponent<Dot>().ShowDots();
            }
        }
    }

    //void OnDrawGizmos() {
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(transform.position, 0.6f);
    //}
}
