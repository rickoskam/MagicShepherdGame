using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	float speed = 30;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

			transform.Rotate (new Vector3 (0, speed * Time.deltaTime * Input.GetAxis ("Mouse X")));
	}

    public void NaarLevel1()
    {
         Application.LoadLevel("Level1");
    }

    public void NaarLevel2()
    {
        Application.LoadLevel("Level2woestijn");
    }

    public void NaarLevel3()
    {
        Application.LoadLevel("Level3");
    }
}
