using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	//public static GameManager GM = null;
	public Transform p1;
	public Transform p2;

	public string sceneName;


	void Start () {
		
	}
	

	void Update () {
		Lose ();
	}

	void Win(){
	
	}

	void Lose(){
		if(p1.position.y < - 20f){
			print ("p1 KO");
			SceneManager.LoadScene (sceneName);
		}

		if(p2.position.y < - 20f){
			print ("p2 KO");
			SceneManager.LoadScene (sceneName);
		}
	}
}
