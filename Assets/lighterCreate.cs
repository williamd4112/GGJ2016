using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lighterCreate : MonoBehaviour {
	public GameObject spark;
	public GameObject light;
	public GameObject candleFire;
	public GameObject fireLight;
	public GameObject button;
	GameObject cam;
	public GameObject blackPanel;
	public GameObject title;

	public GameObject sound;

	int c = 0;
	//int a = 0;
	bool changeScene = false;
	bool black = false;
	bool canLit = true;
	// Use this for initialization
	void Start () {
		candleFire.SetActive (false);
		button.SetActive (false);
		cam = GameObject.Find ("Main Camera");

	}
	
	// Update is called once per frame
	void Update () {
		for (var i = 0; i < Input.touchCount; ++i) {
			if (Input.GetTouch (i).phase == TouchPhase.Began && canLit) {
				Instantiate (spark, new Vector3 (0, 0, -7), Quaternion.identity);
				Instantiate (light, new Vector3 (0, 0, 0), Quaternion.identity);
			
				sound.GetComponent<AudioSource> ().Play ();
				

				c++;
			}

		}
		if (c == 5) {
			candleFire.SetActive (true);
			canLit = false;
		}
		if (!canLit && cam.transform.position.y<2.5f) {
			cam.transform.position += new Vector3 (0, 0.02f, 0);
		}
		if (!canLit && cam.transform.position.y>=2.5f) {
			button.SetActive (true);
		}
		if (!canLit) {
			title.GetComponent<Text> ().color += new Color32 (0, 0, 0, 1);
		}
		if (black) {
			//a++;
			blackPanel.GetComponent<Image> ().color += new Color32(0, 0, 0, 2);
			if (blackPanel.GetComponent<Image> ().color.a == 255) {
				changeScene = true;
			}
		} 
		if (changeScene) {
			//change the scene here.
		}
	}

	public void click(){
		Destroy (fireLight);
		candleFire.GetComponent<ParticleSystem> ().Stop ();
		black = true;

        
	}
}
