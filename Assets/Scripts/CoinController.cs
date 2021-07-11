using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		// check if it collides with Mario
		if (other.gameObject.tag == "Player")
		{
			CentralManager.centralManagerInstance.increaseScore();
			Destroy(gameObject);
		}
	}
}