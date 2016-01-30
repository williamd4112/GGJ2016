using UnityEngine;
using System.Collections;

public class BulletDam : MonoBehaviour {
	[SerializeField]
	private int DamageAmount = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.GetComponent<Damageable> ()) {
			other.gameObject.GetComponent<Damageable> ().OnHit (DamageAmount);
		}
		Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.GetComponent<Damageable> ()) {
			other.gameObject.GetComponent<Damageable> ().OnHit (DamageAmount);
		}
		Destroy (this.gameObject);
	}
}
