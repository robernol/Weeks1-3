using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEngine;

public class BallDog : MonoBehaviour
{
    public AudioSource nom;
    public AudioSource bark;
    public int treatCounter;
    public Sprite standSprite;
    Treat treat;
    Vector2 flip = new Vector2(-1, 1);
    float speed = 0f;
    float xPos2;
    // Start is called before the first frame update
    void Start()
    {
        treatCounter = 0;
        treat = GameObject.Find("dogbiscuit").GetComponent<Treat>();
    }

    // Update is called once per frame
    void Update()
    {

        if (treat.isPlaced)
        {
            GetComponent<Animator>().enabled = true;
            float xPos1 = transform.position.x;
            xPos2 = treat.xPos;
            if (xPos1 > xPos2)
            {
                speed = -0.005f * (treatCounter+1);
                if (transform.localScale.x == 1)
                {
                    transform.localScale *= flip;
                }
            }
            else if (xPos1 < xPos2)
            {
                speed = 0.005f * (treatCounter+1);
                if (transform.localScale.x == -1)
                {
                    transform.localScale *= flip;
                }
            }
            if ((xPos2 - xPos1 <= 0.2) && (xPos2 - xPos1 >= -0.2))
            {
                treat.isPlaced = false;
                GetComponent<Animator>().enabled = false;
                GetComponent<SpriteRenderer>().sprite = standSprite;
                treatCounter++;
                nom.Play(0);
            }

            Vector3 pos = new Vector3(transform.position.x, transform.position.y, -1);
            pos.x += speed;

            Vector2 screenSize = new Vector2(Screen.width, Screen.height);
            Vector2 screenSizeInTheWorld = new Vector2();
            screenSizeInTheWorld = Camera.main.ScreenToWorldPoint(screenSize);

            Vector2 screenZeroInTheWorld = Camera.main.ScreenToWorldPoint(Vector2.zero);


            transform.position = pos;
            
        }
        if (Input.GetMouseButtonDown(1))
        {
            bark.Play(0);
        }

    }
}
