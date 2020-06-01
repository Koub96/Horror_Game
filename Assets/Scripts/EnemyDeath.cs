using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {
    public static int EnemyHealth = 30;
    public GameObject Enemy;
    public GameObject Box;
    public AudioSource ChaseMusic;
    public int StatusCheck;

    public void DamagedEnemy(int damage) {
        EnemyHealth -= damage;
    }
    void Update () {
        if (EnemyHealth <= 0 && StatusCheck == 0) {
            StatusCheck = 2;
            Enemy.GetComponent<Animation>().Stop("walk");
            Enemy.GetComponent<Animation>().Play("fallingback");
            Box.GetComponent<CapsuleCollider>().enabled = false;
            ChaseMusic.Stop();
            

        }
	}
}
