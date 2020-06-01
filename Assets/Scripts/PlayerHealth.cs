using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public static int GlobalHealth = 30;
    public int InternalHealth;
	
	// Update is called once per frame
	void Update () {
        InternalHealth = GlobalHealth;
        if (InternalHealth <= 0) {
            SceneManager.LoadScene(1);
        }
	}
}
