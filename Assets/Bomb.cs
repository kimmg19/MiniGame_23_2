
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision) {
        print("Ãæµ¹");
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
    void Start() {
        
    }
     
    
    private void OnMouseDown() {
        Renderer obj = gameObject.GetComponent<Renderer>();
        if (obj.material.color == Color.white) {
            obj.material.color = Color.red;
        } else {
            obj.material.color = Color.white;
        }
    }


}
