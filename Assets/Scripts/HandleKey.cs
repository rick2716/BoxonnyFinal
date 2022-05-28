using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleKey : MonoBehaviour
{
    public bool key;
    
    //public BoxCollider box;
    // Start is called before the first frame update
    void Start()
    {
        key = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            key = true;
            //Destroy(other.gameObject);
            //Debug.Log("Llave entraaaaa");

        }
        else
        {
            key = false;

        }
    }

}
