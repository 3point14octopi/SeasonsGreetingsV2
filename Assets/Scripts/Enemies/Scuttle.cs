using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scuttle : MonoBehaviour
{

    public float moveSpeed;
    private Vector3 target;
    private RoomTrasition room;

    private float contingiencyTime = 10;

    private float moveTime = 3;

    private float timeSinceMove;

    // Start is called before the first frame update
    void Awake()
    {
         room = gameObject.GetComponentInParent<RoomTrasition>();
         timeSinceMove = 0;
            target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(room.GetActiveState())
        {

            Vector3 direction =(target - transform.position);

            if(direction.magnitude < 0.01)
            {
                if(timeSinceMove > moveTime)
                {
                    PickTarget();
                    timeSinceMove = 0;
                }

            }
            else
            {
                transform.position = transform.position + new Vector3(direction.x, direction.y, 0) * moveSpeed * Time.deltaTime;
            }

            if(timeSinceMove > contingiencyTime)
            {
                PickTarget();
                timeSinceMove = 0;
            }
            
            timeSinceMove += Time.deltaTime;

        }
    }

    private void PickTarget()
    {
        float randX = Random.Range(-2,2);
        float randY = Random.Range(-2,2);

        target = new Vector3(transform.position.x + randX, transform.position.y + randY, 0);

    }
}
