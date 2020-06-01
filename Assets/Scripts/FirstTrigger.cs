using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstTrigger : MonoBehaviour {

    AudioSource source;
    public GameObject TextBox;
    void Start() {
        
    }
   
    private void OnTriggerEnter()
    {
        
        StartCoroutine(ActivateDialog());
        

        
    }

    public IEnumerator ActivateDialog()
    {
        
        TextBox.GetComponent<Text>().text = "Is anybody here?! Please Help me..! Anyone...";
        TextBox.SetActive(true);
        this.GetComponent<BoxCollider>().isTrigger = false;
        this.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(4f);
        TextBox.SetActive(false);
    }
}
