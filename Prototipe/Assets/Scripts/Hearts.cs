using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    public static Hearts Instance;
    public int _health;
    public Image[] hearts;
    void Awake ()   
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        _health = Hearts.Instance._health;
    }
    // Update is called once per frame
    public void Hurt()
    {
        if (_health >= 0 && _health <= 3)
        {
            if (_health != 0)
                _health--;
            if (_health == 2)
            {
                hearts[0].enabled = true;
                hearts[1].enabled = true;
                hearts[2].enabled = false;
            }
            if (_health == 1)
            {
                hearts[0].enabled = true;
                hearts[1].enabled = false;
                hearts[2].enabled = false;
            }
            if (_health == 0)
            {
                hearts[0].enabled = false;
                hearts[1].enabled = false;
                hearts[2].enabled = false;
            }
            Debug.Log(_health);
            Hearts.Instance._health = _health;
        }
        else if (_health == 0)
            Debug.Log("FINISH");
    }
}
