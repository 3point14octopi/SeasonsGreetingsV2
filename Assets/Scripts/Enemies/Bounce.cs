using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    private float xVel = 1;
    private float yVel = 1;

    private RoomTrasition room;

    void Start() 
    {
         room = gameObject.GetComponentInParent<RoomTrasition>();
    }
   
    void Update()
    {
        if(room.GetActiveState())
        {
            transform.position = transform.position + new Vector3(xVel, yVel, 0) * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       Vector3 hit  = other.contacts[0].normal;

       float angle  = Vector3.Angle(hit, Vector3.up);

       if(Mathf.Approximately(angle,0) || Mathf.Approximately(angle, 180))
       {
            yVel *= -1;
       }

       if(Mathf.Approximately(angle,90))
       {
            xVel *= -1;
       }

       
    }

    
}
