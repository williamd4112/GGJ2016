using UnityEngine;
using System.Collections;

public class Hearts : MonoBehaviour {

	public static Hearts Instance;
	public GameObject[] heart;
	int index;

	public BlockFontText ScoreText;
	int score;

	public BlockFontText ComboText;
	float timecount;
	float timelimit = 1f;
	int combo;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < heart.Length; i++) {
			heart [i].SetActive (true);
		}
		index = 4;
		score = 0;
		combo = 0;
		timecount = 0;
	}

	void Awake(){
		Instance = this;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space))
			GetScore ();
		if (combo >= 1) {
			timecount += Time.deltaTime;
			if (timelimit - timecount <= 0.00001f) {
				timecount = 0;
				combo = 0;
				ComboText.text = "";
			}
		}
	}

	public void Dmg(){
        if(index < 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

		heart [index].SetActive (false);
        index--;
	}

	public void GetScore(){
		score++;
		ScoreText.text = score.ToString ();
		combo++;
		timecount = 0;
		if (combo >= 2)
			ComboText.text = combo.ToString () + " COMBO!";
	}
}
