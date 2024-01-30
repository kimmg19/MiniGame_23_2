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
        SceneManager.LoadScene("Level 1");
    }

    public void OnclickStage2Btn()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void OnclickStage3Btn()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void OnclickStage4Btn()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void OnclickStage5Btn()
    {
        SceneManager.LoadScene("Level 5");
    }

    public void OnclickStage6Btn()
    {
        SceneManager.LoadScene("Level 6");
    }

    public void OnclickStage7Btn()
    {
        SceneManager.LoadScene("Level 7");
    }

    public void OnclickStage8Btn()
    {
        SceneManager.LoadScene("Level 8");
    }

    public void OnclickStage9Btn()
    {
        SceneManager.LoadScene("Level 9");
    }

    public void OnclickStage10Btn()
    {
        SceneManager.LoadScene("Level 10");
    }

    public void OnclickStage11Btn()
    {
        SceneManager.LoadScene("Level 11");
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
