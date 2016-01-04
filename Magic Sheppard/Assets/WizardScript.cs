using UnityEngine;
using System.Collections;

public class WizardScript : MonoBehaviour {
	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D)) {
			animator.SetBool ("Lopen", true);
		} 
		else {
			animator.SetBool ("Lopen", false);
		}
	}
}
