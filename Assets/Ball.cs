using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class Ball : MonoBehaviour {

    public float speed = 8;

    GameObject RacketLeft;
    GameObject RacketRight;

    private Component racketScript;

    //Create a stop watch
    Stopwatch sw = new Stopwatch();

    //Number of ms before speed is incremented
    public float period = 4000;

    //Stores current ms since last speed update
    float currentMs = 0;

    void Start() {
        RacketLeft = GameObject.Find("RacketLeft");
        RacketRight = GameObject.Find("RacketRight");

        //Stop movement of Left Racket (as ball moves to the right
        RacketLeft.SendMessage("stopRacket");

        // Initial Velocity of Ball
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

        //Start stopwatch
        sw.Start();
    }

    void Update()
    {
        //increments speed at the set period
        float ms = sw.ElapsedMilliseconds;
        if (ms - currentMs > period)
        {
            speed++;
            currentMs = ms;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                    float racketHeight) {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y)/(racketHeight/2);
    }

    void OnCollisionEnter2D(Collision2D col) {
    // Note: 'col' holds the collision information. If the
    // Ball collided with a racket, then:
    // col.gameObject is the racket
    // col.transform.position is the racket's position
    // col.collider is the racket's collider

    // Hit the left Racket?
    if (col.gameObject.name == "RacketLeft") {
        // Calculate hit Factor
        float y = hitFactor(transform.position,
                            col.transform.position,
                            col.collider.bounds.size.y);

        // Calculate direction, make length=1 via .normalized
        Vector2 dir = new Vector2(1, y).normalized;

        // Set Velocity with dir * speed
        GetComponent<Rigidbody2D>().velocity = dir * speed;

         //Deactivate left racket, activate right racket
         RacketLeft.SendMessage("stopRacket");
         RacketRight.SendMessage("startRacket");
     }

    // Hit the right Racket?
    if (col.gameObject.name == "RacketRight") {
        // Calculate hit Factor
        float y = hitFactor(transform.position,
                            col.transform.position,
                            col.collider.bounds.size.y);

        // Calculate direction, make length=1 via .normalized
        Vector2 dir = new Vector2(-1, y).normalized;

        // Set Velocity with dir * speed
        GetComponent<Rigidbody2D>().velocity = dir * speed;

         //Deactivate right racket, activate right racket
         RacketLeft.SendMessage("startRacket");
         RacketRight.SendMessage("stopRacket");
     }

    // Hit the left Wall?
    if (col.gameObject.name == "WallLeft"){

            //Reposition ball to center
            transform.position = new Vector2(0,0);

            //Reduce speed a little, if it is more than 20
            if (speed > 20) speed = speed - 5;

            //Launch ball towards the opp side (ie. right side)
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

            //Deactivate left racket, activate right racket
            RacketLeft.SendMessage("stopRacket");
            RacketRight.SendMessage("startRacket");

            //Update Score?

        }

    //Hit the right wall?
    if (col.gameObject.name == "WallRight")
        {

            //Reposition ball to center
            transform.position = new Vector2(0, 0);

            //Reduce speed a little, if it is more than 20
            if (speed > 20) speed = speed - 5;

            //Launch ball towards the opp side (ie. left side)
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;

            //Deactivate right racket, activate right racket
            RacketLeft.SendMessage("startRacket");
            RacketRight.SendMessage("stopRacket");

            //Update Score?

        }

    }
}