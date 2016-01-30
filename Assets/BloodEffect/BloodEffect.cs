using UnityEngine;
using System.Collections;

public class BloodEffect : MonoBehaviour {
	private CanvasRenderer[] childIma;
	[SerializeField]
	private float fadingTime = 1.0f;
	[SerializeField]
	private bool isHurt = false;
	[SerializeField]
	private bool hurting = false;
	[SerializeField]
	private float startTime;
	[SerializeField]
	private float fadAlpha;
	// Use this for initialization
	void Start () {
		childIma = this.gameObject.GetComponentsInChildren<CanvasRenderer> ();
		foreach (CanvasRenderer cr in childIma) {
			cr.SetAlpha (0f);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float tempAlpha;
		if (isHurt) {
			isHurt = false;
			hurting = true;
			foreach (CanvasRenderer cr in childIma) {
				cr.SetAlpha (1f);
			}
			startTime = Time.time;
		} else {
			if (hurting) {
				fadAlpha = (Time.time - startTime) / fadingTime;
				tempAlpha = Mathf.Lerp (1, 0, fadAlpha);
				//Debug.Log ("tempAlpha =" + tempAlpha);
				foreach (CanvasRenderer cr in childIma) {
					cr.SetAlpha (tempAlpha);
				}
				if (tempAlpha == 0) {
					hurting = false;
				}
			}
		}
	}

	public void HurtIt(){
		isHurt = true;
	}
		
}
