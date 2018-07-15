using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[System.Serializable]
public class InitialSecuence : Secuence {

	private GameObject player;

	private GameObject enemy;
	
	public override IEnumerator DoSecuence(){
		player = GameObject.FindGameObjectWithTag("Player");
		enemy = GameObject.FindGameObjectWithTag("Enemy");
		Debug.Log("Im in");
		EnterPlayer();
		yield return new WaitForSeconds(2.0f);
		EnterEnemy();
		yield return new WaitForSeconds(2.0f);
		CountDown("3");
		yield return new WaitForSeconds(1.0f);
        CountDown("2");
        yield return new WaitForSeconds(1.0f);
        CountDown("1");
        yield return new WaitForSeconds(1.0f);
        CountDown("Fight!");
        yield return new WaitForSeconds(1.0f);
        CountDown("");
        GameManager.instance.isOnSecuence = false;
	}

	private void EnterPlayer(){
		player.transform.DOMoveX(-5, 2);

	}

	private void EnterEnemy(){
		enemy.transform.DOMoveX(4f,2);
	}

    private void CountDown(string newText){
        GameObject.FindGameObjectWithTag("CountDownText").GetComponent<Text>().text = newText;
	}
}
