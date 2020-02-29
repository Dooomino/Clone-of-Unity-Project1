using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : ActionController
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Fire a projectile at the direction of the mouse's position
    override public void ActionOne(){
        Vector3 worldCoord = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Input.mousePosition is in Screen Coords
        Vector2 dir = worldCoord - this.transform.position;
        animator.SetBool("AttackOne", true);
        dir = dir.normalized;
        var clone = Instantiate(projectiles[0], this.transform.position + (Vector3)(0.3f * dir), Quaternion.identity);
        clone.layer = LayerMask.NameToLayer("playerAttack");
        dir *= projectSpeed;
        clone.GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
        
    }

    override public void ActionFive(){
        animator.SetBool("playerRoll", true);
    }
    //Reset the animations to return to idle animation
    public void endAnimation(){
        animator.SetBool("AttackOne", false);
        animator.SetBool("playerRoll", false);
    }
}
