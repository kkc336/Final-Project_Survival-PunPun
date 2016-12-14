using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCenter : MonoBehaviour {

	public GameObject unitA;
	public GameObject unitB;
	public float camSpd = 3f;
	public float offsetY=10f;
	public float height = 50f;

	void Start () {

	}
	

	void FixedUpdate () {
		if(GameObject.Find("unit1") != null && GameObject.Find("unit2") != null){
			Center_AB ();
			//print ("ok");
		}else{
			print ("lost");
		}

	}



	void Center_AB(){
		float dist = Vector3.Distance (unitA.transform.position, unitB.transform.position);
		Vector3 center = (unitA.transform.position + unitB.transform.position) / 2f;

		float journeySpd = camSpd * Time.deltaTime / dist;

		if (dist < height) {
			this.gameObject.transform.position = Vector3.Lerp (this.gameObject.transform.position, center + new Vector3 (0f, dist + offsetY, 0f), journeySpd);
	
		} else if (dist >= height) {
			dist = height;
			this.gameObject.transform.position = Vector3.Lerp (this.gameObject.transform.position, center + new Vector3 (0f, dist, 0f), journeySpd);
			//this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, new Vector3(15f,dist ,-15f), journeySpd);
		} else {
			this.gameObject.transform.position = Vector3.Lerp (this.gameObject.transform.position, center + new Vector3 (0f, dist + offsetY, 0f), journeySpd);
		}
		//print (dist);

	}









}
