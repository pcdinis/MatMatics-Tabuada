using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumericKeyboard : MonoBehaviour
{
    [SerializeField] private GameObject clickHand1;

    [SerializeField] private GameObject winCup;
    [SerializeField] private GameObject lostGame;

    [SerializeField] private GameObject imgError;
    [SerializeField] private GameObject imgOk;

    [SerializeField] private GameObject life1;
    [SerializeField] private GameObject life2;
    [SerializeField] private GameObject life3;

    [SerializeField] private GameObject group1;
    [SerializeField] private GameObject group2;
    [SerializeField] private GameObject group3;
    [SerializeField] private GameObject group4;
    [SerializeField] private GameObject group5;
    [SerializeField] private GameObject group6;
    [SerializeField] private GameObject group7;
    [SerializeField] private GameObject group8;
    [SerializeField] private GameObject group9;
    [SerializeField] private GameObject group10;

    [SerializeField] private ResultButton uResCalc1;
    [SerializeField] private ResultButton dResCalc1;
    [SerializeField] private ResultButton cResCalc1;

    [SerializeField] private ResultButton uResCalc2;
    [SerializeField] private ResultButton dResCalc2;
    [SerializeField] private ResultButton cResCalc2;

    [SerializeField] private ResultButton uResCalc3;
    [SerializeField] private ResultButton dResCalc3;
    [SerializeField] private ResultButton cResCalc3;

    [SerializeField] private ResultButton uResCalc4;
    [SerializeField] private ResultButton dResCalc4;
    [SerializeField] private ResultButton cResCalc4;

    [SerializeField] private ResultButton uResCalc5;
    [SerializeField] private ResultButton dResCalc5;
    [SerializeField] private ResultButton cResCalc5;

    [SerializeField] private ResultButton uResCalc6;
    [SerializeField] private ResultButton dResCalc6;
    [SerializeField] private ResultButton cResCalc6;

    [SerializeField] private ResultButton uResCalc7;
    [SerializeField] private ResultButton dResCalc7;
    [SerializeField] private ResultButton cResCalc7;

    [SerializeField] private ResultButton uResCalc8;
    [SerializeField] private ResultButton dResCalc8;
    [SerializeField] private ResultButton cResCalc8;

    [SerializeField] private ResultButton uResCalc9;
    [SerializeField] private ResultButton dResCalc9;
    [SerializeField] private ResultButton cResCalc9;

    [SerializeField] private ResultButton uResCalc10;
    [SerializeField] private ResultButton dResCalc10;
    [SerializeField] private ResultButton cResCalc10;

    private LTSeq sequenceAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void numberPressed()
    {
        // Check if it's game over
        bool gameOver = false;

        if (GameEngine.freeKeyboard == true)
        {

        if (GameEngine.allCalcComplete == false)
        {

            string unit = "";
            string ten = "";
            string hundred = "";

            // Get Pressed Key (from numeric keyboard)
            Button bt = this.GetComponent<Button>();
            string numChar = bt.name.Substring(5);

            // Get Line
            string line = GameEngine.getLine();
            // Set Num2
            GameEngine.setOperationNum2(int.Parse(line));

            // Get slot cursor
            string slotCursor = GameEngine.getSlotCursor();

            switch (slotCursor)
            {
                case "unitCursor":
                    unit = "X";
                    break;
                case "tenCursor":
                    ten = "X";
                    break;
                case "hundredCursor":
                    hundred = "X";
                    break;
                default:
                    break;
            }

            // Insert the value pressed within the result spot
            this.setNumberOnResult(numChar, line, unit, ten, hundred);

            // Set number within Game Engine
            GameEngine.setPressedNumber(numChar, line, unit, ten, hundred);

            if (unit == "X")
            {
                // Check if result is OK
                string result = GameEngine.checkResult();

                if (result == "ok")
                {
                    // Check if it was the last calc

                    if (line == "10")
                    {
                        GameEngine.allCalcComplete = true;
                        // Win Animation (LeanTween)
                        this.winAnimation();
                        this.scaleCalculation(group10);
                    }
                    else
                    {
                        // Ok Animation (LeanTween)
                        Vector3 imgScale = imgOk.transform.localScale;
                        sequenceAnim = new LTSeq();
                        sequenceAnim = LeanTween.sequence();
                        sequenceAnim.append(() => { GameEngine.freeKeyboard = false; }); ; // fire event before tween
                        sequenceAnim.append(GameEngine.timeTweenDelay); // delay everything one second
                        sequenceAnim.append(LeanTween.scale(imgOk, new Vector3(GameEngine.scaleResult, GameEngine.scaleResult, imgScale.z), GameEngine.timeTweenCalc)); // do a tween
                        sequenceAnim.append(LeanTween.scale(imgOk, new Vector3(GameEngine.scaleResultInit, GameEngine.scaleResultInit, imgScale.z), GameEngine.timeTweenCalc));
                        //sequenceAnim.append(() => { GameEngine.freeKeyboard = true; }); ; // fire event after tween
                        }

                }
                else if (result == "wrong")
                {
                    Sprite spriteLostLife = Resources.Load<Sprite>("Images/55");

                    // Check how many lifes left
                    int lifesNum = GameEngine.getLifesNumber();

                    if (lifesNum == 1)
                    {
                        // Get the life game object and define the image based on the number of lifes
                        life3.GetComponent<SpriteRenderer>().sprite = spriteLostLife;
                        // You lost the game
                        gameOver = true;
                        // Set calculations complete
                        GameEngine.allCalcComplete = true;
                        // Game Over Animation (LeanTween)
                        this.gameOverAnimation();
                    }
                    else if (lifesNum == 2)
                    {
                        // Get the life game object and define the image based on the number of lifes
                        life2.GetComponent<SpriteRenderer>().sprite = spriteLostLife;
                    }
                    else if (lifesNum == 3)
                    {
                        // Get the life game object and define the image based on the number of lifes
                        life1.GetComponent<SpriteRenderer>().sprite = spriteLostLife;
                    }

                    if (gameOver == false)
                    {
                        // Error Animation (LeanTween)
                        Vector3 imgScale = imgError.transform.localScale;
                        sequenceAnim = new LTSeq();
                        sequenceAnim = LeanTween.sequence();
                        sequenceAnim.append(() => { GameEngine.freeKeyboard = false; }); ; // fire event before tween
                        sequenceAnim.append(GameEngine.timeTweenDelay); // delay everything one second
                        sequenceAnim.append(LeanTween.scale(imgError, new Vector3(GameEngine.scaleResult, GameEngine.scaleResult, imgScale.z), GameEngine.timeTweenCalc)); // do a tween
                        sequenceAnim.append(LeanTween.scale(imgError, new Vector3(GameEngine.scaleResultInit, GameEngine.scaleResultInit, imgScale.z), GameEngine.timeTweenCalc));
                        //sequenceAnim.append(() => { GameEngine.freeKeyboard = true; }); ; // fire event after tween
                        // Take one life out
                        GameEngine.setRemoveLife();
                    }

                }

            }

            if (gameOver == false)
            {
                // Points to the next spot
                this.setNextSpotOnResult(line, unit, ten, hundred);
            }
        }
        else
        {
            // Game complete... force the gamer to press BACK
            this.pointBackButton();
        }
    }
    }

    public void pointBackButton()
    {
        clickHand1.SetActive(true);

        float lv_x = GameEngine.clickHandX + GameEngine.clickHandDelta;
        float lv_y = GameEngine.clickHandY - GameEngine.clickHandDelta;
        float lv_z = GameEngine.clickHandZ;

        sequenceAnim = new LTSeq();
        sequenceAnim = LeanTween.sequence();
        for (int i = 0; i < 10; i++)
        {
            sequenceAnim.append(LeanTween.moveLocal(clickHand1, new Vector3(lv_x, lv_y, lv_z), 0.5f));
            sequenceAnim.append(LeanTween.moveLocal(clickHand1, new Vector3(GameEngine.clickHandX, GameEngine.clickHandY, GameEngine.clickHandZ), 0.5f));
        }
    }

    public void setNumberOnResult(string numChar, string line, string unit, string ten, string hundred)
    {
        switch (line)
        {
            case "1":
                if (unit == "X")
                {
                    uResCalc1.gameObject.SetActive(true);
                    uResCalc1.setButtonNumber(numChar);
                }
                else if (ten == "X")
                {
                    dResCalc1.gameObject.SetActive(true);
                    uResCalc1.gameObject.SetActive(true);
                    dResCalc1.setButtonNumber(numChar);
                }
                else if (hundred == "X")
                {
                    cResCalc1.gameObject.SetActive(true);
                    dResCalc1.gameObject.SetActive(true);
                    uResCalc1.gameObject.SetActive(true);
                    cResCalc1.setButtonNumber(numChar);
                }
                break;
            case "2":
                if (unit == "X")
                {
                    uResCalc2.gameObject.SetActive(true);
                    uResCalc2.setButtonNumber(numChar);
                }
                else if (ten == "X")
                {
                    dResCalc2.gameObject.SetActive(true);
                    uResCalc2.gameObject.SetActive(true);
                    dResCalc2.setButtonNumber(numChar);
                }
                else if (hundred == "X")
                {
                    cResCalc2.gameObject.SetActive(true);
                    dResCalc2.gameObject.SetActive(true);
                    uResCalc2.gameObject.SetActive(true);
                    cResCalc2.setButtonNumber(numChar);
                }
                break;
            case "3":
                if (unit == "X")
                {
                    uResCalc3.gameObject.SetActive(true);
                    uResCalc3.setButtonNumber(numChar);
                }
                else if (ten == "X")
                {
                    dResCalc3.gameObject.SetActive(true);
                    uResCalc3.gameObject.SetActive(true);
                    dResCalc3.setButtonNumber(numChar);
                }
                else if (hundred == "X")
                {
                    cResCalc3.gameObject.SetActive(true);
                    dResCalc3.gameObject.SetActive(true);
                    uResCalc3.gameObject.SetActive(true);
                    cResCalc3.setButtonNumber(numChar);
                }
                break;
            case "4":
                if (unit == "X")
                {
                    uResCalc4.gameObject.SetActive(true);
                    uResCalc4.setButtonNumber(numChar);
                }
                else if (ten == "X")
                {
                    dResCalc4.gameObject.SetActive(true);
                    uResCalc4.gameObject.SetActive(true);
                    dResCalc4.setButtonNumber(numChar);
                }
                else if (hundred == "X")
                {
                    cResCalc4.gameObject.SetActive(true);
                    dResCalc4.gameObject.SetActive(true);
                    uResCalc4.gameObject.SetActive(true);
                    cResCalc4.setButtonNumber(numChar);
                }
                break;
            case "5":
                if (unit == "X")
                {
                    uResCalc5.gameObject.SetActive(true);
                    uResCalc5.setButtonNumber(numChar);
                }
                else if (ten == "X")
                {
                    dResCalc5.gameObject.SetActive(true);
                    uResCalc5.gameObject.SetActive(true);
                    dResCalc5.setButtonNumber(numChar);
                }
                else if (hundred == "X")
                {
                    cResCalc5.gameObject.SetActive(true);
                    dResCalc5.gameObject.SetActive(true);
                    uResCalc5.gameObject.SetActive(true);
                    cResCalc5.setButtonNumber(numChar);
                }
                break;
            case "6":
                if (unit == "X")
                {
                    uResCalc6.gameObject.SetActive(true);
                    uResCalc6.setButtonNumber(numChar);
                }
                else if (ten == "X")
                {
                    dResCalc6.gameObject.SetActive(true);
                    uResCalc6.gameObject.SetActive(true);
                    dResCalc6.setButtonNumber(numChar);
                }
                else if (hundred == "X")
                {
                    cResCalc6.gameObject.SetActive(true);
                    dResCalc6.gameObject.SetActive(true);
                    uResCalc6.gameObject.SetActive(true);
                    cResCalc6.setButtonNumber(numChar);
                }
                break;
            case "7":
                if (unit == "X")
                {
                    uResCalc7.gameObject.SetActive(true);
                    uResCalc7.setButtonNumber(numChar);
                }
                else if (ten == "X")
                {
                    dResCalc7.gameObject.SetActive(true);
                    uResCalc7.gameObject.SetActive(true);
                    dResCalc7.setButtonNumber(numChar);
                }
                else if (hundred == "X")
                {
                    cResCalc7.gameObject.SetActive(true);
                    dResCalc7.gameObject.SetActive(true);
                    uResCalc7.gameObject.SetActive(true);
                    cResCalc7.setButtonNumber(numChar);
                }
                break;
            case "8":
                if (unit == "X")
                {
                    uResCalc8.gameObject.SetActive(true);
                    uResCalc8.setButtonNumber(numChar);
                }
                else if (ten == "X")
                {
                    dResCalc8.gameObject.SetActive(true);
                    uResCalc8.gameObject.SetActive(true);
                    dResCalc8.setButtonNumber(numChar);
                }
                else if (hundred == "X")
                {
                    cResCalc8.gameObject.SetActive(true);
                    dResCalc8.gameObject.SetActive(true);
                    uResCalc8.gameObject.SetActive(true);
                    cResCalc8.setButtonNumber(numChar);
                }
                break;
            case "9":
                if (unit == "X")
                {
                    uResCalc9.gameObject.SetActive(true);
                    uResCalc9.setButtonNumber(numChar);
                }
                else if (ten == "X")
                {
                    dResCalc9.gameObject.SetActive(true);
                    uResCalc9.gameObject.SetActive(true);
                    dResCalc9.setButtonNumber(numChar);
                }
                else if (hundred == "X")
                {
                    cResCalc9.gameObject.SetActive(true);
                    dResCalc9.gameObject.SetActive(true);
                    uResCalc9.gameObject.SetActive(true);
                    cResCalc9.setButtonNumber(numChar);
                }
                break;
            case "10":
                if (unit == "X")
                {
                    uResCalc10.gameObject.SetActive(true);
                    uResCalc10.setButtonNumber(numChar);
                }
                else if (ten == "X")
                {
                    dResCalc10.gameObject.SetActive(true);
                    uResCalc10.gameObject.SetActive(true);
                    dResCalc10.setButtonNumber(numChar);
                }
                else if (hundred == "X")
                {
                    cResCalc10.gameObject.SetActive(true);
                    dResCalc10.gameObject.SetActive(true);
                    uResCalc10.gameObject.SetActive(true);
                    cResCalc10.setButtonNumber(numChar);
                }
                break;
            default:
                break;
        }
    }

    public void setNextSpotOnResult(string line, string unit, string ten, string hundred)
    {

        if (hundred == "X")
        {
            GameEngine.setSlotCursor("", "X", "");
        }
        else if (ten == "X")
        {
            GameEngine.setSlotCursor("", "", "X");
        }
        else if (unit == "X")
        {
            // What's the next calc result?
            int nextResult = GameEngine.getNextResult();

            // Set focus to the next result
            int numDigits = nextResult.ToString().Length;

            if (numDigits == 3){
                GameEngine.setSlotCursor("X", "", "");
            }else if (numDigits == 2){
                GameEngine.setSlotCursor("", "X", "");
            }
            else if (numDigits == 1){
                GameEngine.setSlotCursor("", "", "X");
            }

            int line_i = int.Parse(line);
            line_i++;
            GameEngine.setLine(line_i.ToString());

            this.setCalcFocus(line_i);
        }
    }

    public void setCalcFocus(int i_focus)
    {
        switch (i_focus)
        {
            case 1:
                this.scaleCalculation(group1, group10);
                break;
            case 2:
                this.scaleCalculation(group2, group1);
                break;
            case 3:
                this.scaleCalculation(group3, group2);
                break;
            case 4:
                this.scaleCalculation(group4, group3);
                break;
            case 5:
                this.scaleCalculation(group5, group4);
                break;
            case 6:
                this.scaleCalculation(group6, group5);
                break;
            case 7:
                this.scaleCalculation(group7, group6);
                break;
            case 8:
                this.scaleCalculation(group8, group7);
                break;
            case 9:
                this.scaleCalculation(group9, group8);
                break;
            case 10:
                this.scaleCalculation(group10, group9);
                break;

        }

    }

    public void removeAllCalcFocus()
    {
        float lv_time = 0.001f;
        this.scaleCalculation(group1, lv_time);
        this.scaleCalculation(group2, lv_time);
        this.scaleCalculation(group3, lv_time);
        this.scaleCalculation(group4, lv_time);
        this.scaleCalculation(group5, lv_time);
        this.scaleCalculation(group6, lv_time);
        this.scaleCalculation(group7, lv_time);
        this.scaleCalculation(group8, lv_time);
        this.scaleCalculation(group9, lv_time);
        this.scaleCalculation(group10, lv_time);
    }

    public void scaleCalculation(GameObject groupScale, GameObject groupUnscale)
    {
        Vector3 calcUnscale = groupUnscale.transform.localScale;
        //calcUnscale.z
        sequenceAnim.append(LeanTween.scale(groupUnscale, new Vector3(GameEngine.scaleCalcInit, GameEngine.scaleCalcInit, calcUnscale.z), GameEngine.timeTweenCalc));

        Vector3 calcScale = groupScale.transform.localScale;
        //calcScale.z
        sequenceAnim.append(LeanTween.scale(groupScale, new Vector3(GameEngine.scaleCalc, GameEngine.scaleCalc, calcScale.z), GameEngine.timeTweenCalc));
        sequenceAnim.append(() => { GameEngine.freeKeyboard = true; }); ; // fire event after tween
    }

    public void scaleCalculation(GameObject groupUnscale)
    {
        Vector3 calcUnscale = groupUnscale.transform.localScale;
        //calcUnscale.z
        sequenceAnim.append(LeanTween.scale(groupUnscale, new Vector3(GameEngine.scaleCalcInit, GameEngine.scaleCalcInit, calcUnscale.z), GameEngine.timeTweenCalc));
    }

    public void scaleCalculation(GameObject groupUnscale, float time)
    {
        Vector3 calcUnscale = groupUnscale.transform.localScale;
        //calcUnscale.z
        sequenceAnim.append(LeanTween.scale(groupUnscale, new Vector3(GameEngine.scaleCalcInit, GameEngine.scaleCalcInit, calcUnscale.z), time));
    }

    public void deleteInsertedNumber()
    {
        if (GameEngine.allCalcComplete == false)
        {
            // Points to the previous spot
            this.setPreviousSpotOnResult();
        }
        else
        {
            // Game complete... force the gamer to press BACK
            this.pointBackButton();
        }
    }

    public void setPreviousSpotOnResult()
    {
        // What's the atual calc result?
        int actualResult = GameEngine.getActualResult();

        // Set focus to the next result
        int numDigits = actualResult.ToString().Length;

        // Get Line
        string line = GameEngine.getLine();

        if (numDigits == 3)
        {
            GameEngine.setSlotCursor("X", "", "");
        }
        else if (numDigits == 2)
        {
            GameEngine.setSlotCursor("", "X", "");
        }
        else if (numDigits == 1)
        {
            GameEngine.setSlotCursor("", "", "X");
        }

        this.clearSpotOnResult(line, numDigits);
    }

    public void clearSpotOnResult(string line, int numDigits)
    {
        switch (numDigits)
        {
            case 1:
                GameEngine.clearPressedNumber("", "", "X");
                break;
            case 2:
                GameEngine.clearPressedNumber("", "", "X");
                GameEngine.clearPressedNumber("", "X", "");
                break;
            case 3:
                GameEngine.clearPressedNumber("", "", "X");
                GameEngine.clearPressedNumber("", "X", "");
                GameEngine.clearPressedNumber("X", "", "");
                break;
            default:
                break;
        }

        switch (line)
        {
            case "1":
                if (numDigits == 1)
                {
                    uResCalc1.clearButtonNumber();
                }
                else if (numDigits == 2)
                {
                    uResCalc1.clearButtonNumber();
                    dResCalc1.clearButtonNumber();
                }
                else if (numDigits == 3)
                {
                    uResCalc1.clearButtonNumber();
                    dResCalc1.clearButtonNumber();
                    cResCalc1.clearButtonNumber();
                }
                break;
            case "2":
                if (numDigits == 1)
                {
                    uResCalc2.clearButtonNumber();
                }
                else if (numDigits == 2)
                {
                    uResCalc2.clearButtonNumber();
                    dResCalc2.clearButtonNumber();
                }
                else if (numDigits == 3)
                {
                    uResCalc2.clearButtonNumber();
                    dResCalc2.clearButtonNumber();
                    cResCalc2.clearButtonNumber();
                }
                break;
            case "3":
                if (numDigits == 1)
                {
                    uResCalc3.clearButtonNumber();
                }
                else if (numDigits == 2)
                {
                    uResCalc3.clearButtonNumber();
                    dResCalc3.clearButtonNumber();
                }
                else if (numDigits == 3)
                {
                    uResCalc3.clearButtonNumber();
                    dResCalc3.clearButtonNumber();
                    cResCalc3.clearButtonNumber();
                }
                break;
            case "4":
                if (numDigits == 1)
                {
                    uResCalc4.clearButtonNumber();
                }
                else if (numDigits == 2)
                {
                    uResCalc4.clearButtonNumber();
                    dResCalc4.clearButtonNumber();
                }
                else if (numDigits == 3)
                {
                    uResCalc4.clearButtonNumber();
                    dResCalc4.clearButtonNumber();
                    cResCalc4.clearButtonNumber();
                }
                break;
            case "5":
                if (numDigits == 1)
                {
                    uResCalc5.clearButtonNumber();
                }
                else if (numDigits == 2)
                {
                    uResCalc5.clearButtonNumber();
                    dResCalc5.clearButtonNumber();
                }
                else if (numDigits == 3)
                {
                    uResCalc5.clearButtonNumber();
                    dResCalc5.clearButtonNumber();
                    cResCalc5.clearButtonNumber();
                }
                break;
            case "6":
                if (numDigits == 1)
                {
                    uResCalc6.clearButtonNumber();
                }
                else if (numDigits == 2)
                {
                    uResCalc6.clearButtonNumber();
                    dResCalc6.clearButtonNumber();
                }
                else if (numDigits == 3)
                {
                    uResCalc6.clearButtonNumber();
                    dResCalc6.clearButtonNumber();
                    cResCalc6.clearButtonNumber();
                }
                break;
            case "7":
                if (numDigits == 1)
                {
                    uResCalc7.clearButtonNumber();
                }
                else if (numDigits == 2)
                {
                    uResCalc7.clearButtonNumber();
                    dResCalc7.clearButtonNumber();
                }
                else if (numDigits == 3)
                {
                    uResCalc7.clearButtonNumber();
                    dResCalc7.clearButtonNumber();
                    cResCalc7.clearButtonNumber();
                }
                break;
            case "8":
                if (numDigits == 1)
                {
                    uResCalc8.clearButtonNumber();
                }
                else if (numDigits == 2)
                {
                    uResCalc8.clearButtonNumber();
                    dResCalc8.clearButtonNumber();
                }
                else if (numDigits == 3)
                {
                    uResCalc8.clearButtonNumber();
                    dResCalc8.clearButtonNumber();
                    cResCalc8.clearButtonNumber();
                }
                break;
            case "9":
                if (numDigits == 1)
                {
                    uResCalc9.clearButtonNumber();
                }
                else if (numDigits == 2)
                {
                    uResCalc9.clearButtonNumber();
                    dResCalc9.clearButtonNumber();
                }
                else if (numDigits == 3)
                {
                    uResCalc9.clearButtonNumber();
                    dResCalc9.clearButtonNumber();
                    cResCalc9.clearButtonNumber();
                }
                break;
            case "10":
                if (numDigits == 1)
                {
                    uResCalc10.clearButtonNumber();
                }
                else if (numDigits == 2)
                {
                    uResCalc10.clearButtonNumber();
                    dResCalc10.clearButtonNumber();
                }
                else if (numDigits == 3)
                {
                    uResCalc10.clearButtonNumber();
                    dResCalc10.clearButtonNumber();
                    cResCalc10.clearButtonNumber();
                }
                break;
            default:
                break;
        }
    }

    public void winAnimation()
    {
        Vector3 winCupScale = winCup.transform.localScale;
        sequenceAnim = new LTSeq();
        sequenceAnim = LeanTween.sequence();
        sequenceAnim.append(GameEngine.timeTweenDelay);
        // Remove all result button focus
        this.removeAllCalcFocus();
        sequenceAnim.append(LeanTween.scale(winCup, new Vector3(GameEngine.scaleResult, GameEngine.scaleResult, winCupScale.z), GameEngine.timeTweenCalc));
        sequenceAnim.append(2f);
        sequenceAnim.append(LeanTween.scale(winCup, new Vector3(GameEngine.scaleResultInit, GameEngine.scaleResultInit, winCupScale.z), GameEngine.timeTweenCalc));
        sequenceAnim.append(3f);
    }

    public void gameOverAnimation()
    {
        Vector3 lostGameScale = lostGame.transform.localScale;
        sequenceAnim = new LTSeq();
        sequenceAnim = LeanTween.sequence();
        sequenceAnim.append(GameEngine.timeTweenDelay);
        // Remove all result button focus
        this.removeAllCalcFocus();
        sequenceAnim.append(LeanTween.scale(lostGame, new Vector3(GameEngine.scaleResult, GameEngine.scaleResult, lostGameScale.z), GameEngine.timeTweenCalc));
        sequenceAnim.append(2f);
        sequenceAnim.append(LeanTween.scale(lostGame, new Vector3(GameEngine.scaleResultInit, GameEngine.scaleResultInit, lostGameScale.z), GameEngine.timeTweenCalc));
        sequenceAnim.append(3f);
    }
}
