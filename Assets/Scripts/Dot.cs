using UnityEngine;

//점 충돌 관리
public class Dot : MonoBehaviour
{
    
    public GameObject tileObj;
    public float radius_Dot;       //탐지할 점의 범위
    public LayerMask mask;
    void OnTriggerEnter2D(Collider2D collision) {
        tileObj.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        ShowDots();

    }
    //주변 점 지뢰 0개면 없애기.
    void ShowDots() {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, radius_Dot, mask);
    }
}
