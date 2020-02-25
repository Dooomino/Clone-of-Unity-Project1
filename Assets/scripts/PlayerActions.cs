using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : ActionController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void ActionOne(){
        Vector3 worldCoord = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Input.mousePosition is in Screen Coords
        Vector2 dir = worldCoord - this.transform.position;

        dir = dir.normalized;
        var clone = Instantiate(projectiles[0], this.transform.position + (Vector3)(0.3f * dir), Quaternion.identity);
        clone.layer = LayerMask.NameToLayer("playerAttack");
        dir *= projectSpeed;
        clone.GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
    }
}
