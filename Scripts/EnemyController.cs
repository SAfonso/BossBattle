using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyController : MonoBehaviour {

	public static EnemyController instance;

	// Damage values
	public float amplitud = 2f;
	public float weakPointDamage = 10f;
	public float armDamage = 5f;
	public float enemyDamage = 2f;
	public bool isMoving = false;
	public bool pickUp;

	// Weapons coldown
	public float weaponTimeToShoot;
    public float weaponShootingRate;
	public float clawTimeToShoot;
    public float clawShootingRate;
	public float misileTimeToShoot;
    public float misileShootingRate;


	private Vector3 _startPosition;

	// Weapons
	private EnemyHealth health;
	private ArmScript arm;
	private ArmScript armTwo;
	private ShooterScript weaponOne;
	private MisileScript misileLauncher;
    private GameObject cuerpoBoss;
	private int moveClaw;

    private Animator anim;

    private bool canShoot;


	void Awake(){
		if (instance == null){
			instance = this;
		}else if (instance!= this){
			Destroy(this);
		}
		
	}

	// Use this for initialization
	void Start () {
		// Get the weapons
		weaponOne = GameObject.FindGameObjectWithTag("FrontalCannon").GetComponent<ShooterScript>();
        cuerpoBoss = GameObject.FindGameObjectWithTag("FrontalCannon") as GameObject;
        anim = gameObject.GetComponent<Animator>();

        canShoot = true;

		arm = this.transform.GetChild(1).GetComponent<ArmScript>();
		armTwo = this.transform.GetChild(2).GetComponent<ArmScript>();
		//misileLauncher = this.transform.GetChild(4).GetComponent<MisileScript>();
		
		instance.isMoving = true;
		_startPosition = transform.position;
		health = this.gameObject.GetComponent<EnemyHealth>();
		pickUp = true;
		weaponTimeToShoot = Time.time + weaponShootingRate;
		clawTimeToShoot = Time.time + clawShootingRate;
		misileTimeToShoot = Time.time + misileShootingRate;

	}

	public void SetStartPosition(Vector3 position){
		// Reset the start position after first secuence end
		_startPosition = position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameManager.instance.isOnSecuence){
			if((Time.time >= weaponTimeToShoot) && canShoot){
				weaponTimeToShoot = Time.time + weaponShootingRate;
                int rotation = Random.Range(-15, 15);
                cuerpoBoss.transform.rotation = Quaternion.Euler(0, 0, rotation);
                weaponOne.ShootWeapon();
            }
			if((Time.time >= clawTimeToShoot)){
                canShoot = false;
                //cuerpoBoss.transform.rotation = Quaternion.identity;
                clawTimeToShoot = Time.time + clawShootingRate;
                StartCoroutine("EnableShooting");
                anim.SetTrigger("shootClaw");
			}
		}

	}

	public void ShootTheArms(){
		//arm.ShootArm();
		armTwo.ShootArm();
	}

	public void ShootTheMisile(){
		misileLauncher.ShootMisile();
	}

	public void TakeDamage(int damage){
		health.TakeDamage(damage);
	}

    private IEnumerator EnableShooting() {     
        yield return new WaitForSeconds(4.0f);
        this.canShoot = true;
    }


}
