using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StoryBoard : MonoBehaviour
{
	public TextMeshProUGUI dialogue;

	public string[] text;
	public int index;

	public GameObject[] ExampleObjects;
	public AudioSource Clip;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		dialogue.text = text[index];

		//if(index == 13)
		//{
		//	ExampleObjects[0].SetActive(true);
		//}
		//else
		//{
		//	ExampleObjects[0].SetActive(false);
		//}

		if (index == 14)
		{
			ExampleObjects[0].SetActive(true);
		}
		else
		{
			ExampleObjects[0].SetActive(false);
		}

		if (index == 15)
		{
			ExampleObjects[1].SetActive(true);
		}
		else
		{
			ExampleObjects[1].SetActive(false);
		}
	}

	public void Next()
	{
		Clip.Play();
		if (index < text.Length+1)
		{
			index++;
		}

		if(index > text.Length-1)
		{
			Done();
		}
	
	}

	void Done()
	{
		
		SceneManager.LoadScene("MainScene");
	}

}
