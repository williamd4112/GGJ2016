using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    private static string s_ToLoadLevelName = "Stage1";

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void LoadLevel(string name)
    {
        s_ToLoadLevelName = name;

    }
}
