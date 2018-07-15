using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[Serializable]

public class Bullet : MonoBehaviour
{

    public void Move()
    {
        this.transform.DOMoveX(10, 1);

    }


    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Border")){
            this.transform.position = new Vector3(-10, -3.3f, 0);
            BulletController.instance.PlayerBulletEnd(this);
        }

    }
}
