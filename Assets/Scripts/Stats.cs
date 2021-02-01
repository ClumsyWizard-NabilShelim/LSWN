using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
	public float Health;
	[HideInInspector] public float HealthValue;
	public GameObject effect;

	[Header("After Death")]
	public int MoneyDropAmount;
	public float NutralizerComboAmount;
	GameManager GM;
	[HideInInspector] public bool Deathbycollison;

	// Start is called before the first frame update
	void Start()
	{
		GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
		HealthValue = Health;
	}

	// Update is called once per frame
	void Update()
	{
		if (HealthValue <= 0)
		{
			Die();
		}
	}

	public void Damage(float amount)
	{
		HealthValue -= amount;
	}

	void Die()
	{
		if(Deathbycollison == false)
		{
			GM.stat.AddMoney(MoneyDropAmount);
		}

		Instantiate(effect, transform.position, Quaternion.identity);

		if(GM.Player != null)
		{
			if (Deathbycollison == false)
			{
				GM.Player.GetComponent<PlayerStats>().Combo(NutralizerComboAmount);
			}
		}

		Destroy(gameObject);
	}
}
