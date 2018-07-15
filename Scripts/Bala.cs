using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bala : MonoBehaviour {

	public bool canMove = false;
	public float timeToMove = 1f;
	public float xBounce = -2f;
	public float minYBounce = -4f;
	public float maxYBounce = 4f;
	private Vector3 targetPosition = new Vector3();
	public GameObject enemy;

	// Update is called once per frame
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		targetPosition = enemy.transform.position;
	}
	void Update () {
		if (canMove){
			this.transform.DOMove(targetPosition, timeToMove);
			//transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, Time.deltaTime*speed);
		}
	}

	public void Shoot(){
		canMove = true;
	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy"){
			Debug.Log("Blalal");
			
			float yVec = Random.Range(minYBounce, maxYBounce);
			
			Vector3 vector = new Vector3(xBounce, yVec, 0);
			targetPosition = Vector3.Reflect(this.transform.position, vector);
			timeToMove = timeToMove + 1f;
			Debug.Log(targetPosition);

		}
	}
}
