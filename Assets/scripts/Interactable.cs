using UnityEngine;
/*
* This interface will be implemented by any object that is in the Interactable layer.
* When the player intersects with the interactable object, it calls the OnCollision function.
* This will allow the objects to do different things when the player collideds with it.
*/
public interface Interactable
{
	void OnCollision(CharacterController2D character);
}
