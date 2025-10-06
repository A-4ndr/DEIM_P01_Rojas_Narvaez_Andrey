using JetBrains.Annotations;
using UnityEngine;

public class Prota : MonoBehaviour
{
    public int Movimiento; //Se mueve
    Rigidbody2D rb; //Rigidbody al prota

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Movimiento = 4; //La velocidad de movimiento
        rb = GetComponent<Rigidbody2D>(); //Asignamos rigidbody

    }

    // Update is called once per frame
    void Update()
    {
        //Si le doy a la A va a la izquierda
        if (Input.GetKeyDown(KeyCode.A))
            {

            

            }
        //Si le doy a la D va a la derecha
        if (Input.GetKeyDown(KeyCode.D))
        {



        }

    }

}
