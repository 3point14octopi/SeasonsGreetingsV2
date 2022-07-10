using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RoomData : ScriptableObject
{
   public Vector2Int origin;

   public int roomHeight;

   public int roomLength;

   public int [,] tileType; 
}
