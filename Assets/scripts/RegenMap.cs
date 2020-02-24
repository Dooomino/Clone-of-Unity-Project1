using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenMap : MonoBehaviour
{
    GameObject obstacle;
    GameObject chests;
    GameObject tiles;
    // Start is called before the first frame update
    bool regened = false;
    void Start()
    {
        obstacle = GameObject.Find("ObstaclesMap");
        chests = GameObject.Find("ChestsMap");
        tiles = GameObject.Find("Tiles");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            regened = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !regened){
            obstacle.GetComponent<GenBlock>().Regen();
            chests.GetComponent<GenChest>().Regen();
            tiles.GetComponent<GenTile>().Regen();
            Transform playerTs =collision.gameObject.transform;
            float playerX = playerTs.position.x;
            float playerY = playerTs.position.y;
            playerTs.position = new Vector3(-playerX,-playerY,0);
            regened = true;
        }
    }
}
