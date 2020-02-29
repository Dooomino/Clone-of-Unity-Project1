using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInput : MonoBehaviour
{
    public GameObject player;
    private HashSet<string> actions;
    private CharacterController2D characterController;
    private ActionController actionController;
    private float horiziontalMove = 0.0f;
    private float verticalMove = 0.0f;
    public float sightRadius = 10;

   
    [SerializeField] private LayerMask playerLayer;
    // Start is called before the first frame update
    void Start()
    {
        actions = new HashSet<string>();
        characterController = GetComponent<CharacterController2D>();
        actionController = GetComponent<ActionController>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update(){
        
    }
    void FixedUpdate(){
        characterController.Move(horiziontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime, false);     
        if(inRange(player)){
            Vector3 dir = player.transform.position - this.gameObject.transform.position;
            dir = dir.normalized;
            Vector3 scale = transform.localScale;
            scale.x = dir.x/Mathf.Abs(dir.x);
            transform.localScale = scale;
            actions.Add("1");
        }
        actionController.Action(actions);
        actions.Clear();
    }

    private bool inRange(GameObject player){
        //Create a circle around the enemy. If the player is within that circle, return true
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.gameObject.transform.position, sightRadius, playerLayer);
        return colliders.Length > 0;

    }
}
