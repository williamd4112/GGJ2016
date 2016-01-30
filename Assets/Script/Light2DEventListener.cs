using UnityEngine;
using System.Collections;

public class Light2DEventListener : MonoBehaviour {

    private int id;

	// Use this for initialization
	void Start () {
        id = gameObject.GetInstanceID();

        Light2D.RegisterEventListener(LightEventListenerType.OnEnter, OnLightEnter);
        Light2D.RegisterEventListener(LightEventListenerType.OnStay, OnLightStay);
        Light2D.RegisterEventListener(LightEventListenerType.OnExit, OnLightExit);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnLightEnter(Light2D l, GameObject o)
    {
        if(o.GetInstanceID() == id)
        {
            Debug.Break();
        }
    }

    void OnLightStay(Light2D l, GameObject o)
    {
        if (o.GetInstanceID() == id)
        {

        }
    }

    void OnLightExit(Light2D l, GameObject o)
    {
        if (o.GetInstanceID() == id)
        {

        }
    }
}
