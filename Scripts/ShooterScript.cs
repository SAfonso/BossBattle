using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour {

    public void ShootWeapon () {
        EnemyBullet bullet = BulletController.instance.EnemyShootABullet();
        bullet.transform.position = new Vector3(this.transform.position.x + 0.5f, this.transform.position.y, this.transform.position.z);
        bullet.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x,this.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z + 15);
        bullet.Move();
	}

}
