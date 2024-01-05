using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
    public GameObject playerPrefab;
    float gridSize = 0.9f;
    private bool playerSpawned = false; // �÷��̾ �����Ǿ����� ��Ÿ���� ����


    void Update() {
        if (!playerSpawned && Input.GetMouseButtonDown(0)) {
            // ���콺 Ŭ�� ��ġ�� ������
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // �׸��忡 �� �°� ��ġ ����
            float newX = Mathf.Round(mousePosition.x / gridSize) * gridSize;
            float newY = Mathf.Round(mousePosition.y / gridSize) * gridSize;
            Vector3 roundedPosition = new Vector3(newX, newY, 0f);

            // �÷��̾ ���콺 Ŭ�� ��ġ�� ����
            Instantiate(playerPrefab, roundedPosition, Quaternion.identity);

            playerSpawned = true; // �÷��̾� ����
        }
    }
}
