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
    public int MaxChestNum;
    private static Tilemap tilemap;
    private static Vector3Int[] chestPos;
    private int[] chestsVariants;
    public TileBase[] chests;
    private int chestNum;
    public static Vector3Int[] GetChestPos(){
        return chestPos;
    }
    bool isSet = false;
    void Start()
    {
        size = GenTile.size;
        scale = GenTile.scale;
        tilemap = GetComponent<Tilemap>();
        chestNum = Random.Range(1,MaxChestNum);
        chestPos = new Vector3Int[chestNum];
        chestsVariants = new int[chestNum];
        // Invole more than one cheast in a single room
        for (int i =0;i<chestNum;i++){
            chestPos[i] = new Vector3Int(Random.Range(0,100)%size,
                                         Random.Range(0,100)%size,
                                         0);
            chestsVariants[i] = Random.Range(0,100)%chests.Length;
        }

        Generate();
    }

    [ContextMenu("Regen")]
    public void Regen(){
        tilemap = GetComponent<Tilemap>();
        chestNum = Random.Range(1,MaxChestNum);
        chestPos = new Vector3Int[chestNum];
        chestsVariants = new int[chestNum];
        // Invole more than one cheast in a single room
        for (int i =0;i<chestNum;i++){
            chestPos[i] = new Vector3Int(Random.Range(0,100)%size,
                                         Random.Range(0,100)%size,
                                         0);
            chestsVariants[i] = Random.Range(0,100)%chests.Length;
        }
        Generate();
    }
    void Generate() {
        transform.position = new Vector3(-size/2,-size/2,0);
        tilemap.ClearAllTiles();
        for (int i =0;i<chestNum;i++){
            tilemap.SetTile(chestPos[i], chests[chestsVariants[i]]);
        }
    }
    float distance(Vector3 o1,Vector3 o2){
        return Mathf.Sqrt(Mathf.Pow(o1.x-o2.x,2) + Mathf.Pow(o1.y-o2.y,2));
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.gameObject.tag == "Player"){
            Vector3 playerPos =  collision.collider.gameObject.transform.position;
                for (int i =0;i<chestNum;i++){
                Vector3 chestWorldPos = new Vector3(chestPos[i].x-size/2,chestPos[i].y-size/2,0);
                if(distance(playerPos,chestWorldPos)<2){
                    tilemap.SetTile(chestPos[i],null);
                    //TODO: Applied Loot tables and effect
                }
            }
            // Debug.Log(playerPos+" "+chestPos+ "["+chestWorldPos+"]");
        }
    }
    void Update()
    {
    }
}
