using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	[Header("Bullet_Properties")]
	public float Speed;
	public float Damage;
	public GameObject Effect;
	public float radius;
	public LayerMask Mask;
	Collider2D[] HitGO;
	Animator anim;
	// Start is called before the first frame update
	void Start()
	{

		anim = Camera.main.GetComponent<Animator>();
		//HitGO = Physics2D.OverlapCircleAll(transform.position, radius, Mask);
		//foreach (Collider2D HitObject in HitGO)
		//{
		//	if (HitObject.gameObject.GetComponent<Stats>() != null)
		//	{
		//		HitObject.gameObject.GetComponent<Stats>().Damage(Damage);
		//		if (HitObject.gameObject.GetComponent<Rigidbody2D>() != null)
		//		{
		//			HitObject.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 1000f);
		//		}
		//	}

		//	Instantiate(Effect, transform.position, Quaternion.identity);
		//	Destroy(gameObject);
		//}
	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(Vector3.right * Speed * Time.deltaTime);

		//HitGO = Physics2D.OverlapCircleAll(transform.position, radius, Mask);
		//foreach (Collider2D HitObject in HitGO)
		//{
		//	if (HitObject.gameObject.GetComponent<Stats>() != null)
		//	{
		//		HitObject.gameObject.GetComponent<Stats>().Damage(Damage);
		//		if (HitObject.gameObject.GetComponent<Rigidbody2D>() != null)
		//		{
		//			HitObject.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 1000f);
		//		}
		
		//	}

		//	Instantiate(Effect, transform.position, Quaternion.identity);
		//	Destroy(gameObject);
		//}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag != "Player" && col.tag != "Bullet")
		{
			Debug.Log("Ok");
			if (col.gameObject.GetComponent<Stats>() != null)
			{
				Stats Stat = col.gameObject.GetComponent<Stats>();
				Stat.Damage(Damage);
				if (col.gameObject.GetComponent<Rigidbody2D>() != null)
				{
					col.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 1000f);
				}
			}
			Instantiate(Effect, transform.position, Quaternion.identity);
			anim.SetTrigger("Shake");
			Destroy(gameObject);
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
