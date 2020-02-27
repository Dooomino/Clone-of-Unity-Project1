using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour, Interactable
{
    public int damage = 10;
    public float timeToLive = 1.0f;

    public float coolDown = 1.0f;
    private float timeBorn;
    [SerializeField] private string hitLayer;

    // Start is called before the first frame update
    void Start()
    {
        timeBorn = Time.fixedTime;  
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollision(CharacterController2D character){
        Debug.Log(character.gameObject);
        Destroy(this.gameObject);
    }
    void FixedUpdate(){
        this.gameObject.transform.Rotate(new Vector3(0f, 0f,1.0f), Space.Self);
        if(Time.fixedTime - timeBorn > timeToLive){
            Destroy(this.gameObject);
        }
    }
    // Projectile Will Destory itself when colision happens.
    // Allow effect(Animation) to be played
    // Concept of Delay actions: https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
    virtual public IEnumerator OnCollisionEnter2D(Collision2D collision) {
         
        if(collision.gameObject.layer == LayerMask.NameToLayer(hitLayer)){    
                if(hitLayer == "Player"){
                    collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
                }else{
                    collision.gameObject.GetComponent<EnemyStats>().hp -= damage;    
                }
                
                
            Destroy(this.gameObject);
        }
        
        // Wait for 1 second.
        yield return new WaitForSeconds(1);
        // Do Destory after Delay
        Destroy(this.gameObject);
    }
}
