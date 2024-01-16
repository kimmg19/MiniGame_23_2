using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnclickBackBtn1()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnclickBackBtn2()
    {
        SceneManager.LoadScene("ChooseLevel");
    }

    public void OnclickOptionBtn()
    {
        SceneManager.LoadScene("Option");
    }

    public void OnclickStage1Btn()
    {
        SceneManager.LoadScene("BasicLevel");
    }

    public void OnclickPauseBtn()
    {
        Time.timeScale = 0;
    }

    public void OnclickResumeBtn()
    {
        Time.timeScale = 1;
    }
}
