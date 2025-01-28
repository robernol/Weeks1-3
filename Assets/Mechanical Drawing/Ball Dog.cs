using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEngine;

public class BallDog : MonoBehaviour
{
    public AudioSource nom;
    public AudioSource bark;
    public int treatCounter; //counts treats eaten
    public Sprite standSprite;
    Treat treat;
    Vector2 flip = new Vector2(-1, 1); //vector to flip the sprite
    float speed = 0f; //speed value starts at 0
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
            GetComponent<Animator>().enabled = true; //plays running animation when treat is placed
            float xPos1 = transform.position.x; //dog position
            xPos2 = treat.xPos; //treat position
            if (xPos1 > xPos2) //determines distance to know which way dog should face and move 
            {
                speed = -0.005f * (treatCounter+1); //the more treats eaten, the faster he will move
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
            if ((xPos2 - xPos1 <= 0.2) && (xPos2 - xPos1 >= -0.2)) //when dog gets close enough, he will eat the treat
            {
                treat.isPlaced = false;
                GetComponent<Animator>().enabled = false; //dog stops running and stands still
                GetComponent<SpriteRenderer>().sprite = standSprite;
                treatCounter++; //treat counter goes up
                nom.Play(0); //plays eating sound
            }

            //moves the dog accordingly (if the treat is placed)
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, -1);
            pos.x += speed;

            Vector2 screenSize = new Vector2(Screen.width, Screen.height);
            Vector2 screenSizeInTheWorld = new Vector2();
            screenSizeInTheWorld = Camera.main.ScreenToWorldPoint(screenSize);

            Vector2 screenZeroInTheWorld = Camera.main.ScreenToWorldPoint(Vector2.zero);


            transform.position = pos;
            
        }
        if (Input.GetMouseButtonDown(1)) //when right mouse is clicked, plays a bark sound
        {
            bark.Play(0);
        }

    }
}
