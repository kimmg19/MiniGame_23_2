using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    GameObject[] pos;
    Vector2 portal1;
    Vector2 portal2;
    void Start()
    {
        portal1 = pos[0].transform.position;
        portal2 = pos[1].transform.position;

    }

    public void PortalMove() {
        print("asd");

    }
}
