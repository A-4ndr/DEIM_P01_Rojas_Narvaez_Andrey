using JetBrains.Annotations;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]     //Aseguramos que si o si se necesita el Rigidbody2D
public class Prota : MonoBehaviour
{
    float Velocidad = 4.0f; //Se mueve
    Rigidbody2D rb; //Rigidbody al prota

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>(); //Asignamos rigidbody

    }

    // Update is called once per frame
    void Update()
    {
        //Detecta que toco la tecla A para ir a la izquierda
        if (Input.GetKey(KeyCode.A))
        {
         
            //Mueve el personaje a la izquierda
            transform.Translate(-Velocidad * Time.deltaTime, 0, 0);

        }

        //Detecta que toco la tecla D para ir a la derecha (Otro metodo para hacer que se mueve con transform)
        if (Input.GetKey(KeyCode.D))
       {
                       
           //Mueve el personaje a la izquierda
           transform.Translate(Velocidad * Time.deltaTime, 0, 0);

       }
        

    }
    //Colisiones en 2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Detecta que el personaje colisiona con un objeto con el tag ( se puede usar el .tag normal de toda la vida)
        if (collision.gameObject.CompareTag ("Suelo"))
        {
            //Destruye al personaje al tocar el objeto
            Destroy(gameObject);

        }

    }

}


/*Detecta que toco la tecla A para ir a la izquierda (Metodo de movimiento cambiando la velocidad del rigidbody)
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Muestra un texto en el momento que se toca la tecla
            print("Si esta pulsando");
            //Mueve el personaje a la izquierda
            rb.linearVelocityX = -Velocidad;

        }
        else if (Input.GetKeyUp(KeyCode.A))    //Detecta que ya no estoy tocando la letra A
        {
            //Por lo tanto la velocidad pasa a estar en Cero 0
            rb.linearVelocityX = 0;

        }

        //Detecta que toco la tecla D para ir a la derecha
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Muestra un texto en el momento que se toca la tecla
            print("Si esta pulsando");
            //Mueve el personaje a la derecha
            rb.linearVelocityX = Velocidad;

        }
        else if (Input.GetKeyUp(KeyCode.D))    //Detecta que ya no estoy tocando la letra D
        {
            //Por lo tanto la velocidad pasa a estar en Cero 0
            rb.linearVelocityX = 0;

        }*/
