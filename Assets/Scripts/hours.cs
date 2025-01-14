using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hours : MonoBehaviour
{
    public float speed;
    Vector3 centre;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 screenSizeInTheWorld = new Vector2();
        screenSizeInTheWorld = Camera.main.ScreenToWorldPoint(screenSize);

        centre = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {

        transform.RotateAround(centre, Vector3.forward, speed);
    }
}
