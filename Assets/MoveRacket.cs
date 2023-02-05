using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour
{  
    public float speed = 30;
    public string axis = "Vertical";

    GameObject highlight;
    GameObject upArrow;
    GameObject downArrow;

    void Start()
    {
        highlight = transform.GetChild(0).gameObject;
        upArrow = transform.GetChild(1).gameObject;
        downArrow = transform.GetChild(2).gameObject;

        downArrow.SetActive(false);
        upArrow.SetActive(false);
    }

    void FixedUpdate()
    {
        float v = Input.GetAxisRaw(axis);
        if ((v < 0) && (speed==30))
        {
            downArrow.SetActive(true);
            upArrow.SetActive(false);

        } else if ((v > 0) && (speed == 30))
        {
            downArrow.SetActive(false);
            upArrow.SetActive(true);

        } else 
        {
            downArrow.SetActive(false);
            upArrow.SetActive(false);
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }

    void stopRacket()
    {
        speed = 0;
        highlight.SetActive(false);
        
    }

    void startRacket()
    {
        speed = 30;
        highlight.SetActive(true);
    }
}