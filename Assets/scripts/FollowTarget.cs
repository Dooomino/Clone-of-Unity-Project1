using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Found the concept here https://answers.unity.com/questions/31582/need-camera-to-follow-player-but-not-the-players-r.html
public class FollowTarget : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	// Use this for initialization
	//Set the camera's position to a bit away from the target
	void Start () {
		Vector3 location = target.position + offset;
		location.z = transform.position.z; //Want the z coord to not change
		transform.position = location;
	}
	
	// Update is called once per frame
	//Do the same as above
	void Update () {
		Vector3 location = target.position + offset;
		location.z = transform.position.z;
		transform.position = location;
	}
}
