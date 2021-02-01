using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
	//public Vector2 Size;
	//public Transform ColPos;

	//Collider2D[] col;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//col = Physics2D.OverlapBoxAll(ColPos.position, Size, 0);

		//foreach (Collider2D HitObject in col)
		//{
		//	if(HitObject.tag == "Bullet")
		//	{
		//		Debug.Log(HitObject);
		//		Destroy(HitObject);
		//	}
		//}
	}

	void FixedUpdate()
	{
		Vector2 Diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float Rotz = Mathf.Atan2(Diff.y, Diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, Rotz);
	}

	//void OnDrawGizmos()
	//{
	//	Gizmos.DrawWireCube(ColPos.position, Size);
	//}
}
