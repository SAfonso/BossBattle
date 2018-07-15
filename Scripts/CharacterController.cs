using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterController : MonoBehaviour
{

    public static CharacterController instance;
    private Bullet newBullet;
    // Use this for initialization

    public float damagePerShoot = 5f;
    public float coolDown;
    public float coolDownTime;

    private PlayerHealth health;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }

    }

    void Start()
    {
        coolDownTime = Time.time;
        health = this.gameObject.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

        //Player control with touch controller
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).position.x < Screen.width / 2)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    this.transform.DOMoveY(3, 1);                   //If user touch the scrren on the left side, player fly to up
                }
                else if (Input.GetTouch(i).phase == TouchPhase.Ended || Input.GetTouch(i).phase == TouchPhase.Canceled)
                {
                    this.transform.DOMoveY(-3, 1);                  //Player down
                }
            }
            else if (Input.GetTouch(i).position.x > Screen.width / 2)
            {
                newBullet = BulletController.instance.PlayerShootABullet(); //If user touch in the right size, the player shoot. 
                newBullet.transform.DOMoveX(10, 1);
            }
        }

#if UNITY_EDITOR
        if (!GameManager.instance.isOnSecuence)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                this.transform.DOMoveY(3, 1);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                this.transform.DOMoveY(-3, 1);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Time.time >= coolDownTime)
                {
                    coolDownTime = Time.time + coolDown;
                    Bullet newBullet = BulletController.instance.PlayerShootABullet();
                    newBullet.transform.position = this.transform.position; //If user touch in the right size, the player shoot. 
                    newBullet.Move();
                }

            }
        }
#endif

    }

    public void TakeDamage()
    {
        health.TakeDamage(damagePerShoot);
    }
}
