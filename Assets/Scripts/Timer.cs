using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    private float min = 0;
    private float sec = 0;
    private bool isTimerActive = false; // 타이머 활성화 여부   

    void Update() {
        if(isTimerActive)
            sec += Time.deltaTime;
            if (sec >= 60f) {
                min += 1;
                sec = 0;
            }

            text.text = string.Format("{0:D2}:{1:D2}", (int)min, (int)sec);
        
    }
    public void StartTimer() {
        isTimerActive = true;
    }
}
