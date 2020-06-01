using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public GameObject Player;
    public GameObject Enemy;
    public bool attackTrigger = false;
    public bool isAttacking = false;
    public float speed = 0.01f;
    int HurtGen;
    public AudioSource Hurt1;
    public AudioSource Hurt2;
    public AudioSource Hurt3;
	// Update is called once per frame
	void Update () {
        transform.LookAt(Player.transform);
        if (EnemyDeath.EnemyHealth <= 0) {
            this.enabled = false;
        }
        

        if (isAttacking == false && attackTrigger == true)
        {
            speed = 0;
            Enemy.GetComponent<Animation>().Play("attack");
            StartCoroutine(InflictDamage());
        }
        if(attackTrigger == false) {
            speed = 0.01f;
            Enemy.GetComponent<Animation>().Play("walk");
            transform.position = Vector3.MoveTowards(transform.position,Player.transform.position,speed);
        }

		
	}

    void OnTriggerEnter() {
        attackTrigger = true;
    }

    void OnTriggerExit()
    {
        attackTrigger = false;
    }

    IEnumerator InflictDamage() {
        isAttacking = true;
        if (HurtGen == 1)
        {
            Hurt1.Play();
        }
        else if (HurtGen == 2)
        {
            Hurt2.Play();
        }
        else
        {
            Hurt3.Play();
        }
        yield return new WaitForSeconds(1.3f);
        PlayerHealth.GlobalHealth -= 10;
        HurtGen = Random.Range(1, 4);
        
        isAttacking = false;
    }
}
