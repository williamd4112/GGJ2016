using UnityEngine;
using System.Collections;

namespace CompleteProject
{
	public class EnemyMovement : MonoBehaviour
	{
		GameObject player;               // Reference to the player's position.
		NavMeshAgent nav;               // Reference to the nav mesh agent.
        float originSpeed;
		
		void Awake ()
		{
            // Set up the references.
            player = GameObject.Find("Player");
			nav = GetComponent <NavMeshAgent> ();
            originSpeed = nav.speed;
		}
		
		
		void Update ()
		{
			// If the enemy and the player have health left...

				// ... set the destination of the nav mesh agent to the player.
			nav.SetDestination (player.transform.position);
            nav.speed = originSpeed;

		}
	}
}