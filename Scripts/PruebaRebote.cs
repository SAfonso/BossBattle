using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaRebote : MonoBehaviour {

	public Bala bala;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A)){
			bala.Shoot();
		}
	}
}
