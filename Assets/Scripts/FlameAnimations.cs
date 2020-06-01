using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAnimations : MonoBehaviour {

    public int LightMode;
    public GameObject FlameLight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (LightMode == 0) {
            StartCoroutine(AnimateLight());  //The StartCoroutine function allows us to run a function that can be paused for several seconds at any point...
        }
	}

    
    public IEnumerator AnimateLight() {
        LightMode = Random.Range(1,4);

        FlameLight.GetComponent<Animation>().Play("TorchAnim" + LightMode); 
        yield return new WaitForSeconds(0.9f);  //...This is helpful when you want your function to wait for an Animation to finish before moving on.

        LightMode = 0;
    }
}
