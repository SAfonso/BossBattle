using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MisileScript : MonoBehaviour {

	public float speed = 0.5f; 
    public bool isMoving = false; 
    private GameObject player; 
    private Vector3 playerPosition; 

	void Update(){ 
        if (isMoving){ 
            this.transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed*Time.deltaTime); 
        } 
         
    } 
	public void ShootMisile(){
		playerPosition  = Vector3.ClampMagnitude(player.transform.position, 70); 
        isMoving = true; 
	}

}
