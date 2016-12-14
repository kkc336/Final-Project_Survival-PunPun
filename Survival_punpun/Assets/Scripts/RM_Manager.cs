using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RM_Manager : MonoBehaviour {

	public GameObject[] rooms = new GameObject[14];
	public int interval_num = 10;



	private Vector3[,] spawnGrid = new Vector3[4,4];


	void SpawnGrid(){
		int x = 0;
		int z = 0;

		for (int i = 0; i < 4; i++) {

			for (int j = 0; j < 4; j++) {
				spawnGrid [i, j] = new Vector3 (x , 0, z);
				int r = Random.Range (0, 14);
				Instantiate (rooms[r],new Vector3(x , 0 ,z), transform.rotation);
				z -= interval_num;
			}
			x += interval_num;
			z = 0;
			print (x +""+z);

		}
	}


	void Start () {
		SpawnGrid ();
		/*int x = 0;
		int y = 0;

		foreach(GameObject room in rooms){
			//for(int i =0; i < rooms.Length; i++){
			x += x_interval;
			//}
		
			Instantiate (room,transform.position +new Vector3(x , 0 ,0), transform.rotation);
			
		}*/
	}
	

	void Update () {
		
	}
}
