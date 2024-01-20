using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
    public GameObject playerPrefab;  
    GameObject startPanel;
    float gridValue;
    public bool playerSpawned = false; // �÷��̾ �����Ǿ����� ��Ÿ���� ����

    void Start() {
        startPanel = GameObject.Find("StartPanel");   
#if UNITY_EDITOR
        gridValue = UnityEditor.EditorSnapSettings.move.x;
#endif
    }

    void Update() {

        if (!playerSpawned) {
            startPanel.gameObject.SetActive(true);     //�Ѹ��� ��ġ�� �������ּ���
            if (Input.GetMouseButtonDown(0))
                StartGame();
        }
    }

    void StartGame() {
        // ���콺 Ŭ�� ��ġ�� ������
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // �׸��忡 �� �°� ��ġ ����
        float newX = Mathf.Round(mousePosition.x / gridValue) * gridValue;
        float newY = Mathf.Round(mousePosition.y / gridValue) * gridValue;
        Vector3 roundedPosition = new Vector3(newX, newY, 0f);

        // �÷��̾ ���콺 Ŭ�� ��ġ�� ����
        Instantiate(playerPrefab, roundedPosition, Quaternion.identity);

        playerSpawned = true; // �÷��̾� ����
        startPanel.gameObject.SetActive(false);
        FindObjectOfType<Timer>().StartTimer();

    }
}
