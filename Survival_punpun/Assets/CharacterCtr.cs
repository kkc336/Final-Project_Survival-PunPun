using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtr : MonoBehaviour {
	
	//character speed
	public float speed;
	//keyboard input
	public KeyCode up;
	public KeyCode down;
	public KeyCode right;
	public KeyCode left;
	private Rigidbody rb;




	void Start () {
		rb = GetComponent<Rigidbody> ();
	}


	void FixedUpdate () {
		float timeAdjustSpeed = speed * Time.deltaTime;

		MoveByKey (up ,new Vector3(0f ,0f ,timeAdjustSpeed));
		MoveByKey (down ,new Vector3(0f ,0f ,-timeAdjustSpeed));
		MoveByKey (right ,new Vector3(timeAdjustSpeed ,0f ,0f));
		MoveByKey (left ,new Vector3(-timeAdjustSpeed ,0f ,0));

	}


	void MoveByKey(KeyCode key, Vector3 movement){
		if (Input.GetKey (key)) {
			transform.LookAt (transform.position + movement);
			//this.gameObject.transform.position = transform.position += movement;
			rb.MovePosition (transform.position += movement);

		}
	}
}
