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
    {   //by default treat will not be placed
        isPlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaced)
        {   //when not placed, treat hides behind the background
            Vector3 hide = new Vector3 (transform.position.x, transform.position.y, 1);
            transform.position = hide;
        }

        if (Input.GetMouseButtonDown(0))
        {   //on left click, the treat will be "placed" and moved to the x position of the mouse
            isPlaced = true;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 bonePos = new Vector3(mousePos.x, -3.5f, -1); //uses mouse position to inform the bone position
            transform.position = bonePos;
            xPos = bonePos.x; //public variable so that the dog code can use it
        }
        
        
        
    }
}
