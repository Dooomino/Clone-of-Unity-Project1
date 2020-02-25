using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UIElements;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float Maxhp = 100;   
    public float Maxmana = 100;
    [Range(0,100)]
    public float hp = 100;
    [Range(0,100)]
    public float mana = 100;
    public GameObject HpBarObj;
    public GameObject ManaBarObj;

    AudioSource audioSource;
    Slider HpBar;
    Slider ManaBar;
    // Start is called before the first frame update
    void Start()
    {
       
        HpBar = HpBarObj.GetComponent<Slider>();
        //   Debug.Log(HpBarObj.GetComponent<Slider>());
        ManaBar = ManaBarObj.GetComponent<Slider>();

        audioSource = GetComponent<AudioSource>();
       
    }

    public void DealDamage(float hit){
        hp -= hit;
        audioSource.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        HpBar.value = hp/100;
        ManaBar.value = mana/100;
    }
}
