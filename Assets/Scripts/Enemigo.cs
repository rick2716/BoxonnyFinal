using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int damage;
    public GameObject jugador;


    public int rutina;
    public float cronometro;
    public Animator anim;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    public bool atacando;

    


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("NombrePersonaje");
    }

    // Update is called once per frame
    void Update()
    {
        Comportamiento();
    }

    public void Comportamiento()
    {
        if(Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            anim.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    anim.SetBool("walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    anim.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !atacando)
            {
                var LookPos = target.transform.position - transform.position;
                LookPos.y = 0;
                var rot = Quaternion.LookRotation(LookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 2);
                anim.SetBool("walk", false);

                anim.SetBool("run", true);
                transform.Translate(Vector3.forward * 1.5f * Time.deltaTime);

                anim.SetBool("hit", false);
            }
            else
            {
                anim.SetBool("walk", false);
                anim.SetBool("run", false);

                anim.SetBool("hit", true);
                //atacando = true;

            }
        }
        
    }

    public void Final_anim()
    {
        anim.SetBool("hit", false);
        atacando = false;

    }

    public void Damage()
    {
        atacando = true;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Niño")
    //    if(other.tag == "Niño")
    //    {
    //        jugador.GetComponent<DatosJugador>().vidaPlayer -= damage;

    //    }
    //}

}
