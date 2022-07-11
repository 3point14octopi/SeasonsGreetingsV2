using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public float bulletSpeed;

    [SerializeField]
    private GameObject playerBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)|| Input.GetKeyDown(KeyCode.RightShift))
        {
            Shoot();
        }
    }

    public void Shoot()
    {

        Vector3 shootDirection = (gameObject.GetComponent<CharacterMovement>().GetMoveDirection()).normalized;

            GameObject newBullet = Instantiate(playerBullet, new Vector3 (transform.position.x + shootDirection.x, transform.position.y + shootDirection.y,0), Quaternion.identity);
            
            if(shootDirection != new Vector3(0,0,0))
            {
            newBullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;
            }

            else
            {
                newBullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -1f, 0) * bulletSpeed;
            }
    }
}
