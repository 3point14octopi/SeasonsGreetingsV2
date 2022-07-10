using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBasedMovement : MonoBehaviour
{

    private MapManager mapManager;

    [SerializeField]
    private float moveTime;

    private float moveCounter;


    private void Awake()
    {
        mapManager = FindObjectOfType<MapManager>();

        moveCounter = moveTime;
    }

    private void Update()
    {
        moveCounter -= Time.deltaTime;

        if (moveCounter <= 0)
        {
            moveCounter = moveTime;

        }

    }
}
