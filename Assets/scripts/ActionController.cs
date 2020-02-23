using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    public float projectSpeed = 1.0f;
    public GameObject firstProjectile;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action(HashSet<string> inputs){
        if(inputs.Contains("1")){
            Vector3 worldCoord = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Input.mousePosition is in Screen Coords
            Vector2 dir = worldCoord - this.transform.position;
            dir = dir.normalized;
            // Debug.Log(dir);
            dir *= projectSpeed;
            Debug.DrawLine(this.transform.position, worldCoord , Color.black,3);
            var clone = Instantiate(firstProjectile, this.transform.position, Quaternion.identity);
            clone.GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
        }
        
    }
}
