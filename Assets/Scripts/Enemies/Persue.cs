using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persue : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D rigid;
    public Transform target;

    private Vector2 moveDirection;

    private RoomTrasition room;

    // Start is called before the first frame update
    void Start()
    {
        room = gameObject.GetComponentInParent<RoomTrasition>();
        rigid = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if(room.GetActiveState())
        {
            Vector3 direction =(target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rigid.rotation = angle + 180;
            moveDirection = direction;
            transform.position = transform.position + new Vector3(moveDirection.x, moveDirection.y, 0) * moveSpeed * Time.deltaTime;
        }
    }
}
