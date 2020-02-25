using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicAttack : MonoBehaviour, Attack, Interactable
{
    public float projectSpeed = 10;
    public float timeToKill = 1;
    public float damage = 10;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(ActionController attacker){
            GameObject playerTarget = GameObject.FindGameObjectWithTag("Player");
            Vector2 dir = playerTarget.transform.position - attacker.transform.position;

            dir = dir.normalized;
            var clone = Instantiate(this.gameObject, attacker.transform.position + (Vector3)(0.3f * dir), Quaternion.identity);
            Debug.DrawRay(attacker.transform.position, dir, Color.white, 1);
            dir *= projectSpeed;
            clone.GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
    }
    public void OnCollision(CharacterController2D character){
        character.gameObject.GetComponent<PlayerStats>().DealDamage(damage);
    }
}
