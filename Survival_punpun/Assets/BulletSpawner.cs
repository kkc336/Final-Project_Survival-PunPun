using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {

	public static GameObject[] all_Players;

	public Rigidbody bulletPrefab;
	public Transform p1_Pos;
	public Transform p2_Pos;

	public float power = 100f;
	//1 = p1/2 = p2
	public int playerTurn = 1;

	public static float intervalTime = 5f;



	void Start () {
		
		all_Players = GameObject.FindGameObjectsWithTag ("Player");
		if(all_Players != null && playerTurn > 0){
			//check who start first
			DecideTurn ();
			print ("player join " + all_Players.Length);
		}
	}




	public virtual void DecideTurn(){
		if(all_Players.Length == 2){
			
			if (playerTurn == 1) {
			
				//InvokeRepeating ("Attack_P1", 2f, 10f);
				Invoke ("Attack_P1", intervalTime);
			} 

			else if (playerTurn == 2) {
			
				//InvokeRepeating ("Attack_P2", 2f, 10f);
				Invoke ("Attack_P2", intervalTime);
			} 
				
		}
		else {
			print ("DecideStartTurn Error");
		}
	}

//------------------------------------------------------------------------------------------------

	void Update(){
		


	}



	void Attack_P1(){
		if (playerTurn == 1) {
			if (all_Players.Length == 2 && GameObject.Find("unit1") != null) {
				Vector3 dir = p1_Pos.position - this.gameObject.transform.position;
			

				Rigidbody rb = Instantiate (bulletPrefab, transform.position, transform.rotation) as Rigidbody;
				rb.AddForce (dir * power);

				TurnEnd_P1 ();
			}
		} else {
			print ("atk_p1 error");
		}

	}



	void Attack_P2(){
		if (playerTurn == 2) {
			if (all_Players.Length == 2 && GameObject.Find("unit2") != null) {
				Vector3 dir = p2_Pos.position - this.gameObject.transform.position;
			

				Rigidbody rb = Instantiate (bulletPrefab, transform.position, transform.rotation) as Rigidbody;
				rb.AddForce (dir * power);

				TurnEnd_P2 ();
			} else {
				print ("atk_2 error");
			}
		}
	}



	void TurnEnd_P1(){
		//change turn
		playerTurn = 2;
		//check who's next
		DecideTurn ();
	}



	void TurnEnd_P2(){
		//change turn
		playerTurn = 1;
		//check who's next
		DecideTurn ();
	}




}
