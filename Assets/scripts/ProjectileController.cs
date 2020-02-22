using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
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
    void FixedUpdate(){
        if(Time.fixedTime - timeBorn > timeToLive){
            Destroy(this.gameObject);
        }
    }
}
