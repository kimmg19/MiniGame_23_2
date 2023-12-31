using System;
using UnityEngine;

//�� Ŭ�� �̺�Ʈ ����
public class DotController : MonoBehaviour {

    void Update() {
        // ���콺 ��Ŭ�� ����
        if (Input.GetMouseButtonDown(1)) {

            ToggleRedDot(); // ��Ŭ�� �� ���� �� ���
        }
    }

    void ToggleRedDot() {

        //���콺 Ŭ���� ��ǥ�� ��������
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //�ش� ��ǥ�� �ִ� ������Ʈ ã��
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
        if (hit.collider != null) {
            GameObject click_obj = hit.transform.gameObject;
            SpriteRenderer spriteRenderer = click_obj.GetComponent<SpriteRenderer>();

            //�� Ŭ�� �� �� ����
            if (click_obj.tag == "Dot") {
                if (spriteRenderer.color == Color.white) {
                    spriteRenderer.color = Color.red;
                    
                } else
                    spriteRenderer.color = Color.white;
            }

        }


    }
}
