using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

	private Rigidbody rb;
	public float radius = 15f;
	public float power = 100f;
	public GameObject particle;
	public GameObject shatterPrefab;

	public float timer = 5f;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	

	void Update () {

		if (timer > 0) {
			timer -= 1 * Time.deltaTime;

		} else if(timer == 0) {
			Instantiate (particle, this.gameObject.transform.position, this.gameObject.transform.rotation);
			Destroy (this.gameObject,1f);
		}
			
		
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject){
			Instantiate (particle, this.gameObject.transform.position, this.gameObject.transform.rotation);

			if(col.gameObject.tag != "Player" && col.gameObject.tag != "Shatter"){
			Destroy (col.gameObject);
				Instantiate (shatterPrefab, col.gameObject.transform.position, col.gameObject.transform.rotation);

			}

			//destroy bomb
			Destroy (this.gameObject,1f);
		}

		if(col.gameObject.tag == "Player"){
			//Instantiate (particle, this.gameObject.transform.position, this.gameObject.transform.rotation);

			//gameObject.AddComponent <HingeJoint>();
			//gameObject.GetComponent<HingeJoint> ().connectedBody = col.rigidbody;

			//rb.AddForce (Vector3.up * 5000f);
			rb.AddExplosionForce (power, this.gameObject.transform.position  + new Vector3(0, -10f, 0), radius);
			Destroy (this.gameObject,1f);



		}


	}

}
