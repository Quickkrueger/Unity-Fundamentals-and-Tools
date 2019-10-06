using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarshallKrueger.Tools.TextInput
{
    public static class TextInputHandler
    {
        const int LOWEST_CHARACTER = 32;
        const int HIGHEST_CHARACTER = 126;
        const int LOWEST_NUMPAD = 256;
        const int HIGHEST_NUMPAD = 270;
        const int TO_UPPER = -32;

        public static bool IsCharacter(KeyCode keyCode)
        {
            if((keyCode >= (KeyCode)LOWEST_CHARACTER && keyCode <= (KeyCode)HIGHEST_CHARACTER))
            {
                return true;
            }

            return false;
        }
        public static bool IsLetter(KeyCode keyCode)
        {
            if(keyCode >= KeyCode.A && keyCode <= KeyCode.Z)
            {
                return true;
            }

            return false;
        }

        public static string EditString(string currentString, KeyCode keyCode)
        {
            string finalString = currentString;
            if (IsCharacter(keyCode))
            {
                char codeToChar;

                if((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && IsLetter(keyCode))
                {
                    keyCode = (KeyCode)((int)keyCode + TO_UPPER);
                }

                codeToChar = (char)keyCode;
                finalString = currentString + codeToChar;
            }
            else if (keyCode == KeyCode.Backspace)
            {
                if (currentString.Length > 0)
                {
                    finalString = currentString.Substring(0, currentString.Length - 1);
                }
            }

            return finalString;
        }
    }
}
