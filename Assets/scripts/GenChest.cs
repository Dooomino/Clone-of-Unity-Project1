using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
/* This script will only runs one time when game started.
    However, the Generation could still being 
    called by Regen() if necessary.*/
public class GenChest : MonoBehaviour
{
    // Perlin noise variables
    int size;
    int scale;
    private static Tilemap tilemap;
    private static Vector3Int chestPos;
    private int chestsVariant;
    public TileBase[] chests;
    public static Vector3 GetChestPos(){
        return chestPos;
    }
    bool isSet = false;
    void Start()
    {
        size = GenTile.size;
        scale = GenTile.scale;
        tilemap = GetComponent<Tilemap>();
        chestPos = new Vector3Int(Random.Range(0,100)%size,
                                    Random.Range(0,100)%size,
                                    0);
        chestsVariant = Random.Range(0,100)%chests.Length;

        Generate();
    }

    [ContextMenu("Regen")]
    void Regen(){
        tilemap = GetComponent<Tilemap>();
        Generate();
    }
    void Generate() {
        transform.position = new Vector3(-size/2,-size/2,0);
        tilemap.ClearAllTiles();
        tilemap.SetTile(chestPos, chests[chestsVariant]);

    }

    // Update is called once per frame
    void Update()
    {
    }
}
