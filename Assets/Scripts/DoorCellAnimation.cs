using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorCellAnimation : MonoBehaviour {

    public float DistancePlayerDoor; //It will reference the public variable from PlayerCasting Script.
    public GameObject PromptOpenDoor; //It holds the prompt text.
    public GameObject DoorRotationPoint; //It holds the animation.
    public AudioSource CreakSound;

	void Update () {
        DistancePlayerDoor = PlayerCasting.DistanceFromPlayer;
	}

    void OnMouseOver()
    {
        if (DistancePlayerDoor <= 1.4)
        {
            PromptOpenDoor.SetActive(true);
            if (Input.GetButtonDown("Action"))
            {
                PromptOpenDoor.SetActive(false);
                DoorRotationPoint.GetComponent<Animation>().Play("DoorAnimOpen");

                this.GetComponent<BoxCollider>().enabled = false;
                

                CreakSound.Play();
            }

        }
        if(DistancePlayerDoor > 1.4) {
            PromptOpenDoor.SetActive(false);
        }
    }

    void OnMouseExit() {
        PromptOpenDoor.SetActive(false);
    }
}
