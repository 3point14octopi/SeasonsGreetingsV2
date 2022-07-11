using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    public Animator animator;
    // Update is called once per frame
    public Vector3 movement;

    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        transform.position = transform.position + speed * movement * Time.deltaTime;
    }

    private void FixedUpdate() 
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3 (0,0,0);
    }

    public Vector3 GetMoveDirection()
    {
        return movement;
    }
}
