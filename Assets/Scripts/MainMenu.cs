using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnClickStart() {
        Debug.Log("æ¿ ∫Ø∞Ê");
        SceneManager.LoadScene("ChooseLevel");
    }

    public void OnClickOpt() {
        Debug.Log("æ¿ ∫Ø∞Ê");
        SceneManager.LoadScene("Option");
    }

    public void OnClickQuit() {
        Debug.Log("∞‘¿” ¡æ∑·");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
