using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour {
    public GameObject pistol;
    public GameObject MuzzleFlash;
    public GameObject Enemy;
    public AudioSource GunFire;
    public bool IsFiring;
    public float TargetDistance;
    public GameObject RayPoint;
    int DamageAmount = 10;
	void Update () {

        Ray r = new Ray(RayPoint.transform.position, transform.forward);
        //Debug.DrawRay(r.origin, r.direction, Color.blue); UNCOMMNENT THIS LINE TO SEE THE RAY CASTED.
	
        if (Input.GetButtonDown("Fire1")) {
            
            if (IsFiring == false && GlobalAmmo.ammoCount > 0) {
                GlobalAmmo.ammoCount -= 1;
                StartCoroutine(FireGun());
            }
        }
	}

    IEnumerator FireGun(){
        

        IsFiring = true;
        RaycastHit shot;
        Physics.IgnoreLayerCollision(11,10);


        if (Physics.Raycast(RayPoint.transform.position, transform.forward, out shot))
        {
            TargetDistance = shot.distance;

            if (TargetDistance <= 10 && shot.collider.gameObject.name == "Zombie")
            {

                Debug.Log("Enemy was hit!");
                Enemy.GetComponent<EnemyDeath>().DamagedEnemy(DamageAmount);

            }
        }

        
        pistol.GetComponent<Animation>().Play("PistolFire");
        MuzzleFlash.SetActive(true);
        MuzzleFlash.GetComponent<Animation>().Play("MuzzleFlash");
        GunFire.Play();
        yield return new WaitForSeconds(0.5f);


        IsFiring = false;
    }
}
