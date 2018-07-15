using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public static BulletController instance;

	[SerializeField] private List<Bullet> playerBulletList;
	public List<Bullet> recuperablePlayerBulletList;
	[SerializeField] private List<EnemyBullet> enemyBulletList;
	public List<EnemyBullet> recuperableEnemyBulletList;
	

	void Awake(){
		if (instance == null){
			instance = this;
		}else if (instance!= this){
			Destroy(this);
		}
		
	}
	// Use this for initialization
	void Start () {
		
	}
	
	public Bullet PlayerShootABullet(){
		Bullet bullet = null;
        if (instance.playerBulletList.Count > 0)
        {
            bullet = instance.playerBulletList[0];
            instance.playerBulletList.Remove(bullet);
            instance.recuperablePlayerBulletList.Add(bullet);
        }
		return bullet;
	}

	public void PlayerBulletEnd(Bullet bullet){
		instance.playerBulletList.Add(bullet);
        instance.recuperablePlayerBulletList.Remove(bullet);
	}

    public EnemyBullet EnemyShootABullet()
    {

        EnemyBullet bullet = null;
        if (instance.enemyBulletList.Count > 0) {
            bullet = instance.enemyBulletList[0];
            instance.enemyBulletList.Remove(bullet);
            instance.recuperableEnemyBulletList.Add(bullet);
        }
        return bullet;
    }

    public void EnemyBulletEnd(EnemyBullet bullet)
    {
        instance.enemyBulletList.Add(bullet);
        bullet.isMoving = false; 
        instance.recuperableEnemyBulletList.Remove(bullet);
    }
}
