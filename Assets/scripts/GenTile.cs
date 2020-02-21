using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GenTile : MonoBehaviour
{
    public int size = 10;
    [Range(0,100)]
    public int scale;
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
            for (int j = 0; j < size; j++)
            {   
                float x = i * scale + offsetX;
                float y = j * scale + offsetY;
                int z = (int)(Mathf.PerlinNoise(x, y)*10);
                vals[i, j] = z;
            }
        }

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Vector3Int v = new Vector3Int(i, j, 0);
                if(vals[i,j] > 5)
                    tilemap.SetTile(v, tileSet[1]);
                else
                    tilemap.SetTile(v, tileSet[0]);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Generate();
    }
}
