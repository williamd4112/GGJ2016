using UnityEngine;
using System.Collections;

public class BulletShoot : MonoBehaviour {
	[SerializeField]
	private GameObject m_Bullet;
	[SerializeField]
	private float shootTime = 2.0f;
	//[SerializeField]
	private bool isShooting = true;
	[SerializeField]
	private float bulSpeed = 1.0f;
	private GameObject myOwnBul;
	private bool shooting = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isShooting) {
			StartCoroutine ("startShoot");
			isShooting = false;
		}
		if (shooting) {
			shooting = false;
			myOwnBul = Instantiate (m_Bullet, this.transform.position, this.transform.rotation) as GameObject;
			myOwnBul.GetComponent<Rigidbody> ().velocity = this.transform.forward * bulSpeed;
			isShooting = true;
		}
	}

	IEnumerator startShoot(){
		yield return new WaitForSeconds (shootTime);
		shooting = true;
	}

}
