using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour {

    TextMeshProUGUI textColor;
    void Start() {
        textColor = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            textColor.color = Color.yellow;
        } else
            textColor.color = Color.white;
    }
}
