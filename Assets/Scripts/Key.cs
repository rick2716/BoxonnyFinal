using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public BoxCollider box;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
    }
        
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)//LO CAMBIE DE COLLISION A COLLIDER:...
    {
        if(other.gameObject.tag == "Handle")
        {
            box.isTrigger = true;
        }
    }
}
