using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Treat : MonoBehaviour
{
    public Boolean isPlaced;
    public float xPos;
    // Start is called before the first frame update
    void Start()
    {
        isPlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaced)
        {
            Vector3 hide = new Vector3 (transform.position.x, transform.position.y, 1);
            transform.position = hide;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isPlaced = true;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 bonePos = new Vector3(mousePos.x, -3.5f, -1);
            transform.position = bonePos;
            xPos = bonePos.x;
        }
        
        
        
    }
}
