using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private RoomTrasition room;

    public GameObject bullet;

    public Transform target;

    private float timer;
    public float reloadTime = 5;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
         room = gameObject.GetComponentInParent<RoomTrasition>();
         timer = reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(room.GetActiveState())
        {
            if(timer <= 0)
            {
                Shoot();
                timer = reloadTime;
            }

            timer -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        Vector3 direction =(target.position - transform.position).normalized;
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity, transform);
        newBullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
