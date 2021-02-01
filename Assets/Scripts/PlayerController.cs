using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Transform pos;

	public float MovementSpeed;
	public Camera cam;
	public float Dashforce;
	public float DashDelay;
	float currentTime;
	SpriteRenderer Rend;
	public GameObject effect;
	Rigidbody2D Rb2D;
	Animator Anim;
	Vector2 InputVec;

	public SpriteRenderer[] Weapons;
	// Start is called before the first frame update
	void Start()
	{
		cam = Camera.main;
		Anim = cam.GetComponent<Animator>();
		Rend = GetComponent<SpriteRenderer>();
		Rb2D = GetComponent<Rigidbody2D>();
		currentTime = DashDelay;
	}

	// Update is called once per frame
	void Update()
	{

		InputVec.x = Input.GetAxisRaw("Horizontal");
		InputVec.y = Input.GetAxisRaw("Vertical");

		if (currentTime <= 0)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Dash();
			}
		}
		else
		{
			currentTime -= Time.deltaTime;
		}

		CheckMousePos();
	}

	void FixedUpdate()
	{
		Rb2D.MovePosition(Rb2D.position + InputVec.normalized * MovementSpeed * Time.fixedDeltaTime);
	}

	void CheckMousePos()
	{
		Vector2 playerPos = cam.WorldToScreenPoint(transform.position);

		if (Input.mousePosition.x < playerPos.x)
		{
			Rend.flipX = true;
			foreach (SpriteRenderer r in Weapons)
			{
				r.flipY = true;
			}
		}
		else
		{
			Rend.flipX = false;
			foreach (SpriteRenderer r in Weapons)
			{
				r.flipY = false;
			}
		}
	}

	void Dash()
	{
		Anim.SetTrigger("Shake");
		Rb2D.AddForce(InputVec.normalized * Dashforce * Time.deltaTime);
		Instantiate(effect, transform.position, Quaternion.identity);
		currentTime = DashDelay;
	}
}
