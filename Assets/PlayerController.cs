using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	private int countball = 1000000000;
	public GameObject banana;
	public Transform Luncher;
	
	public AudioSource shootingSound;


	// Use this for initialization
	void Start () {
		shootingSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire2")&& (countball>0)){
			GameObject throwThis = Instantiate (banana, Luncher.position,Luncher.rotation) as GameObject;
			throwThis.GetComponent<Rigidbody>().AddForce (Luncher.transform.forward * 1000f);
			countball--;
			shootingSound.Play();
		}
	}
}