using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
	public string PlayLevel;
	public string MainMenuLevel;
	public string CreditsLevel;

	public AudioSource Clip;

	public void Play()
	{
		Clip.Play();
		SceneManager.LoadScene(PlayLevel);
	}

	public void MainMenu()
	{
		Clip.Play();
		SceneManager.LoadScene(MainMenuLevel);
	}

	public void Restart()
	{
		Clip.Play();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Credits()
	{
		Clip.Play();
		SceneManager.LoadScene(CreditsLevel);
	}

	//public void Quit()
	//{
	//	Application.Quit();
	//}
}
