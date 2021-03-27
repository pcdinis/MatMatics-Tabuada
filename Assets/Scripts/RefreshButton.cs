using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefreshButton : MonoBehaviour
{
    [SerializeField] private GameObject clickHand1;

    [SerializeField] private GameObject numericKeyboard;

    [SerializeField] private GameObject btCalc1Result1;
    [SerializeField] private GameObject btCalc1Result2;
    [SerializeField] private GameObject btCalc1Result3;

    [SerializeField] private GameObject btCalc2Result1;
    [SerializeField] private GameObject btCalc2Result2;
    [SerializeField] private GameObject btCalc2Result3;

    [SerializeField] private GameObject btCalc3Result1;
    [SerializeField] private GameObject btCalc3Result2;
    [SerializeField] private GameObject btCalc3Result3;

    [SerializeField] private GameObject btCalc4Result1;
    [SerializeField] private GameObject btCalc4Result2;
    [SerializeField] private GameObject btCalc4Result3;

    [SerializeField] private GameObject btCalc5Result1;
    [SerializeField] private GameObject btCalc5Result2;
    [SerializeField] private GameObject btCalc5Result3;

    [SerializeField] private GameObject btCalc6Result1;
    [SerializeField] private GameObject btCalc6Result2;
    [SerializeField] private GameObject btCalc6Result3;

    [SerializeField] private GameObject btCalc7Result1;
    [SerializeField] private GameObject btCalc7Result2;
    [SerializeField] private GameObject btCalc7Result3;

    [SerializeField] private GameObject btCalc8Result1;
    [SerializeField] private GameObject btCalc8Result2;
    [SerializeField] private GameObject btCalc8Result3;

    [SerializeField] private GameObject btCalc9Result1;
    [SerializeField] private GameObject btCalc9Result2;
    [SerializeField] private GameObject btCalc9Result3;

    [SerializeField] private GameObject btCalc10Result1;
    [SerializeField] private GameObject btCalc10Result2;
    [SerializeField] private GameObject btCalc10Result3;

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

    [SerializeField] private SlotNumber calc1_number11;
    [SerializeField] private SlotNumber calc1_number12;
    [SerializeField] private SlotNumber calc1_number21;
    [SerializeField] private SlotNumber calc1_number22;

    [SerializeField] private SlotNumber calc2_number11;
    [SerializeField] private SlotNumber calc2_number12;
    [SerializeField] private SlotNumber calc2_number21;
    [SerializeField] private SlotNumber calc2_number22;

    [SerializeField] private SlotNumber calc3_number11;
    [SerializeField] private SlotNumber calc3_number12;
    [SerializeField] private SlotNumber calc3_number21;
    [SerializeField] private SlotNumber calc3_number22;

    [SerializeField] private SlotNumber calc4_number11;
    [SerializeField] private SlotNumber calc4_number12;
    [SerializeField] private SlotNumber calc4_number21;
    [SerializeField] private SlotNumber calc4_number22;

    [SerializeField] private SlotNumber calc5_number11;
    [SerializeField] private SlotNumber calc5_number12;
    [SerializeField] private SlotNumber calc5_number21;
    [SerializeField] private SlotNumber calc5_number22;

    [SerializeField] private SlotNumber calc6_number11;
    [SerializeField] private SlotNumber calc6_number12;
    [SerializeField] private SlotNumber calc6_number21;
    [SerializeField] private SlotNumber calc6_number22;

    [SerializeField] private SlotNumber calc7_number11;
    [SerializeField] private SlotNumber calc7_number12;
    [SerializeField] private SlotNumber calc7_number21;
    [SerializeField] private SlotNumber calc7_number22;

    [SerializeField] private SlotNumber calc8_number11;
    [SerializeField] private SlotNumber calc8_number12;
    [SerializeField] private SlotNumber calc8_number21;
    [SerializeField] private SlotNumber calc8_number22;

    [SerializeField] private SlotNumber calc9_number11;
    [SerializeField] private SlotNumber calc9_number12;
    [SerializeField] private SlotNumber calc9_number21;
    [SerializeField] private SlotNumber calc9_number22;

    [SerializeField] private SlotNumber calc10_number11;
    [SerializeField] private SlotNumber calc10_number12;
    [SerializeField] private SlotNumber calc10_number21;
    [SerializeField] private SlotNumber calc10_number22;


    public void Refresh()
    {
        // Game Engine initialization
        GameEngine.initData();

        // Init calc focus
        this.initFocus();

        this.hideResultButtons();

        // hide pointing hands
        this.clickHand1.SetActive(false);
        Vector3 clickTween = clickHand1.transform.localPosition;
        GameEngine.clickHandX = clickTween.x;
        GameEngine.clickHandY = clickTween.y;
        GameEngine.clickHandZ = clickTween.z;

        // define random numbers
        //int numProduct = GameEngine.randomNumber();
        int numProduct = GameEngine.numTabuada;

        // Set numbers to sprite
        string strProduct = numProduct.ToString();

        // Set numbers on the screen
        this.setNumberImagesWithinScreen(strProduct, numProduct);
        
        // launch numeric keyboard
        numericKeyboard.SetActive(true);

        // Initialize regarding the first operation!!!
        // Focus Initialization
        Vector3 calc1_pos_ori = group1.transform.localScale;
        LeanTween.scale(group1, new Vector3(GameEngine.scaleCalc, GameEngine.scaleCalc, calc1_pos_ori.z), GameEngine.timeTweenCalc);

        // Set the Operation and the Result
        GameEngine.setOperationData(numProduct, 1);

        GameEngine.setLine("1");

        if (strProduct == "10")
        {
            GameEngine.setSlotCursor("", "X", "");
        }
        else
        {
            GameEngine.setSlotCursor("", "", "X");
        }

        GameEngine.freeKeyboard = true;
    }

    public void setNumberImagesWithinScreen(string strProduct, int numProduct)
    {
        string str11 = "";
        string str12 = "";
        string str21 = "";
        string str22 = "";

        if (strProduct == "10")
        {
            str11 = 1.ToString();
            str12 = 0.ToString();
        }
        else
        {
            str11 = 0.ToString();
            str12 = numProduct.ToString();
        }

        Sprite sp11 = Resources.Load<Sprite>("Images/1" + str11);
        if (str11 == "0")
        {
            sp11 = Resources.Load<Sprite>("Images/2" + str11);
        }

        Sprite sp12 = Resources.Load<Sprite>("Images/1" + str12);
        if (str12 == "0")
        {
            sp12 = Resources.Load<Sprite>("Images/2" + str12);
        }

        // Set sprites to slots
        str21 = 0.ToString();
        str22 = 1.ToString();
        calc1_number11.setNumber(sp11);
        if (strProduct == "10")
        {
            calc1_number11.setActive(true);
        }
        else
        {
            calc1_number11.setActive(false);
        }
        calc1_number12.setNumber(sp12);
        calc1_number21.setNumber(Resources.Load<Sprite>("Images/2" + str21));
        calc1_number21.setActive(false);
        calc1_number22.setNumber(Resources.Load<Sprite>("Images/1" + str22));

        str21 = 0.ToString();
        str22 = 2.ToString();
        calc2_number11.setNumber(sp11);
        if (strProduct == "10")
        {
            calc2_number11.setActive(true);
        }
        else
        {
            calc2_number11.setActive(false);
        }
        calc2_number12.setNumber(sp12);
        calc2_number21.setNumber(Resources.Load<Sprite>("Images/2" + str21));
        calc2_number21.setActive(false);
        calc2_number22.setNumber(Resources.Load<Sprite>("Images/1" + str22));

        str21 = 0.ToString();
        str22 = 3.ToString();
        calc3_number11.setNumber(sp11);
        if (strProduct == "10")
        {
            calc3_number11.setActive(true);
        }
        else
        {
            calc3_number11.setActive(false);
        }
        calc3_number12.setNumber(sp12);
        calc3_number21.setNumber(Resources.Load<Sprite>("Images/2" + str21));
        calc3_number21.setActive(false);
        calc3_number22.setNumber(Resources.Load<Sprite>("Images/1" + str22));

        str21 = 0.ToString();
        str22 = 4.ToString();
        calc4_number11.setNumber(sp11);
        if (strProduct == "10")
        {
            calc4_number11.setActive(true);
        }
        else
        {
            calc4_number11.setActive(false);
        }
        calc4_number12.setNumber(sp12);
        calc4_number21.setNumber(Resources.Load<Sprite>("Images/2" + str21));
        calc4_number21.setActive(false);
        calc4_number22.setNumber(Resources.Load<Sprite>("Images/1" + str22));

        str21 = 0.ToString();
        str22 = 5.ToString();
        calc5_number11.setNumber(sp11);
        if (strProduct == "10")
        {
            calc5_number11.setActive(true);
        }
        else
        {
            calc5_number11.setActive(false);
        }
        calc5_number12.setNumber(sp12);
        calc5_number21.setNumber(Resources.Load<Sprite>("Images/2" + str21));
        calc5_number21.setActive(false);
        calc5_number22.setNumber(Resources.Load<Sprite>("Images/1" + str22));

        str21 = 0.ToString();
        str22 = 6.ToString();
        calc6_number11.setNumber(sp11);
        if (strProduct == "10")
        {
            calc6_number11.setActive(true);
        }
        else
        {
            calc6_number11.setActive(false);
        }
        calc6_number12.setNumber(sp12);
        calc6_number21.setNumber(Resources.Load<Sprite>("Images/2" + str21));
        calc6_number21.setActive(false);
        calc6_number22.setNumber(Resources.Load<Sprite>("Images/1" + str22));

        str21 = 0.ToString();
        str22 = 7.ToString();
        calc7_number11.setNumber(sp11);
        if (strProduct == "10")
        {
            calc7_number11.setActive(true);
        }
        else
        {
            calc7_number11.setActive(false);
        }
        calc7_number12.setNumber(sp12);
        calc7_number21.setNumber(Resources.Load<Sprite>("Images/2" + str21));
        calc7_number21.setActive(false);
        calc7_number22.setNumber(Resources.Load<Sprite>("Images/1" + str22));

        str21 = 0.ToString();
        str22 = 8.ToString();
        calc8_number11.setNumber(sp11);
        if (strProduct == "10")
        {
            calc8_number11.setActive(true);
        }
        else
        {
            calc8_number11.setActive(false);
        }
        calc8_number12.setNumber(sp12);
        calc8_number21.setNumber(Resources.Load<Sprite>("Images/2" + str21));
        calc8_number21.setActive(false);
        calc8_number22.setNumber(Resources.Load<Sprite>("Images/1" + str22));

        str21 = 0.ToString();
        str22 = 9.ToString();
        calc9_number11.setNumber(sp11);
        if (strProduct == "10")
        {
            calc9_number11.setActive(true);
        }
        else
        {
            calc9_number11.setActive(false);
        }
        calc9_number12.setNumber(sp12);
        calc9_number21.setNumber(Resources.Load<Sprite>("Images/2" + str21));
        calc9_number21.setActive(false);
        calc9_number22.setNumber(Resources.Load<Sprite>("Images/1" + str22));

        str21 = 1.ToString();
        str22 = 0.ToString();
        calc10_number11.setNumber(sp11);
        if (strProduct == "10")
        {
            calc10_number11.setActive(true);
        }
        else
        {
            calc10_number11.setActive(false);
        }
        calc10_number12.setNumber(sp12);
        calc10_number21.setNumber(Resources.Load<Sprite>("Images/1" + str21));
        calc10_number21.setActive(true);
        calc10_number22.setNumber(Resources.Load<Sprite>("Images/2" + str22));
    }


    public void initFocus()
    {
        group1.transform.localScale  = new Vector3((float)1, (float)1, (float)1);
        group2.transform.localScale  = new Vector3((float)1, (float)1, (float)1);
        group3.transform.localScale  = new Vector3((float)1, (float)1, (float)1);
        group4.transform.localScale  = new Vector3((float)1, (float)1, (float)1);
        group5.transform.localScale  = new Vector3((float)1, (float)1, (float)1);
        group6.transform.localScale  = new Vector3((float)1, (float)1, (float)1);
        group7.transform.localScale  = new Vector3((float)1, (float)1, (float)1);
        group8.transform.localScale  = new Vector3((float)1, (float)1, (float)1);
        group9.transform.localScale  = new Vector3((float)1, (float)1, (float)1);
        group10.transform.localScale = new Vector3((float)1, (float)1, (float)1);

    }

    public void hideResultButtons()
    {
        btCalc1Result1.SetActive(false);
        btCalc1Result2.SetActive(false);
        btCalc1Result3.SetActive(false);

        btCalc2Result1.SetActive(false);
        btCalc2Result2.SetActive(false);
        btCalc2Result3.SetActive(false);

        btCalc3Result1.SetActive(false);
        btCalc3Result2.SetActive(false);
        btCalc3Result3.SetActive(false);

        btCalc4Result1.SetActive(false);
        btCalc4Result2.SetActive(false);
        btCalc4Result3.SetActive(false);

        btCalc5Result1.SetActive(false);
        btCalc5Result2.SetActive(false);
        btCalc5Result3.SetActive(false);

        btCalc6Result1.SetActive(false);
        btCalc6Result2.SetActive(false);
        btCalc6Result3.SetActive(false);

        btCalc7Result1.SetActive(false);
        btCalc7Result2.SetActive(false);
        btCalc7Result3.SetActive(false);

        btCalc8Result1.SetActive(false);
        btCalc8Result2.SetActive(false);
        btCalc8Result3.SetActive(false);

        btCalc9Result1.SetActive(false);
        btCalc9Result2.SetActive(false);
        btCalc9Result3.SetActive(false);

        btCalc10Result1.SetActive(false);
        btCalc10Result2.SetActive(false);
        btCalc10Result3.SetActive(false);

    }
}
