using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShadowtheHedgehog : MonoBehaviour
{
    float speed = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += speed;
        transform.position = pos;


        if ((pos.x >= 10) || (pos.x <= -10))
                {
            speed *= -1;
        }
    }
}
