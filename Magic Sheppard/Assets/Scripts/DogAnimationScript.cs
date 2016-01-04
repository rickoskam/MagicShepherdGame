using UnityEngine;
using System.Collections;

public class DogAnimationScript : MonoBehaviour {
	Animator animator;
	float speed1;
	float speed2;
	float speed3;
	float speed4;
	Vector3 lastPosition = Vector3.zero;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	void FixedUpdate()
	{
		//animator.SetBool ("Rondjes", HondScript.aan);
		speed1 = (transform.position - lastPosition).magnitude*1000;
		speed2 = (transform.position - lastPosition).magnitude*1000;
		speed3 = (transform.position - lastPosition).magnitude*1000;
		speed4 = (transform.position - lastPosition).magnitude*1000;
		float speed = (speed1 + speed2 + speed3 + speed4) / 4;
		lastPosition = transform.position;
			//animator.SetFloat ("Speed", speed);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
