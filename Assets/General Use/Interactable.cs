using MarshallKrueger.Tools.TextInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MarshallKrueger.Tools.Interactable
{
    public class Interactable : MonoBehaviour
    {
        protected string objectTag;
        protected bool interacting;
        public float interactionDelay;
        protected string interactionText;

        private void Start()
        {
            objectTag = tag;
            interacting = false;
            interactionDelay = 1;
            interactionText = "Press 'E' to interact.";
        }

        public virtual void Interact()
        {
            if (!interacting)
            {
                StartCoroutine(RunInteraction());
            }
        }
        
        protected virtual IEnumerator RunInteraction()
        {
            interacting = true;
            yield return new WaitForSeconds(interactionDelay);
            interacting = false;
        }

        protected virtual void InteractionResult()
        {

        }

        public bool IsInteracting()
        {
            return interacting;
        }

        public void EnableInteractionText()
        {
            InteractionController._instance.EnableInteractionText(interactionText);
        }

    }
}