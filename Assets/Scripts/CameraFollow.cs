using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform Target;
	public Vector3 Offset;

	public float MoveSpeed;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//if(Target == null)
		//{
		//	Debug.Log("No player");
		//}
		if (Target != null)
		{
			Vector3 TargetPos = Target.position + Offset;
			Vector3 SmoothPos = Vector3.Lerp(transform.position, TargetPos, MoveSpeed);
			transform.position = SmoothPos;
		}



	}
}
