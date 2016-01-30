using UnityEngine;
using System.Collections;


public class TestScaleTween : MonoBehaviour {
	[SerializeField]
	private float scales = 2.0f;
	[SerializeField]
	private float dur = 1.5f;
	private float startTime;
	[SerializeField]
	private int angl;
	// Use this for initialization
	void Start () {
		LeanTween.scale (this.gameObject, new Vector3 (scales, scales, scales), dur);
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float t = (Time.time - startTime) / dur;
		float temp = Mathf.SmoothStep (0, 1, t);
		this.GetComponent<_2dxFX_Additive> ()._Alpha = temp;
		this.transform.Rotate (new Vector3 (0, 0, angl) * Time.deltaTime);

	}
}
