using UnityEngine;
using System.Collections;

public class GhostOnHit : MonoBehaviour {

	[SerializeField]
	private bool isHit = false;
	[SerializeField]
	private bool isFirst = true;
	[SerializeField]
	private ParticleSystem m_HitEffect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isHit) {
			if (isFirst) {
				isFirst = false;
				m_HitEffect.Play ();
			}
		}
	
	}

	public void LightHit(){
		isHit = true;
	}

	public void LightLeave(){
		
	}
}
