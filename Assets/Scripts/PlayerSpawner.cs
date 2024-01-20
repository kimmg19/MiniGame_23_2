using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
    public GameObject playerPrefab;  
    GameObject startPanel;
    float gridValue;
    public bool playerSpawned = false; // 플레이어가 생성되었는지 나타내는 변수

    void Start() {
        startPanel = GameObject.Find("StartPanel");   
#if UNITY_EDITOR
        gridValue = UnityEditor.EditorSnapSettings.move.x;
#endif
    }

    void Update() {

        if (!playerSpawned) {
            startPanel.gameObject.SetActive(true);     //팩맨의 위치를 지정해주세요
            if (Input.GetMouseButtonDown(0))
                StartGame();
        }
    }

    void StartGame() {
        // 마우스 클릭 위치를 가져옴
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 그리드에 딱 맞게 위치 조정
        float newX = Mathf.Round(mousePosition.x / gridValue) * gridValue;
        float newY = Mathf.Round(mousePosition.y / gridValue) * gridValue;
        Vector3 roundedPosition = new Vector3(newX, newY, 0f);

        // 플레이어를 마우스 클릭 위치에 생성
        Instantiate(playerPrefab, roundedPosition, Quaternion.identity);

        playerSpawned = true; // 플레이어 생성
        startPanel.gameObject.SetActive(false);
        FindObjectOfType<Timer>().StartTimer();

    }
}
