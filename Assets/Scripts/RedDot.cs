using UnityEngine;

public class RedDot : MonoBehaviour
{
    private GameObject redDot; // 빨간 점의 인스턴스 참조

    void Update()
    {
        // 마우스 우클릭 감지
        if (Input.GetMouseButtonDown(1))
        {
            ToggleRedDot(); // 우클릭 시 빨간 점 토글
        }
    }

    void ToggleRedDot()
    {
        // raycast로 블록 찾기
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // 블록의 좌표를 가져와서 빨간 점을 생성 또는 제거
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
        // 빨간 점 생성
        redDot = Instantiate(Resources.Load<GameObject>("RedDotPrefab"), position, Quaternion.identity);
        redDot.name = "RedDot";

        // 생성된 블록에 Collider 추가
        BoxCollider collider = redDot.AddComponent<BoxCollider>();
        collider.isTrigger = true; 
    }

    void RemoveRedDot()
    {
        // 빨간 점 제거
        if (redDot != null)
        {
            // 제거된 블록의 Collider 제거
            Destroy(redDot.GetComponent<BoxCollider>());
            Destroy(redDot);
            redDot = null;
        }
    }
}
