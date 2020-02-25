using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerAttack : MonoBehaviour, Attack
{
    public float projectSpeed = 10;
    public float timeToKill = 1.0f;
    private float lastFire;
    public float coolDown = 1.0f;
    public float damage = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        lastFire = Time.time;
    }

    // Update is called once per frame
    void Update(){
        /*
        float tempTime = Time.fixedTime;
            float deltaTime = tempTime - lastFire;
            if(deltaTime < timeToKill){
                Destroy(this.gameObject);
            }*/
            
    }

    void FixedUpdate(){
        
    }

    public void Attack(ActionController attacker){
        
        float tempTime = Time.fixedTime;
            float deltaTime = tempTime - lastFire;
            if(deltaTime < coolDown){
                return;
            }
            lastFire = tempTime;
        Vector3 worldCoord = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Input.mousePosition is in Screen Coords
            Vector2 dir = worldCoord - attacker.transform.position;

            dir = dir.normalized;
            var clone = Instantiate(this.gameObject, attacker.transform.position + (Vector3)(0.3f * dir), Quaternion.identity);
            dir *= projectSpeed;
            clone.GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
    }
}
