using UnityEngine;
using System.Collections;

public class EnemyMaker : MonoBehaviour {

	public GameObject point1;
	public GameObject point2;

	public GameObject enemy;

	float timelimit = 1f;
	float timecount;

	// Use this for initialization
	void Start () {
		timecount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timecount += Time.deltaTime;
		if (timelimit - timecount <= 0.00001f) {
			float xpos = point1.transform.position.x + Random.value * (point2.transform.position.x - point1.transform.position.x);
			float zpos = point1.transform.position.z + Random.value * (point2.transform.position.z - point1.transform.position.z);
			Vector3 newpos = new Vector3 (xpos, 0, zpos);
			GameObject newenemy = Instantiate (enemy, newpos, Quaternion.Euler (0, 0, 0)) as GameObject;
			timecount = 0;
		}
	}
}
