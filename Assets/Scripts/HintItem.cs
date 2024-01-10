using UnityEngine;
using System.Collections;

public class HintItem : MonoBehaviour {
    public float itemDuration = 0.25f;
    public LayerMask mineLayer; // 지뢰 레이어
    float gridValue;
    void Start() {
#if UNITY_EDITOR
        gridValue = UnityEditor.EditorSnapSettings.move.x;
#endif
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            UseItem();            
        }
    }

    void UseItem() {
        //주변 5x5 영역의 지뢰를 표시
        StartCoroutine(RevealMines(transform.position));
    }

    IEnumerator RevealMines(Vector3 position) {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(position, new Vector2(5, 5) * gridValue, 0);

        foreach (Collider2D collider in hitColliders) {
            if (collider.CompareTag("Mine")) {
                collider.GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
        }
        yield return new WaitForSeconds(itemDuration); // 0.25초 대기
        foreach (Collider2D collider in hitColliders) {
            if (collider.CompareTag("Mine")) {
                collider.GetComponent<SpriteRenderer>().sortingOrder = 0;
                Destroy(gameObject);
            }
        }
    }
}
