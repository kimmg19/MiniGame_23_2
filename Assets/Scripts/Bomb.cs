using UnityEngine;

public class Bomb : MonoBehaviour
{


    
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
