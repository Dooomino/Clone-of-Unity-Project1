using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    private const int NUM_ATTACKS = 4;
    public float projectSpeed = 1.0f;
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
        
        float currentTime = Time.fixedTime;
        if(inputs.Contains("1")){
            ActionOne();
        }else if(inputs.Contains("2")){
            ActionTwo();
        }else if(inputs.Contains("3")){
            ActionThree();
        }else if(inputs.Contains("4")){
            ActionFour();
        }else if(inputs.Contains("5")){
            ActionFive();
        }else if(inputs.Contains("6")){
            ActionSix();
        }
        
    }
    virtual public void ActionOne(){}
    virtual public void ActionTwo(){}
    virtual public void ActionThree(){}
    virtual public void ActionFour(){}
    virtual public void ActionFive(){}
    virtual public void ActionSix(){}
}
