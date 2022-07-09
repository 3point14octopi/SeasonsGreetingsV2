using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retreat : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rigid;
    public Transform target;
    private float timeTillSpawn;
    public GameObject enemyToSpawn;

    public float spawnTime;
    private Vector2 moveDirection;

    private RoomTrasition room;

    // Start is called before the first frame update
    void Start()
    {
        room = gameObject.GetComponentInParent<RoomTrasition>();
        rigid = GetComponent<Rigidbody2D>();
        timeTillSpawn = spawnTime;

    }

    // Update is called once per frame
    void Update()
    {
        if(room.GetActiveState())
        {
            Vector3 direction =(transform.position - target.position);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rigid.rotation = angle + 180;
            moveDirection = direction.normalized;
            if(direction.magnitude < 7)
            {

                transform.position = transform.position + new Vector3(moveDirection.x, moveDirection.y, 0) * moveSpeed * Time.deltaTime;

            }
            else
            {
                if(timeTillSpawn <= 0)
                {
                    GameObject newspawn = Instantiate(enemyToSpawn, transform.position - new Vector3 (0,-3,0), Quaternion.identity, transform.parent);
                    timeTillSpawn = spawnTime;
                }
                timeTillSpawn -= Time.deltaTime;
                //countdown to spawn thing
            }
            
        }
    }
}
