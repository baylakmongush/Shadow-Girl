using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionBetweenLevels : MonoBehaviour
{
    public bool sceneEnd;
	public float fadeSpeed = 1.5f;
	public string nextLevel;
	private Image _image;
	private bool sceneStarting;

	void Awake ()
	{
		_image = GetComponent<Image>();
		sceneStarting = true;
		sceneEnd = false;
		Cursor.visible = false;
	}

	void Update ()
	{
		if(sceneStarting) StartScene();
		if(sceneEnd) EndScene();
	}

	void StartScene ()
	{
		_image.color = Color.Lerp(_image.color, Color.clear, fadeSpeed * Time.deltaTime);

		if(_image.color.a <= 0.01f)
		{
			_image.color = Color.clear;
			_image.enabled = false;
			sceneStarting = false;
			Cursor.visible = true;
		}
	}

	void EndScene ()
	{
		_image.enabled = true;
		_image.color = Color.Lerp(_image.color, Color.black, fadeSpeed * Time.deltaTime);

		if(_image.color.a >= 0.95f)
		{
			Cursor.visible = false;
			_image.color = Color.black;
			SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
		}
	}
}
