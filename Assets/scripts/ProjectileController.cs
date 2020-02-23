using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour, Interactable
{
    public int damage = 10;
    public float timeToLive = 1.0f;

    public float coolDown = 1.0f;
    private float timeBorn;

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
        if(Time.fixedTime - timeBorn > timeToLive){
            Destroy(this.gameObject);
        }
    }
    // Projectile Will Destory itself when colision happens.
    // Allow effect(Animation) to be played
    // Concept of Delay actions: https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
    private IEnumerator OnCollisionEnter2D(Collision2D collision) {
        // Wait for 1 second.
        yield return new WaitForSeconds(1);
        // Do Destory after Delay
        Destroy(this.gameObject);
    }
}
