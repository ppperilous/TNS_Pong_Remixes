using System.Collections;
using UnityEngine;

public class Alt_MoveRacket : MonoBehaviour
{
    public float Rspeed = 2;
    float acc = 5;
    float maxSpeed = 50;
    public string axis = "Vertical";

    void FixedUpdate()
    {

        while (Input.GetKey(KeyCode.UpArrow)){

            if (Rspeed < maxSpeed) {
                {
                    Rspeed += acc * Time.deltaTime;
                }

            }
            float v = Input.GetAxisRaw(axis);

            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * Rspeed;
            Rspeed = 0;
            Debug.Log("faster: " + Rspeed);
        }
    }
    }