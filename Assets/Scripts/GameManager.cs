using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	public GameObject Player;

	public PlayerStats stat;
	public GameObject GameOverCanvas;

	public GameObject[] PlayerWeapons;
	int RandomInt;

	public TextMeshProUGUI Moneyearned;

	public TextMeshProUGUI SomeTalk;

	public float Picktime;
	float CurrentTime;

	public Animator CamAnim;
	public AudioSource Clip;
	public GameObject Spawner;
	// Start is called before the first frame update
	void Start()
	{
		CurrentTime = 15f;
	//	CurrentTime = Picktime;
		stat = Player.GetComponent<PlayerStats>();
		//RandomInt = Random.Range(0, 2);

		//PlayerWeapons[RandomInt].SetActive(true);

		//for (int i = 0; i < PlayerWeapons.Length; i++)
		//{
		//	if(PlayerWeapons[i] != PlayerWeapons[RandomInt])
		//	{
		//		PlayerWeapons[i].SetActive(false);
		//	}
		//}

		PlayerWeapons[0].SetActive(false);
		PlayerWeapons[1].SetActive(false);
	

	}

	// Update is called once per frame
	void Update()
	{
		if(stat.Money < 0)
		{
			Moneyearned.text = "0";
		}
		else
		{
			Moneyearned.text = stat.Money.ToString();
		}
	
		if (stat.Dead == true)
		{
		//	Clip.Play();
			GameOver();
		}
		else
		{
			GameOverCanvas.SetActive(false);
		}

		if(Player != null)
		{
			if (PlayerWeapons != null)
			{
				if (CurrentTime <= 0)
				{
					RandomInt = Random.Range(0, 2);

					PlayerWeapons[RandomInt].SetActive(true);

					for (int i = 0; i < PlayerWeapons.Length; i++)
					{
						if (PlayerWeapons[i] != PlayerWeapons[RandomInt])
						{
							PlayerWeapons[i].SetActive(false);
						}
					}
					CurrentTime = Picktime;
				}
				else
				{
					CurrentTime -= Time.deltaTime;
				}
			}
		}


		if (Player == null)
		{
			Destroy(Spawner);
		}


	}

	void GameOver()
	{
		GameOverCanvas.SetActive(true);
		if (stat.Money < 500 && stat.Money > 0)
		{
			SomeTalk.text = "Well you earned the same amount of money as you lived............ Very little.... HAHAHAHAHAHAHAH";
		}
		else if (stat.Money > 1000 && stat.Money < 5000)
		{
			SomeTalk.text = "Well kid it looks like you earned yourself some good amount of money but the thing is you still died out of anxiety cause you couldn't dodge those payments. Sad. HEHEHEHEHEHEHE";
		}
		else if (stat.Money > 5000)
		{
			SomeTalk.text = "Kid I gotta say you earned a good amount of money, A honerable amount, but lifes unfare and that What gives ME JOY!!! HAHAHAHAHAHAHAHAH";
		}
		else
		{
			if (stat.Money <= 0)
			{
				SomeTalk.text = "Well your playing skills is exactly like your earning ...... '0'! HAHAHAHAHAHAHHAHAHAHAHAHAHAHAHAHAHAHAH";
			}
		}
	}

	public void CamShake()
	{
		CamAnim.SetTrigger("Shake");
	}
}
