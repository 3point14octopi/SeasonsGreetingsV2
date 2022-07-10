using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{

    [SerializeField]
    private Tilemap bgmap;

    [SerializeField]
    private Tilemap wallmap;

    [SerializeField]
    private TileBase bgtile;

    [SerializeField]
    private TileBase walltile;

    [SerializeField]
    private List<RoomData> roomDatas;

    [SerializeField]
    private Grid grid;

    public GameObject roomPrefab;

    private Dictionary<TileBase, TileData> dataFromTiles;

    private int tileToPlace;

    private void Awake()
    {


        int  [,] sampleRoom = new int [9,17] {
                            {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0} , 
                            {0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0} ,
                            {0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0} ,
                            {0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0} ,
                            {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                            {0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                            {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0} ,
                            {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0} ,
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
                            };

        RoomData room = ScriptableObject.CreateInstance<RoomData>();
        room.tileType = sampleRoom;
        room.roomHeight = 9;
        room.roomLength = 17;
        room.origin = new Vector2Int(-9,5);
        roomDatas.Add(room);


        AssetDatabase.CreateAsset(room, "Assets/Scriptable Objects/RoomData/TestRoom.asset"); 
    }



    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            BuildRooms();
        }

    }

    public void BuildRooms()
    {

        foreach(var RoomData in roomDatas)
        {


            //lay tiles
            for(int count = 0; count < RoomData.roomHeight; count++)
            {
                for(int quickCount = RoomData.roomLength -1; quickCount >= 0; quickCount --)
                {

                    Debug.Log(RoomData.roomLength);
                    tileToPlace = RoomData.tileType[count,quickCount];

                    switch(tileToPlace)
                    {
                        case 0:

                                wallmap.SetTile(new Vector3Int(RoomData.origin.x + quickCount, RoomData.origin.y + count,0), walltile);
                                break;

                        case 1:

                                bgmap.SetTile(new Vector3Int(RoomData.origin.x + quickCount, RoomData.origin.y + count,0), bgtile);
                                break;


                        default:

                        break;
                    }

                    

                }
            }

        }
    }
}

