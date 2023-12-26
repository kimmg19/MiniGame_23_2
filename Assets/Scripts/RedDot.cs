using UnityEngine;

public class RedDot : MonoBehaviour
{
    private bool isObstacle = false; // RedDot 객체가 장애물로 취급되는지 여부

    void Start()
    {
        // 시작 시 RedDot이 나타나지 않은 상태로 초기화
        ToggleObstacleAtMousePosition();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ToggleObstacleAtMousePosition();
        }
    }

    private void ToggleObstacleAtMousePosition()
    {
        isObstacle = !isObstacle;

        if (isObstacle)
        {
            
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // z 축을 0으로 설정하여 2D 평면 상에 위치하도록 함
            transform.position = mousePosition;

            GetComponent<Renderer>().enabled = true;

            // "Obstacle" 레이어의 번호를 8로 설정 (임의의 값, 프로젝트에 맞게 조정 필요)
            gameObject.layer = 8;
        }
        else
        {
          
            GetComponent<Renderer>().enabled = false;
            // 여기에서 장애물 레이어로 설정
            gameObject.layer = LayerMask.NameToLayer("Obstacle");
        }
    }
}
