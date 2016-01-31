using UnityEngine;
using System.Collections;

public class lighter : MonoBehaviour {
	//Vector3 pos = new Vector3(0,0,0);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = this.GetComponent<Transform> ().position-new Vector3(0,0,0.7f);
		this.GetComponent<Transform> ().position = pos;
		if (this.GetComponent<Transform> ().position.z <= -50)
			Destroy (this.gameObject);
	}
}
