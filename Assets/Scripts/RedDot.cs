using UnityEngine;

public class RedDot : MonoBehaviour
{
    private bool isObstacle = false; // RedDot ��ü�� ��ֹ��� ��޵Ǵ��� ����

    void Start()
    {
        // ���� �� RedDot�� ��Ÿ���� ���� ���·� �ʱ�ȭ
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
            mousePosition.z = 0f; // z ���� 0���� �����Ͽ� 2D ��� �� ��ġ�ϵ��� ��
            transform.position = mousePosition;

            GetComponent<Renderer>().enabled = true;

            // "Obstacle" ���̾��� ��ȣ�� 8�� ���� (������ ��, ������Ʈ�� �°� ���� �ʿ�)
            gameObject.layer = 8;
        }
        else
        {
          
            GetComponent<Renderer>().enabled = false;
            // ���⿡�� ��ֹ� ���̾�� ����
            gameObject.layer = LayerMask.NameToLayer("Obstacle");
        }
    }
}
