using System;
using UnityEngine;

//점 클릭 이벤트 관리
public class DotController : MonoBehaviour {

    void Update() {
        // 마우스 우클릭 감지
        if (Input.GetMouseButtonDown(1)) {

            ToggleRedDot(); // 우클릭 시 빨간 점 토글
        }
    }

    void ToggleRedDot() {

        //마우스 클릭한 좌표값 가져오기
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //해당 좌표에 있는 오브젝트 찾기
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
        if (hit.collider != null) {
            GameObject click_obj = hit.transform.gameObject;
            SpriteRenderer spriteRenderer = click_obj.GetComponent<SpriteRenderer>();

            //점 클릭 시 색 변경
            if (click_obj.tag == "Dot") {
                if (spriteRenderer.color == Color.white) {
                    spriteRenderer.color = Color.red;
                    
                } else
                    spriteRenderer.color = Color.white;
            }

        }


    }
}
