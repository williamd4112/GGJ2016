using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {

    [SerializeField]
    private float m_Delay = 1.0f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, m_Delay);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
