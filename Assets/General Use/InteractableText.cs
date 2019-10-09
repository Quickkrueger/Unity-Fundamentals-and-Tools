using MarshallKrueger.Tools.TextInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MarshallKrueger.Tools.Interactable
{
    public class InteractableText : Interactable
    {
        // Start is called before the first frame update
        bool isInteracting;
        private void Start()
        {
            isInteracting = false;
        }

        private void OnGUI()
        {
            Event e = Event.current;
            if (isInteracting && e.isKey)
            {
                if (Input.GetKeyDown(e.keyCode))
                {
                    KeyCode keyCode = e.keyCode;
                    KeyPressed(keyCode);
                }
            }
        }

        private void Update()
        {

        }

        public void BeginInteraction()
        {
            StartCoroutine(ToInteraction());

        }

        public bool CheckInteractionState()
        {
            return isInteracting;
        }

        private IEnumerator ToInteraction()
        {
            yield return new WaitWhile(() => Input.GetKey(KeyCode.E));
            isInteracting = true;
        }

        private void KeyPressed(KeyCode keyCode)
        {
            if (isInteracting)
            {
                if (Input.anyKeyDown)
                {
                    GetComponent<Text>().text = TextInputHandler.EditString(GetComponent<Text>().text, keyCode);
                }
            }
        }
    }
}
