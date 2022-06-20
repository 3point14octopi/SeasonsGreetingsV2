using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{

    [SerializeField]
    private Tilemap map;


    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;


    private void Awake()
    {


        dataFromTiles = new Dictionary<TileBase, TileData>();
        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }

    }



    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = map.WorldToCell(mousePosition);

            TileBase clickedTile = map.GetTile(gridPosition);

            float walkingSpeed = dataFromTiles[clickedTile].walkingSpeed;

            print("Walking speed on tile type " + clickedTile + " is " + walkingSpeed);
        }

    }


    public float GetTileWalkingSpeed(Vector2 worldPosition)
    {
        Vector3Int gridPosition = map.WorldToCell(worldPosition);

        TileBase tile = map.GetTile(gridPosition);

        if (tile == null)
            return 1f;

        float walkingSpeed = dataFromTiles[tile].walkingSpeed;

        return walkingSpeed;
    
    }


}

