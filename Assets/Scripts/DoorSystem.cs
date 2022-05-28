using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class DoorSystem : MonoBehaviour
{
    
    public XRGrabInteractable doorGrab;
    public HandleKey handleKey;
    //public Rigidbody rb;
    private bool key;

    // Start is called before the first frame update
    void Start()
    {
        doorGrab = GetComponent<XRGrabInteractable>();
        //rb = GetComponent<Rigidbody>();
        doorGrab.enabled = false;
        //rb.isKinematic = true;
        //rb.detectCollisions = false;
    }

    // Update is called once per frame
    void Update()
    {
        key = handleKey.key;
       
        if (key)
        {
            doorGrab.enabled = true;
        }
        else
        {
            doorGrab.enabled = false;
            Debug.Log("False");
        }
    }

    
 
}
