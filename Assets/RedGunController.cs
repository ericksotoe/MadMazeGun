using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGunController : MonoBehaviour {

    public GameObject newMat;
    public Texture green;
    public Texture white;
    public Texture blue;
    public Texture red;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // do if statements and change color depednig on color pickup
        newMat.GetComponent<MeshRenderer>().material.SetTexture("_EmmisionMap", green);
		
	}
}
