using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarshallKrueger.Tools.Interactable;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 mouseStartPosition;
    [SerializeField]private CameraController cameraController;
    private GameObject currentInteractable;

    void Start()
    {
        mouseStartPosition = Input.mousePosition;
        currentInteractable = null;
    }

    // Update is called once per frame
    void Update()
    {
            ControlHandler();
            CheckForInteractable();
    }

    private void ControlHandler()
    {
        MouseControl();
        KeyControl();
    }

    private void MouseControl()
    {
        gameObject.transform.rotation = Quaternion.Euler(0f, Input.GetAxis("Mouse X") * 5f + gameObject.transform.rotation.eulerAngles.y, 0f);
        cameraController.RotateCamera(Quaternion.Euler(Input.GetAxis("Mouse Y") * 5f, gameObject.transform.rotation.eulerAngles.y, 0f));
    }

    private void CheckForInteractable()
    {
        currentInteractable = cameraController.GetCameraRaycast();

        if(currentInteractable != null && currentInteractable.GetComponent<Interactable>() != null)
        {
            currentInteractable.GetComponent<Interactable>().EnableInteractionText();
            Debug.Log("INTERACTABLE FOUND");
        }
        else
        {
            InteractionController._instance.DisableInteractionText();
            currentInteractable = null;
        }
    }

    private void KeyControl()
    {
        GetComponent<Rigidbody>().velocity = (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")) * 5;
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.GetComponent<Interactable>().Interact();
            Debug.Log("INTERACTED");
        }
    }


}
