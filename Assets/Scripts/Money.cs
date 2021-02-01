using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
	[HideInInspector] public float Value;
	[HideInInspector] public float RePayAddOn;

	public GameObject effect;
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			col.gameObject.GetComponent<PlayerStats>().AddMoney(Value);

			Instantiate(effect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
