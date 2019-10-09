using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public void RotateCamera(Quaternion cameraRotation)
    {
        gameObject.transform.rotation = Quaternion.Euler(cameraRotation.eulerAngles.x * -1 + transform.rotation.eulerAngles.x, cameraRotation.eulerAngles.y, 0f);
    }

    public GameObject GetCameraRaycast()
    {
        RaycastHit raycastHit;
        if(Physics.Raycast(transform.position, transform.forward, out raycastHit, 3)){
            if(raycastHit.collider.gameObject.tag == "Interactable")
            {
                return raycastHit.collider.gameObject;
            }
            else
            {
                return null;
            }
        }
        return null;
    }

}
