using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

//점 충돌 관리
public class Dot : MonoBehaviour {
    public float radius;       //탐지할 범위
    public LayerMask mask_Bomb;     //탐지할 layer-Bomb
    public LayerMask mask_Dot;     //탐지할 layer-Bomb
    public TextMeshPro text;

    void Start() {
        ShowBombs();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        ShowTile();
        ShowDots();
    }

    void ShowBombs() {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, radius, mask_Bomb);   //레이어를 통해 주변 지뢰 파악
        if (colls.Length == 0) {
            text.text = string.Empty;
        } else {
            text.text = colls.Length.ToString();
        }
    }

    void ShowTile() {
        text.gameObject.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    //주변 점 지뢰 0개면 없애기.
    void ShowDots() {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, radius, mask_Dot);  //레이러를 통해 주변 Dot 파악
        for (int i = 0; i < colls.Length; i++) {
            if (colls[i].transform.GetChild(0).GetComponent<TextMeshPro>().text == string.Empty) {
                colls[i].GetComponent<Dot>().ShowTile();
                colls[i].GetComponent<Dot>().ShowDots();
            }
        }
    }
}
