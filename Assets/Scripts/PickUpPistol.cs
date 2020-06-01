using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpPistol : MonoBehaviour {

    public float DistancePlayerPistol; //It will reference the public variable from PlayerCasting Script.
    public GameObject PromptTakePistol; //It holds the prompt text.
    public GameObject FakePistol;
    public GameObject POVPistol;
    public GameObject JumpScareTrigger;
    public AudioSource PistolPickUpSound;
    public GameObject AmmoPanel;


	void Update () {
        DistancePlayerPistol = PlayerCasting.DistanceFromPlayer;
	}

    void OnMouseOver()
    {
        if (DistancePlayerPistol <= 1.9)
        {
            PromptTakePistol.GetComponent<Text>().text = "[E]\nPick up.";
            PromptTakePistol.SetActive(true);
            if (Input.GetButtonDown("Action"))
            {
                PromptTakePistol.SetActive(false);
                this.GetComponent<BoxCollider>().enabled = false;
                FakePistol.SetActive(false);
                POVPistol.SetActive(true);
                PistolPickUpSound.Play();
                JumpScareTrigger.SetActive(true);
                GlobalAmmo.ammoCount = 10;
                AmmoPanel.SetActive(true);

            }

        }
        if(DistancePlayerPistol > 1.9) {
            PromptTakePistol.SetActive(false);
        }
    }

    void OnMouseExit() {
        PromptTakePistol.SetActive(false);
    }
}
