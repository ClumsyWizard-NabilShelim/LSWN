using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
	public Animator anim;
	public TextMeshProUGUI Text;
//	[HideInInspector]
	public string[] DialogieText;
	public int index;
	/*[HideInInspector]*/ public bool Dialoguestart; 
//	int i = 0;
    // Start is called before the first frame update
    void Start()
    {
		//anim = GetComponent<Animator>();
		//ShowText();
	}

    // Update is called once per frame
    void Update()
    {
		if(index > DialogieText.Length)
		{
			DialogieText = null;
			index = 0;
		}
		if(Dialoguestart)
		{
			anim.SetTrigger("In");
			Text.text = DialogieText[index];
		}
		
    }

	public void Next()
	{
		if(index < DialogieText.Length)
		{
			index++;
		}
		if(index == DialogieText.Length)
		{
			Done();
		}
		//ShowText();
	}


	void Done()
	{
		index = 0;
		DialogieText = null;
		anim.SetTrigger("Out");
		Dialoguestart = false;
	}
	//void ShowText()
	//{
	//	foreach (string s in DialogieText)
	//	{
	//		if (i == index)
	//		{
	//			Text.text = s;
	//		}
	//		i++;
	//	}
	//}
}
