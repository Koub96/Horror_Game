using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour {

	void Update () {
        Ray r = new Ray(transform.position,transform.forward);
        Debug.DrawRay(r.origin, r.direction, Color.blue);
	}
}
