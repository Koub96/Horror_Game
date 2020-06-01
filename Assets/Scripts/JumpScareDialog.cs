using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JumpScareDialog : MonoBehaviour {
    public GameObject TextBox;

    public void TriggerDialog() {
        StartCoroutine(ShowDialog());        

    }

    IEnumerator ShowDialog()
    {
        TextBox.GetComponent<Text>().text = "What the fuck is that thing ?!";
        TextBox.SetActive(true);
        yield return new WaitForSeconds(3f);
        TextBox.SetActive(false);
    }
}
