using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenBlock : MonoBehaviour
{
    // Start is called before the first frame update
    int size;
    int scale;
    public float offsetX = 100f; 
    public float offsetY = 100f; 
    private static Tilemap tilemap;

    public TileBase[] stones;
    public TileBase[] planks;
    void Start()
    {
        size = GenTile.size;
        scale = GenTile.scale;
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

    // Update is called once per frame
    void Update()
    {
       
    }
}
