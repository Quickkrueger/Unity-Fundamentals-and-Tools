using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    [SerializeField]private Text interactionText;
    public static InteractionController _instance;

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        interactionText.text = "Press 'E' to interact.";
    }

    public void EnableInteractionText(string newText)
    {
        interactionText.text = newText;
        interactionText.enabled = true;
    }

    public void DisableInteractionText()
    {
        interactionText.enabled = false;
    }
}
