using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PickUpNote : MonoBehaviour {

    public float DistancePlayerNote; //It will reference the public variable from PlayerCasting Script.
    public GameObject PromptTakeNote; //It holds the prompt text.
    public GameObject note;
    public GameObject Player;
    public GameObject TextBox;
    public AudioSource PickUpNoteSound;


	void Update () {
        DistancePlayerNote = PlayerCasting.DistanceFromPlayer;
	}

    void OnMouseOver()
    {
        if (DistancePlayerNote <= 2)
        {
            
            PromptTakeNote.GetComponent<Text>().text = "[E]\nPick up Note.";
            PromptTakeNote.SetActive(true); 
            if (Input.GetButtonDown("Action"))
            {
                this.GetComponent<BoxCollider>().enabled = false;
                note.SetActive(false);
                StartCoroutine(ShowNoteContent());

            }

        }
        if(DistancePlayerNote > 2) {
            PromptTakeNote.SetActive(false);
        }
    }

    public IEnumerator ShowNoteContent()
    {
        Player.GetComponent<FirstPersonController>().enabled = false;
        TextBox.GetComponent<Text>().text = "There is a note on this table..\nIt has a number written on it: 8 5 12 16.\n";
        TextBox.SetActive(true);
        PickUpNoteSound.Play();
        yield return new WaitForSeconds(5f);
        TextBox.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        
    }

    void OnMouseExit() {
        PromptTakeNote.SetActive(false);
    }
}
