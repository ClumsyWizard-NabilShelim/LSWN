using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour
{
	public Transform ShootPos;
	public GameObject Projectile;

	[Header("ShootingControl")]
	public float FireRate;
	float CurrentTime;
	// Start is called before the first frame update
	void Start()
	{
		CurrentTime = FireRate;
	}
	void Update()
	{
		if (CurrentTime <= 0)
		{
			if(!EventSystem.current.IsPointerOverGameObject())
			{
				if (Input.GetMouseButtonDown(0))
				{
					Shoot();
				}
			}
			
		}
		else
		{
			CurrentTime -= Time.deltaTime;
		}
	}

	void Shoot()
	{
		GameObject Bullet = Instantiate(Projectile, ShootPos.position, ShootPos.rotation);
		Destroy(Bullet, 10f);
		CurrentTime = FireRate;
	}
}
