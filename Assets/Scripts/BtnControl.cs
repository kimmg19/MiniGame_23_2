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
        Debug.Log("�� ����");
        SceneManager.LoadScene("Main");
    }

    public void OnclickBackBtn2()
    {
        Debug.Log("�� ����");
        SceneManager.LoadScene("ChooseLevel");
    }

    public void OnclickStageBtn()
    {
        Debug.Log("�� ����");
        SceneManager.LoadScene("BasicLevel");
    }
}
