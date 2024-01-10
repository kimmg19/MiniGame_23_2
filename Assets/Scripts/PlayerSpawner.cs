using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
    public GameObject playerPrefab;
    float gridValue;
    void Start() {
#if UNITY_EDITOR
        gridValue = UnityEditor.EditorSnapSettings.move.x;
        print(gridValue);
#endif
    }

    private bool playerSpawned = false; // �÷��̾ �����Ǿ����� ��Ÿ���� ����


    void Update() {
        if (!playerSpawned && Input.GetMouseButtonDown(0)) {
            // ���콺 Ŭ�� ��ġ�� ������
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // �׸��忡 �� �°� ��ġ ����
            float newX = Mathf.Round(mousePosition.x / gridValue) * gridValue;
            float newY = Mathf.Round(mousePosition.y / gridValue) * gridValue;
            Vector3 roundedPosition = new Vector3(newX, newY, 0f);

            // �÷��̾ ���콺 Ŭ�� ��ġ�� ����
            Instantiate(playerPrefab, roundedPosition, Quaternion.identity);

            playerSpawned = true; // �÷��̾� ����
        }
    }
}
