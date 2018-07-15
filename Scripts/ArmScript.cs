using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArmScript : MonoBehaviour {

	private float armPosition;
	private float armOldPosition;
	private GameObject arm;

	void Start () {
		arm = this.transform.gameObject;
		
	}

	/*public void MoveBackArm(){
		armPosition = arm.transform.position.x;
		arm.transform.position = new Vector3(0.5f, arm.transform.position.y, arm.transform.position.z);
		
	}

	public void ResetBackArm(){
		arm.transform.position = new Vector3(armPosition, arm.transform.position.y, arm.transform.position.z);
		
	}*/

	public void ShootArm() {
		armOldPosition = this.transform.position.x;
		EnemyController.instance.isMoving = false;
		arm.transform.DOMoveX(-7,2);
		EnemyController.instance.pickUp = false;
		StartCoroutine(PickUpArms());
	}

	IEnumerator PickUpArms() {
    	yield return new WaitForSeconds(3f);
		arm.transform.DOMoveX(armOldPosition,2);
		StartCoroutine(ContiuneMoving());
		
    }

	IEnumerator ContiuneMoving() {
		//armTwo.ResetBackArm();
    	yield return new WaitForSeconds(2f);
		EnemyController.instance.pickUp = true;
		EnemyController.instance.isMoving = true;
    }
}
