using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEngine
{
    public static bool freeKeyboard = false;
    public static bool soundOn = true;
    public static int numTabuada;

    public static int lifes;

    public static bool allCalcComplete;

    public static int numberOne;
    public static int numberTwo;

    public static ResultButton generalResultButton;

    private static string line    = null;
    private static string unit    = null;
    private static string ten     = null;
    private static string hundred = null;

    private static string unitCursor    = null;
    private static string tenCursor     = null;
    private static string hundredCursor = null;

    public static float timeTweenCalc = 0.5f;
    public static float scaleCalc = 1.6f;
    public static float scaleCalcInit = 1f;
    public static float scaleResult = 100;
    public static float scaleResultInit = 0.18f;
    public static float timeTweenDelay = 0.1f;

    public static float clickHandX = 0f;
    public static float clickHandY = 0f;
    public static float clickHandZ = 0f;
    public static float clickHandDelta = 25f;


    public static int randomNumber()
    {
        int i;
        i = Random.Range(0, 10);

        return i;
    }

    public static void initData()
    {
        allCalcComplete = false;

        lifes = 3;

        numberOne = 0;
        numberTwo = 0;
    
        line = null;
        unit = null;
        ten = null;
        hundred = null;

        unitCursor = null;
        tenCursor = null;
        hundredCursor = null;
    }

    public static void setRemoveLife()
    {
        lifes--;
    }

    public static int getLifesNumber()
    {
        return lifes;
    }

    public static void setGeneralButton(ResultButton specificResButton)
    {
        generalResultButton = specificResButton;
    }

    public static ResultButton getGeneralButton()
    {
        return generalResultButton;
    }

    public static void clearGeneralButton()
    {
        generalResultButton = null;
    }

    public static void setOperationData(int num1, int num2)
    {
        numberOne = num1;
        numberTwo = num2;
    }

    public static void setOperationNum2(int num2)
    {
        numberTwo = num2;
    }

    public static void setSlotCursor(string hundred, string ten, string unit)
    {
        unitCursor    = unit;
        tenCursor     = ten;
        hundredCursor = hundred;
    }

    public static string getSlotCursor()
    {
        string res = null;

        if (unitCursor == "X"){
            res = "unitCursor";
        }else if(tenCursor == "X"){
            res = "tenCursor";
        }else if(hundredCursor == "X"){
            res = "hundredCursor";
        }

        return res;
    }

    public static void setPressedNumber(string numChar, string line, string unit, string ten, string hundred) {
        if (unit == "X")
        {
            setUnit(numChar);
        }else if (ten == "X")
        {
            setTen(numChar);
        }
        else if (hundred == "X")
        {
            setHundred(numChar);
        }
    }

    public static void clearPressedNumber(string unit, string ten, string hundred)
    {
        if (unit == "X")
        {
            setUnit(null);
        }
        else if (ten == "X")
        {
            setTen(null);
        }
        else if (hundred == "X")
        {
            setHundred(null);
        }
    }

    public static void setLine(string num)
    {
        line = num;
    }

    public static void setUnit(string num)
    {
        unit = num;
    }

    public static void setTen(string num)
    {
        ten = num;
    }

    public static void setHundred(string num)
    {
        hundred = num;
    }

    public static string getLine()
    {
        return line;
    }

    public static string getUnit()
    {
        return unit;
    }

    public static string getTen()
    {
        return ten;
    }

    public static string getHundred()
    {
        return hundred;
    }

    public static int getActualResult()
    {
        int result = 0;
        result = numberOne * numberTwo;

        return result;
    }

    public static int getNextResult()
    {
        int result = 0;
        int nextNumberTwo = 0;
        nextNumberTwo = numberTwo + 1;
        result = numberOne * nextNumberTwo;

        return result;
    }

    public static string checkResult()
    {
        int result = 0;
        string success = "";
        
        result = numberOne * numberTwo;

        // Do the checking
        int num100 = 0;
        if (hundred != null) {
            num100 = int.Parse(hundred);
        }
        int num10 = 0;
        if (ten != null)
        {
            num10 = int.Parse(ten);
        }
        int num1 = 0;
        if (unit != null)
        {
            num1 = int.Parse(unit);
        }

        int checkResult = (num100 * 100) + (num10 * 10) + (num1);
        if (checkResult == result)
        {
            // Result Right
            success = "ok";
        }
        else
        {
            // Result Wrong
            success = "wrong";
        }

        return success;

    }
}
