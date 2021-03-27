using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultButton : MonoBehaviour
{
    [SerializeField] private GameObject numericKeyboard;

    private Sprite p_image;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void launchKeyboard()
    {
        // launch numeric keyboard
        numericKeyboard.SetActive(true);
        GameEngine.setGeneralButton(this);
    }

    public void hideKeyboard()
    {
        // hide numeric keyboard
        numericKeyboard.SetActive(false);
        GameEngine.clearGeneralButton();
    }

    public void clearButtonNumber()
    {
        Sprite spriteNumber;
        spriteNumber = Resources.Load<Sprite>("Images/89");
        // Get the Result Button and define the image clear button
        button = GetComponent<Button>();
        button.image.sprite = spriteNumber;
    }

    public void setButtonNumber(string numChar)
    {
        Sprite spriteNumber;

        // Get sprite
        if (numChar == "0")
        {
            spriteNumber = Resources.Load<Sprite>("Images/2" + numChar);
        }
        else
        {
            spriteNumber = Resources.Load<Sprite>("Images/1" + numChar);
        }

        // Get the Result Button and define the image based on the pressed key (from numeric keyboad)
        button = GetComponent<Button>();
        button.image.sprite = spriteNumber;

        int operationResultBl = 0;

        if (button.name == "btResult1")
        {
            // Set unit
            //GameEngine.setUnit(numChar);
            // Check result
            //operationResultBl = GameEngine.checkResult();
        }
        else if (button.name == "btResult2")
        {
            // Set tens
            //GameEngine.setTen(numChar);
            // Check result
            //operationResultBl = GameEngine.checkResult();
        }
        else if (button.name == "btResult3")
        {
            // Set hundreds
            //GameEngine.setHundred(numChar);
            // Check result
            //operationResultBl = GameEngine.checkResult();
        }

        if (operationResultBl != 0)
        {
            // Send message
            if (operationResultBl == 1)
            {
                Debug.Log("SUCCESS!!!");
            }
            else if (operationResultBl == 2)
            {
                Debug.Log("WRONG!!!");
            }
        }

        // then hide the keyboard
        //this.hideKeyboard();
    }
}
