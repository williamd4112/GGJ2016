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
	[SerializeField]
	private float desTime = 3.0f;
	[SerializeField]
	private float desDur = 1.0f;
	[SerializeField]
	private GameObject flare;
	// Use this for initialization
	void Start () {
		LeanTween.scale (this.gameObject, new Vector3 (scales, scales, scales), dur).setEase(LeanTweenType.easeOutBack);
		startTime = Time.time;
		StartCoroutine ("Destroy");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float t = (Time.time - startTime) / dur;
		float temp = Mathf.SmoothStep (0, 1, t);
		this.GetComponent<_2dxFX_Additive> ()._Alpha = temp;
		this.transform.Rotate (new Vector3 (0, 0, angl) * Time.deltaTime);

	}

	IEnumerator Destroy(){
		yield return new WaitForSeconds (desTime);
		LeanTween.scale (this.gameObject, new Vector3 (0, 0, 0), desDur).setEase (LeanTweenType.easeInBack);
		Instantiate (flare, this.transform.position, Quaternion.identity);
	}
}
