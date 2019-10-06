using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 mouseStartPosition;
    [SerializeField]private CameraController cameraController;
    private GameObject currentInteractable;
    bool usingInteractable;

    void Start()
    {
        mouseStartPosition = Input.mousePosition;
        currentInteractable = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!usingInteractable)
        {
            ControlHandler();
            CheckForInteractable();
        }
        else
        {
            usingInteractable = currentInteractable.GetComponent<Interactable>().CheckInteractionState();
        }
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
    }

    private void KeyControl()
    {
        GetComponent<Rigidbody>().velocity = (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")) * 5;
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            usingInteractable = true;
            currentInteractable.GetComponent<Interactable>().BeginInteraction();
            Debug.Log("INTERACTED");
        }
        if (currentInteractable != null)
        {
            usingInteractable = currentInteractable.GetComponent<Interactable>().CheckInteractionState();
        }
    }


}
