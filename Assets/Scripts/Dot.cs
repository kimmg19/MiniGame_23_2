using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

//점 충돌 관리
public class Dot : MonoBehaviour
{    
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
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, radius, mask_Bomb);       //레이어를 통해 주변 지뢰 탐지.
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
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, radius, mask_Dot);
        foreach (Collider2D coll in colls) {
            if (coll.transform.GetChild(0).GetComponent<TextMeshPro>().text == string.Empty) {
                coll.GetComponent<Dot>().ShowTile();
                coll.GetComponent<Dot>().ShowDots();
            }
        }
    }
}
