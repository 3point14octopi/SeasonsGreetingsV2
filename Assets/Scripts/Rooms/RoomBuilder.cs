using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomBuilder : MonoBehaviour
{


    private PolygonCollider2D poly;

    private int basicHeight = 9;
    private int tileDim = 2;
    
    //will be passed by joey algorythm
    public int roomLength;
    public int roomHeight;
    public Vector2 origin;

    // Start is called before the first frame update
    void Awake()
    {
        poly = gameObject.GetComponent<PolygonCollider2D>();
       //this will exist later
        /*
        middle man script will hold the data for one room at a time and will update as rooms are created, 
            be sure to update prefab with an existing reference to the middle man so it can easily grab from it.

         roomlength = middleMan.getLength();
         roomHeight = middleMan.getHeight();
         origin = middleMan.GetOrigin();

        */

        //perform the rest of the room creation peice by peice
        BuildCamCollision();  


    }

    public void BuildCamCollision()
    {
        //rework to only unse the nessisary 4 coners instead of all the extra stuff :D

        int roomScale = roomHeight/basicHeight; 
        int totalPoints = (roomScale * 10) + 2;
        Vector2[] myPoints = new Vector2 [totalPoints];
       
        float halfTile = tileDim/2;
        float shenanigans = ((tileDim * basicHeight)/2) - halfTile;
        

        myPoints[0] = new Vector2(origin.x + 1, origin.y);
        int count = 1;

        for(int counter = 0; counter < roomScale; counter ++)
        {
            myPoints[count].y = myPoints[count -1].y - (shenanigans);
            myPoints[count].x = origin.x + halfTile;
            count++;
            myPoints[count].y = myPoints[count - 1].y;
            myPoints[count].x = origin.x + halfTile;
            count++;
            myPoints[count].y = myPoints[count - 1].y - tileDim;
            myPoints[count].x = origin.x + halfTile;
            count++;
            myPoints[count].y = myPoints[count - 1].y;
            myPoints[count].x = origin.x + halfTile;
            count++;
            myPoints[count].y = myPoints[count - 1].y - (shenanigans);
            myPoints[count].x = origin.x + halfTile;
            count++;
        }
        
        poly.points = myPoints;

        //safety
        int safety = count;
        bool flip = false;

        for (int i = 1; i <= safety; i++) 
        {
            myPoints[count].y = myPoints[count - ((2 * i) - 1)].y;
            myPoints[count].x = origin.x + (roomLength * tileDim) - halfTile;
            if(myPoints[count].y == myPoints[count - 1].y && i > 1)
            {
                flip = !flip;
            }
            if(flip == true)
            {
                //myPoints[count].x += halfTile;
            }
            
            count++;
        }
        poly.points = myPoints;
    }
}



