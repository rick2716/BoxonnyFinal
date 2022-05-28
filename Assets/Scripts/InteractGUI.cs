using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractGUI : MonoBehaviour
{
    public float distancia = 2.0f;
    public GameObject text1;
    public GameObject text2;
    GameObject ultimoReconocido;
    public HandleKey hk;
    bool text;
    // Start is called before the first frame update
    void Start()
    {
        text1.SetActive(false);
        text2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        DeselectObj();
        if (hk.key)
        {

        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia))
            {

                DeselectObj();

                if (hit.collider.tag == "PuertaBloqueada")
                {
                    text = false;
                    SelectedObj(hit.transform);

                }
                else if (hit.collider.tag == "PuertaPistola")
                {
                    text = true;
                    SelectedObj(hit.transform);
                }
                else
                {
                    DeselectObj();
                }

            }


        }

    }


    void SelectedObj(Transform transform)
    {
        ultimoReconocido = transform.gameObject;
    }

    void DeselectObj()
    {
        if (ultimoReconocido)
        {
            ultimoReconocido = null;
        }
    }

    void OnGUI()
    {
        if (ultimoReconocido)
        {
            if (text)
            {
                text2.SetActive(true);
            }
            else
            {
                text1.SetActive(true);
            }

        }
        else
        {
            text2.SetActive(false);
            text1.SetActive(false);
        }
    }
}