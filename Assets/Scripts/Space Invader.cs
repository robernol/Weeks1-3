using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInvader : MonoBehaviour
{
    float speed = 0.003f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += speed;

        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 screenSizeInTheWorld = new Vector2();
        screenSizeInTheWorld = Camera.main.ScreenToWorldPoint(screenSize);

        Vector2 screenZeroInTheWorld = Camera.main.ScreenToWorldPoint(Vector2.zero);

        if ((pos.x >= screenSizeInTheWorld.x) || (pos.x <= screenZeroInTheWorld.x))
        {
            speed *= -1;
            pos.y -= 1;
        }

        transform.position = pos;
    }
}
