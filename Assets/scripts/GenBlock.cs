using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
/* This script will only runs one time when game started.
    However, the Generation could still being 
    called by Regen() if necessary.*/
public class GenBlock : MonoBehaviour
{
    // Perlin noise variables
    int size;
    int scale;
    public float offsetX = 100f;  
    public float offsetY = 100f; 
    private static Tilemap tilemap;

    //overlap detection variable 
    public Transform player;
    private Vector3 playerPosition;
    private Vector3 chestPosition;

    public TileBase[] stones; // Pool for Stone Obstacles
    public TileBase[] planks; // Pool for Planks/Barrel Obstacles

   
    void Start()
    {
        size = GenTile.size;
        scale = GenTile.scale;
        offsetX = Random.Range(0,9999f);
        offsetY = Random.Range(0,9999f);
        tilemap = GetComponent<Tilemap>();
        playerPosition = player.position;
        chestPosition = GenChest.GetChestPos();
        Generate();
    }

    [ContextMenu("Regen")]
    void Regen(){
        offsetX = Random.Range(0,9999f);
        offsetY = Random.Range(0,9999f);
        tilemap = GetComponent<Tilemap>();
        Generate();
    }
    void Generate() {
        transform.position = new Vector3(-size/2,-size/2,0);
        tilemap.ClearAllTiles();
        int[,] vals = new int[size, size];
        for (int i = 0; i < size; i++)
        {   
            //get x distances
            var bx = (i-size/2); // Obstacle x
            var distx = Mathf.Abs( bx - playerPosition.x); // X distance to player
            for (int j = 0; j < size; j++)
            {
                // Generate Perlin noise
                float x = i * scale + offsetX;
                float y = j * scale + offsetY;
                int z = (int)(Mathf.PerlinNoise(x, y)*10);
                vals[i, j] = z;
                //get y distances
                var by = (j-size/2);// Obstacle x
                var disty = Mathf.Abs(by - playerPosition.y);// Y distance to player
                //Applied tileSet based on Chest & play position
                if ((distx > 1 && disty > 1) && 
                    (bx != chestPosition.x && by != chestPosition.y)){
                    // If NOT Overlap
                    Vector3Int v = new Vector3Int(i, j, 0);
                    if(vals[i,j]==7){
                        if((int)(Random.Range(0,100f))%2 == 0){
                            tilemap.SetTile(v, stones[(vals[i,j]*i*j)%stones.Length]);
                        }else{
                            tilemap.SetTile(v, planks[(vals[i,j]*i*j)%planks.Length]);
                        }
                    }
                }
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
