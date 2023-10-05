using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletebanana : MonoBehaviour
{
    

	// Use this for initialization
	void Start () {

	}

	private void OnCollisionEnter( Collision hit){
		if (hit.gameObject.tag == "banana"){
			Destroy(hit.gameObject);
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
