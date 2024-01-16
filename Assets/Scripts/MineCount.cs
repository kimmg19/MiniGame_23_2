using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MineCount : MonoBehaviour
{

    public TextMeshProUGUI text;
    public float mineCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] mines = GameObject.FindGameObjectsWithTag("Mine");
        for (int i = 0; i<mines.Length; i++)
        {
            mineCount++;
        }
        text.text = mineCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = mineCount.ToString();
    }
}
