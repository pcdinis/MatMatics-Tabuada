using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Music sound;

    private Button button;

    public void onClick()
    {
        Sprite spriteNumber;

        sound.ToggleSound();
        if (GameEngine.soundOn == false)
        {
            // Get sprite
            spriteNumber = Resources.Load<Sprite>("Images/57");
        }
        else
        {
            // Get sprite
            spriteNumber = Resources.Load<Sprite>("Images/56");
        }
        // Get the Result Button and define the image based on the pressed key (from numeric keyboad)
        button = GetComponent<Button>();
        button.image.sprite = spriteNumber;
    }

    public void okSound()
    {
        AudioSource audioSource = sound.GetComponent<AudioSource>();
        //audioSource.PlayOneShot()
    }

    public void errorSound()
    {

    }

}
