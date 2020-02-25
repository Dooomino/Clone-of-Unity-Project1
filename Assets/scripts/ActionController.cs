using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    private const int NUM_ATTACKS = 4;
    public float projectSpeed = 1.0f;
    public GameObject firstProjectile;
    public GameObject[] projectiles = new GameObject[NUM_ATTACKS];
    private float[] projectileCoolDown = new float[NUM_ATTACKS];
    // Start is called before the first frame update
    void Start()
    {
        float currentTime = Time.fixedTime;
        for(int i = 0; i < NUM_ATTACKS; i ++){
            projectileCoolDown[i] = currentTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action(HashSet<string> inputs){
        if(inputs.Contains("1")){
            firstProjectile.GetComponent<Attack>().Attack(this);
        }
        
    }
}
