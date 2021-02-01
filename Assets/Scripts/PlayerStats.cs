using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
	[HideInInspector]public float Money;
	[HideInInspector] public float Anxiety;
/*	[HideInInspector]*/ public float anxietyNutralizerCombo = 0;

	public TextMeshProUGUI MoneyText;
	public Image AnxietyBar;
	public Image AnxietyNutralizer_bar;

	public Sprite[] Conditions;
	public GameObject DeathEffect;
	SpriteRenderer Rend;
	public bool Dead;

	public GameObject GameText;
	public AudioSource clip;
    // Start is called before the first frame update
    void Start()
    {
		Rend = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
		MoneyText.text = "$" + Money.ToString();
		AnxietyBar.fillAmount = Anxiety / 100;

		AnxietyNutralizer_bar.fillAmount = anxietyNutralizerCombo / 100;

		if (anxietyNutralizerCombo >= 100)
		{
			GameText.SetActive(true);
			if (Input.GetMouseButtonDown(1))
			{
				ComboClick();
			}
		}
		else
		{
			GameText.SetActive(false);
		}

		if (Anxiety >= 100)
		{
			Death();
		}
	}

	public void TakeAwayMoney(float Amount)
	{
		Money -= Amount;
	}

	public void AddMoney(float Amount)
	{
		Money += Amount;
	}

	public void AddAnxiety(float Amount)
	{
		Anxiety += Amount;
	}

	public void Combo(float combo)
	{
		anxietyNutralizerCombo += combo;
	}

	void Death()
	{
		Instantiate(DeathEffect, transform.position, Quaternion.identity);
		Dead = true;
		Destroy(gameObject);
	}
	public void ComboClick()
	{
		clip.Play();
		Anxiety = 0;
		anxietyNutralizerCombo = 0;
		Debug.Log("Fuck");

	}
}
