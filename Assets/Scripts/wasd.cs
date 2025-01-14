using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class wasd : MonoBehaviour
{
    Vector2 pos;
    int xspeed;
    int yspeed;
    Boolean faceLeft = false;
    Vector2 flip = new Vector2 (-1, 1);

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 screenSizeInTheWorld = new Vector2();
        screenSizeInTheWorld = Camera.main.ScreenToWorldPoint(screenSize);

        Vector2 screenZeroInTheWorld = Camera.main.ScreenToWorldPoint(Vector2.zero);

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (pos.y < screenSizeInTheWorld.y -1)
            {
                yspeed += 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (faceLeft == true)
            {
                faceLeft = false;
                transform.localScale *= flip;
            }

            if (pos.x > screenZeroInTheWorld.x)
            {
                xspeed -= 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (pos.y > screenZeroInTheWorld.y)
            {
                yspeed -= 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (faceLeft == false)
            {
                faceLeft = true;
                transform.localScale *= flip;
            }

            if (pos.x < screenSizeInTheWorld.x)
            {
                xspeed += 1;
            }
        }

        pos.x += xspeed;
        pos.y += yspeed;

        transform.position = pos;

        xspeed = 0;
        yspeed = 0;

    }
}