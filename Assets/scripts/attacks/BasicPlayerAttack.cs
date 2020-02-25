using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerAttack : MonoBehaviour, Attack, Interactable
{
    public float projectSpeed = 10;
    public float timeToKill = 1;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        float tempTime = Time.fixedTime;
        if(tempTime - currentTime > timeToKill){
            Destroy(this);
        }else{
            currentTime = tempTime;
        }
    }

    public void Attack(ActionController attacker){
        Vector3 worldCoord = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Input.mousePosition is in Screen Coords
            Vector2 dir = worldCoord - attacker.transform.position;

            dir = dir.normalized;
            var clone = Instantiate(this.gameObject, attacker.transform.position + (Vector3)(0.3f * dir), Quaternion.identity);
            Debug.DrawRay(attacker.transform.position, dir, Color.white, 1);
            dir *= projectSpeed;
            clone.GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
    }

    public void OnCollision(CharacterController2D character){

    }
}
