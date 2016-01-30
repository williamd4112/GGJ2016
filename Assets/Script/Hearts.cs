using UnityEngine;
using System.Collections;

public class Hearts : MonoBehaviour {

	public static Hearts Instance;
	public GameObject[] heart;

	public BlockFontText ScoreText;
	int score;

	int index;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < heart.Length; i++) {
			heart [i].SetActive (true);
		}
		index = 4;
		score = 0;
	}

	void Awake(){
		Instance = this;
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Dmg(){
		heart [index].SetActive (false);
		index--;
	}

	public void GetScore(){
		score++;
		ScoreText.text = score.ToString ();
	}
}
