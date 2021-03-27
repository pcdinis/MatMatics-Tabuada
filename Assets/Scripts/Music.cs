using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    static Music instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    public void ToggleSound()
    {
        if (GameEngine.soundOn == true)
        {
            GameEngine.soundOn = false;
            AudioListener.volume = 0f;
        }
        else
        {
            GameEngine.soundOn = true;
            AudioListener.volume = 0.5f;
        }
    }
}
