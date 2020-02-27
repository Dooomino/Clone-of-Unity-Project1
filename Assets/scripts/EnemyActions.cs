using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : ActionController
{
    public GameObject player;
    // Start is called before the first frame update
    override public void ActionOne(){
        Vector2 dir = player.transform.position - this.gameObject.transform.position;
        dir = dir.normalized;

        var clone = Instantiate(projectiles[0], this.gameObject.transform.position, Quaternion.identity);
        dir *= projectSpeed;
        clone.GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
    }
}
