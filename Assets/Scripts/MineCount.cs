using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MineCount : MonoBehaviour
{

    public TextMeshProUGUI text;
    public float mineCount = 0;
    public float correctCount = 0;

    void Start()
    {
        GameObject[] mines = GameObject.FindGameObjectsWithTag("Mine");
        for (int i = 0; i<mines.Length; i++)
        {
            mineCount++;
            correctCount++;
        }
        text.text = mineCount.ToString();
    }

    void Update()
    {
        text.text = mineCount.ToString();
        if (mineCount == 0)
        {
            GameObject[] dots = GameObject.FindGameObjectsWithTag("Dot");
            GameObject[] mines = GameObject.FindGameObjectsWithTag("Mine");
            for (int i = 0; i<dots.Length; i++)
            {
                SpriteRenderer dotColor = dots[i].GetComponent<SpriteRenderer>();
                if(dotColor.color == Color.red) 
                { 
                    for (int j = 0; j<mines.Length;  j++)
                    {
                        if (dots[i].transform.position == mines[j].transform.position)
                        {
                            correctCount--;
                        }
                    }
                }
            }
        }
        if (correctCount == 0)
        {
            GameObject winPannel = GameObject.Find("Canvas");
            winPannel = winPannel.transform.Find("WinResultPannel").gameObject;
            winPannel.SetActive(true);
        }
    }
}
