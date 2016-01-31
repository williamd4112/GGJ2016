using UnityEngine;
using System.Collections;

public class MagicSlow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
            if (other.CompareTag("Enemy"))
            {
                NavMeshAgent agent = other.GetComponent<NavMeshAgent>();
                if (agent != null)
                {
                    agent.speed = 0;
                }
            }
  
    }
}
