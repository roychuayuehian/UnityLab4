using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMush : MonoBehaviour, ConsumableInterface
{
	public Texture t;
	public void consumedBy(GameObject player)
	{
		// give player jump boost
		player.GetComponent<CharacterController2D>().maxSpeed *= 2;
		player.transform.localScale = new Vector3(player.transform.localScale.x + 0.2f, player.transform.localScale.y + 0.2f, player.transform.localScale.z);

		StartCoroutine(removeEffect(player));
	}

	IEnumerator removeEffect(GameObject player)
	{
		yield return new WaitForSeconds(5.0f);
		player.GetComponent<CharacterController2D>().maxSpeed /= 2;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			// update UI
			Debug.Log("collide with green");
			CentralManager.centralManagerInstance.addPowerup(t, 1, this);

			Debug.Log("done with green");
			GetComponent<Collider2D>().enabled = false;
			Destroy(gameObject);
		}
	}
}
