using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float Speed;
	public float Damage;
	[HideInInspector] public float Anxiety;
	public GameObject Effect;
	public Animator anim;

	void Start()
	{
		anim = Camera.main.GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update()
	{
		transform.Translate(Vector3.right * Speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag != "Enemy")
		{
			if (col.gameObject.GetComponent<PlayerStats>() != null)
			{
				PlayerStats Stat = col.gameObject.GetComponent<PlayerStats>();
				Stat.TakeAwayMoney(Damage);
				Stat.AddAnxiety(Anxiety);
				Instantiate(Effect, transform.position, Quaternion.identity);
				Destroy(gameObject);
			}
			else if(col.tag == "Shield")
			{
				col.GetComponentInParent<Rigidbody2D>().AddForce(transform.right * 1000f);
			}
			Instantiate(Effect, transform.position, Quaternion.identity);
			//if(col.tag != "Envi")
			//{
			//	anim.SetTrigger("Shake");
			//}
			Destroy(gameObject);
		}

	}
}
