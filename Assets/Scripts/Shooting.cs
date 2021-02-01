using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    void FixedUpdate()
	{
		Vector2 Diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float Rotz = Mathf.Atan2(Diff.y, Diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, Rotz);
	}
}
