using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    public int healthPoints;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.layer == 10)  
        {
            healthPoints--;
            if(healthPoints <= 0)
            {
            Destroy(gameObject);
            }
        }  
    }
}
