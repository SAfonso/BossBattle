using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[Serializable]

public class EnemyBullet : MonoBehaviour
{
    public float speed = 6f;

    public bool isMoving = false; 
    private GameObject player; 
    private Vector3 toDirection;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update(){ 
        if (isMoving){
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        } 
         
    } 

    public void Move(){
        float angles =  Quaternion.Angle(this.transform.rotation, Quaternion.identity);
        //Debug.Log(angles);
        toDirection = new Vector3(1, Mathf.Tan(-angles), 1).normalized;
        isMoving = true; 
        //this.transform.DOMoveX(-10,2);
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Border")){
            this.transform.position = new Vector3(-10, -3.3f, 0);
            BulletController.instance.EnemyBulletEnd(this);
        } else if (other.CompareTag("Player")){
            this.transform.position = new Vector3(-10, -3.3f, 0);
            BulletController.instance.EnemyBulletEnd(this);
            CharacterController.instance.TakeDamage();
        }
    }
}
