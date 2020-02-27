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
    public GameObject player;

    public GameObject[] enemyPrefabs;
    public List<GameObject> enemies;
    private Vector3 playerPosition;
    private Vector3Int[] chestPositions;

    public TileBase[] stones; // Pool for Stone Obstacles
    public TileBase[] planks; // Pool for Planks/Barrel Obstacles
    void Start()
    {
        size = GenTile.size;
        scale = GenTile.scale;
        offsetX = Random.Range(0,9999f);
        offsetY = Random.Range(0,9999f);
        tilemap = GetComponent<Tilemap>();
        playerPosition = player.transform.position;
        chestPositions = GenChest.GetChestPos();
        enemies = new List<GameObject>();
        SpawnMonster(); 
        Generate();
    }

    [ContextMenu("Regen")]
    public void Regen(){
        offsetX = Random.Range(0,9999f);
        offsetY = Random.Range(0,9999f);
        tilemap = GetComponent<Tilemap>();
        foreach(GameObject x in enemies){
            Destroy(x);
        }
        enemies = new List<GameObject>();
        SpawnMonster();
        Generate();
    }

    float distance(Vector3 o1,Vector3 o2){
        return Mathf.Sqrt(Mathf.Pow(o1.x-o2.x,2) + Mathf.Pow(o1.y-o2.y,2));
    }

    bool CheckChestPos(Vector3 pos){
        for (int i =0;i<chestPositions.Length;i++){
            if(distance(pos ,chestPositions[i]) < 4){
                return false;
            }
        }
        return true;
    }
    bool CheckMonsterPos(Vector3 pos){
        foreach(GameObject x in enemies){
            if(distance(pos ,x.transform.position) < 4){
                return false;
            }
        }
        return true;
    }
    void SpawnMonster(){
        foreach(GameObject x in enemyPrefabs){
            Vector3 pos = new Vector3(Random.Range(-size/2,size/2),Random.Range(-size/2,size/2),0);
            GameObject enemy = Instantiate(x,pos,Quaternion.identity);
            enemies.Add(enemy);
            // enemy.GetComponent<EnemyInput>().player = player;
        }
    }

    void Generate() {
        transform.position = new Vector3(-size/2,-size/2,0);
        tilemap.ClearAllTiles();
        int[,] vals = new int[size, size];
        for (int i = 0; i < size; i++)
        {   
            for (int j = 0; j < size; j++)
            {
                // Generate Perlin noise
                float x = i * scale + offsetX;
                float y = j * scale + offsetY;
                int z = (int)(Mathf.PerlinNoise(x, y)*10);
                vals[i, j] = z;

                //get block position
                Vector3 blockPos = new Vector3((i-size/2),(j-size/2),0);

                //Applied tileSet based on Chest & play position
                // (bx != chestPosition.x && by != chestPosition.y)
                if (distance(blockPos,playerPosition) > 4 && 
                    CheckChestPos(blockPos) &&
                    CheckMonsterPos(blockPos)){
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
