using UnityEngine;

public class RedDot : MonoBehaviour
{
    private GameObject redDot; // ���� ���� �ν��Ͻ� ����

    void Update()
    {
        // ���콺 ��Ŭ�� ����
        if (Input.GetMouseButtonDown(1))
        {
            ToggleRedDot(); // ��Ŭ�� �� ���� �� ���
        }
    }

    void ToggleRedDot()
    {
        // raycast�� ��� ã��
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // ����� ��ǥ�� �����ͼ� ���� ���� ���� �Ǵ� ����
            Vector3 blockPosition = hit.transform.position;

            if (redDot != null)
            {
                RemoveRedDot();
            }
            else
            {
                CreateRedDot(blockPosition);
            }
        }
    }

    void CreateRedDot(Vector3 position)
    {
        // ���� �� ����
        redDot = Instantiate(Resources.Load<GameObject>("RedDotPrefab"), position, Quaternion.identity);
        redDot.name = "RedDot";

        // ������ ��Ͽ� Collider �߰�
        BoxCollider collider = redDot.AddComponent<BoxCollider>();
        collider.isTrigger = true; 
    }

    void RemoveRedDot()
    {
        // ���� �� ����
        if (redDot != null)
        {
            // ���ŵ� ����� Collider ����
            Destroy(redDot.GetComponent<BoxCollider>());
            Destroy(redDot);
            redDot = null;
        }
    }
}
