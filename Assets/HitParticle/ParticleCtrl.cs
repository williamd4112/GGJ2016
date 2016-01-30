using UnityEngine;
using System.Collections;

public class ParticleCtrl : MonoBehaviour {

	private ParticleSystem thisPart;
	// Use this for initialization
	void Awake(){
		thisPart = this.gameObject.GetComponent<ParticleSystem> ();
		thisPart.Stop ();
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnHit(){
		thisPart.Play ();
	}

	public void Onleave(){
		thisPart.Stop ();
	}
}
