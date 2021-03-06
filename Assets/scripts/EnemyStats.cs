﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float Maxhp = 100;
    public float Maxmana = 0;
    [Range(0,100)]
    public float hp = 100;
    [Range(0,100)]
    public float mana = 0;
    public float hitPoint = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
       
  
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag=="Player"){ //deal damage to a player if the player touches the enemy
            PlayerStats stats = collision.gameObject.GetComponent<PlayerStats>();
            stats.TakeDamage(hitPoint);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(hp <= 0){
            Destroy(this.gameObject);
        }
    }
}
