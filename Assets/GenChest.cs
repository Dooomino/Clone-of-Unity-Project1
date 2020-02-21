using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenChest : MonoBehaviour
{
    // Start is called before the first frame update
    int size;
    int scale;
    private static Tilemap tilemap;
    private Vector3Int chestPos;
    private int chestsVariant;
    public TileBase[] chests;

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
        Generate();
    }
}
