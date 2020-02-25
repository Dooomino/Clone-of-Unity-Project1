using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
/* This script will only runs one time when game started.
    However, the Generation could still being 
    called by Regen() if necessary.*/
public class GenTile : MonoBehaviour
{
    // Perlin noise variables
    // [Range(10,30)]
    public static int size = 16;
    // [Range(0,100)]
    public static int scale = 72;
    public float offsetX = 100f; 
    public float offsetY = 100f; 
    public TileBase[] tileSet;
    private static Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        offsetX = Random.Range(0,9999f);
        offsetY = Random.Range(0,9999f);
        tilemap = GetComponent<Tilemap>();
        Generate();
    }

    [ContextMenu("Regen")]
    public void Regen(){
        offsetX = Random.Range(0,9999f);
        offsetY = Random.Range(0,9999f);
        tilemap = GetComponent<Tilemap>();
        Generate();
    }
    void Generate() {
        transform.position = new Vector3(-size/2,-size/2,0);
        tilemap.ClearAllTiles();
        int[,] vals = new int[size, size];

        // Generate perlin noise
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {   
                float x = i * scale + offsetX;
                float y = j * scale + offsetY;
                int z = (int)(Mathf.PerlinNoise(x, y)*10*tileSet.Length);
                vals[i, j] = z;
                // Applied to TileMap
                if(vals[i,j] > (tileSet.Length*10)/2 ){
                    Vector3Int v = new Vector3Int(i, j, 0);
                    var index = vals[i,j] % tileSet.Length;
                    tilemap.SetTile(v, tileSet[index]);
                }
            }
        }
    }
    void Update()
    {
        // Generate();
    }
}
