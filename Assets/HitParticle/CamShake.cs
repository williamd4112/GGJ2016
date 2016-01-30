using UnityEngine;
using System.Collections;

public class CamShake : MonoBehaviour {

	public float shakeAmt = 5f; // the degrees to shake the camera
	public float shakePeriodTime = 0.42f; // The period of each shake
	public float dropOffTime = 1.6f; // How long it takes the shaking to settle down to nothing

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShakeAndBake(){
		LTDescr shakeTween = LeanTween.rotateAroundLocal (gameObject, Vector3.right, shakeAmt, shakePeriodTime)
			.setEase (LeanTweenType.easeShake) // this is a special ease that is good for shaking
			.setLoopClamp ()
			.setRepeat (-1);

		LeanTween.value (gameObject, shakeAmt, 0f, dropOffTime).setOnUpdate (
			(float val) => {
				shakeTween.setTo (Vector3.right * val);
			}
		).setEase (LeanTweenType.easeOutQuad);
	}
}
