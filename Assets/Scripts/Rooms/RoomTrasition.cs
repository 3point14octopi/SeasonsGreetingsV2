using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrasition : MonoBehaviour
{
    public GameObject virtualCam;
    private bool isActiveRoom;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Transition"))
        {
            virtualCam.SetActive(true);
            isActiveRoom = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Transition"))
        {
            virtualCam.SetActive(false);
            isActiveRoom = false;
        }
    }

    public bool GetActiveState()
    {
        return isActiveRoom;
    }
}
