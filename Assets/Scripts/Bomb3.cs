using UnityEngine;

public class Bomb3 : MonoBehaviour
{
    public GameObject tileObj;


    private void OnTriggerEnter2D(Collider2D collision) {
        tileObj.SetActive(true);
        gameObject.SetActive(false);
    }





}
