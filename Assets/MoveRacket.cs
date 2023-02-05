using System.Collections;
using UnityEngine;

public class MoveRacket : MonoBehaviour
{  
    public float speed = 2;
    public string axis = "Vertical";
       
    void FixedUpdate()
    {
        float v = Input.GetAxisRaw(axis);
         
        if (speed < 50)
        {
            speed++;
        };
        
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }

}