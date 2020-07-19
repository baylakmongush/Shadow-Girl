using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenToPyramid : MonoBehaviour
{
    // Start is called before the first frame updatepublic bool sceneEnd;
    public bool sceneEnd;
    public float fadeSpeed = 1.5f;
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
            GameObject.FindGameObjectWithTag("character").transform.position = new Vector2(40, GameObject.FindGameObjectWithTag("character").transform.position.y);
            sceneEnd = false;
            GameObject.FindGameObjectWithTag("location").GetComponent<Image>().enabled = false;
		}
	}
}
