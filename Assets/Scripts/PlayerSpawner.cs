using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
    public GameObject playerPrefab;
    float gridSize = 0.9f;
    private bool playerSpawned = false; // 플레이어가 생성되었는지 나타내는 변수


    void Update() {
        if (!playerSpawned && Input.GetMouseButtonDown(0)) {
            // 마우스 클릭 위치를 가져옴
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 그리드에 딱 맞게 위치 조정
            float newX = Mathf.Round(mousePosition.x / gridSize) * gridSize;
            float newY = Mathf.Round(mousePosition.y / gridSize) * gridSize;
            Vector3 roundedPosition = new Vector3(newX, newY, 0f);

            // 플레이어를 마우스 클릭 위치에 생성
            Instantiate(playerPrefab, roundedPosition, Quaternion.identity);

            playerSpawned = true; // 플레이어 생성
        }
    }
}
