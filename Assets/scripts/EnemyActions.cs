using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : ActionController
{
    public GameObject player;
    private float lastFire;
    public float coolDown = 2.0f;
    // Start is called before the first frame update
    private void Start() {
        lastFire = Time.fixedTime;
        player = GameObject.Find("Player");
    }
    override public void ActionOne(){

        float tempTime = Time.fixedTime;
        float deltaTime = tempTime - lastFire;
        if(deltaTime < coolDown){ //is the cooldown over?
            return;
        }
        lastFire = tempTime;
        //Find the direction of the player and fire an projectile at that direction
        Vector2 dir = player.transform.position - this.gameObject.transform.position;
        dir = dir.normalized;

        var clone = Instantiate(projectiles[0], this.gameObject.transform.position, Quaternion.identity);
        dir *= projectSpeed;
        clone.GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
    }
}
