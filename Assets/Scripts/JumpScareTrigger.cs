using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JumpScareTrigger : MonoBehaviour {

    public GameObject Enemy;
    public AudioSource DoorBang;
    public AudioSource ChaseMusic;
    public GameObject Door1;
    public GameObject ScareTrigger;
    public GameObject Door1Collider;
    public GameObject OpeningSong;
    public GameObject TextBox;
    public GameObject DialogTrigger;


    void OnTriggerEnter() {
        ScareTrigger.SetActive(false);
        Door1.GetComponent<Animation>().Play("JumpDoorAnim");
        DoorBang.Play();
        Enemy.active = true;
        Door1Collider.SetActive(false);
        ChaseMusic.Play();
        DialogTrigger.GetComponent<JumpScareDialog>().TriggerDialog();     

    }

    
}

   

   

