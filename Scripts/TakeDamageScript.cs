using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageScript : MonoBehaviour {

    public int damage;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet")) {
            EnemyController.instance.TakeDamage(damage);
            other.transform.GetChild(0).gameObject.SetActive(true);
            other.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
            StartCoroutine(CallEnemyBullet(other.gameObject));
            StartCoroutine("TurnRed");
        }
        
    }

    private IEnumerator CallEnemyBullet(GameObject other){
        
        yield return new WaitForSeconds(0.2f);
        BulletController.instance.PlayerBulletEnd(other.gameObject.GetComponent<Bullet>());
    }

    private IEnumerator TurnRed() {
        Debug.Log("Hola");
        spriteRenderer.color = Color.red;
        Debug.Log(spriteRenderer.color);
        yield return new WaitForSeconds(0.5f);
        //spriteRenderer.color = Color.white;
        yield return null;
    }
}
