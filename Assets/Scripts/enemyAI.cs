using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
	public GameObject target;
	public GameObject Bullet;
	public Transform ShootPos;

	public float moveSpeed;
	public float StoppingDistance;
	public float retreatDistance;
	public float TimeBetweenShootsValue = 0.5f;
	public float AttackRange;
	float TimeBetweenShoots;
	bool move = true;
	Rigidbody2D rb;
	public float radius;
	public float anxietyIncreaseAmount;
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		retreatDistance = StoppingDistance;

	}

	// Update is called once per frame
	void Update()
	{
		Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, radius);
		foreach (Collider2D e in col)
		{
			if (e.tag == "Enemy")
			{
				transform.position = Vector3.MoveTowards(transform.position, e.transform.position, -moveSpeed * Time.deltaTime);
			}
		}

		target = GameObject.FindGameObjectWithTag("Player");
		if (target != null)
		{
			EnemyMovement();
			if (TimeBetweenShoots <= 0 && (Vector3.Distance(transform.position, target.transform.position) <= AttackRange))
			{
				Shoot();
			}
			else
			{
				TimeBetweenShoots -= Time.deltaTime;
			}

			Vector2 dir = target.transform.position - ShootPos.position;
			float Rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			ShootPos.rotation = Quaternion.Euler(0, 0, Rot);
		}

	}

	#region Shooting
	void Shoot()
	{
		GameObject B = Instantiate(Bullet, ShootPos.position, ShootPos.rotation);
		B.GetComponent<Bullet>().Anxiety = anxietyIncreaseAmount;
		TimeBetweenShoots = TimeBetweenShootsValue;
	}
	#endregion

	#region Enemy Movement AI
	void EnemyMovement()
	{
		if (Vector3.Distance(transform.position, target.transform.position) < StoppingDistance)
		{
			move = false;
		}
		else
		{
			move = true;
		}
		if(move == true)
		{
			if (Vector3.Distance(transform.position, target.transform.position) > StoppingDistance && Vector3.Distance(transform.position, target.transform.position) > retreatDistance)
			{
				transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
			}
		}

		if (Vector3.Distance(transform.position, target.transform.position) < retreatDistance)
		{
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, -moveSpeed * Time.deltaTime);
		}
	}
	#endregion
	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, radius);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			GetComponent<Stats>().Deathbycollison = true;
			col.gameObject.GetComponent<PlayerStats>().AddAnxiety(5);
			col.gameObject.GetComponent<PlayerStats>().TakeAwayMoney(20);
			GetComponent<Stats>().HealthValue = 0;
		}else if (col.gameObject.tag == "Shield")
		{
			GetComponent<Stats>().Deathbycollison = true;
			col.gameObject.GetComponentInParent<PlayerStats>().AddAnxiety(5);
			col.gameObject.GetComponentInParent<PlayerStats>().TakeAwayMoney(20);
			GetComponent<Stats>().HealthValue = 0;
		}
	}
}
