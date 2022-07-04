using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrasition : MonoBehaviour
{
    public GameObject virtualCam;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Transition"))
        {
            virtualCam.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Transition"))
        {
            virtualCam.SetActive(false);
        }
    }
}
