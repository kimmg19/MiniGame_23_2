using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileText : MonoBehaviour
{
    public LayerMask objectLayer;
    TextMeshPro text;
    public float radius;
    void Start() {
        text=GetComponentInChildren<TextMeshPro>();
        
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, radius, objectLayer);
        text.text = colls.Length.ToString();
    }
    
}
