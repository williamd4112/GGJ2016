using UnityEngine;
using System.Collections;

public class Hearts : MonoBehaviour {

	public static Hearts Instance;
	public GameObject[] heart;

	int index;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < heart.Length; i++) {
			heart [i].SetActive (true);
		}
		index = 4;
	}

	void Awake(){
		Instance = this;
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Dmg(){
        if(index < 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

		heart [index].SetActive (false);
        index--;
	}
}
