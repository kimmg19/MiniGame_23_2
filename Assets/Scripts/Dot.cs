using UnityEngine;

//�� �浹 ����
public class Dot : MonoBehaviour
{
    
    public GameObject tileObj;
    public float radius_Dot;       //Ž���� ���� ����
    public LayerMask mask;
    void OnTriggerEnter2D(Collider2D collision) {
        tileObj.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        ShowDots();

    }
    //�ֺ� �� ���� 0���� ���ֱ�.
    void ShowDots() {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, radius_Dot, mask);
    }
}
