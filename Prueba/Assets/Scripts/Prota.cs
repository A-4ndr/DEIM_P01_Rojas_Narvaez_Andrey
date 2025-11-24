using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;               //Esto activa el codigo relacionado con UI (Interfaz de usuario)


[RequireComponent(typeof(Rigidbody2D))]     //Aseguramos que si o si se necesita el Rigidbody2D
public class Prota : MonoBehaviour
{
    [SerializeField]                           //Sirve para poder ver algo que esta privado en el inspector
    float Velocidad = 4.0f; //Se mueve
    Rigidbody2D rb; //Rigidbody al prota
    public static int Puntos;                  //Variable que se encarga de contabilizar los puntos
    public TMP_Text MarcadorPuntos;            //Objeto de texto que tiene el marcador de los puntos, el "Public" se usa cuando tengo asignar algo dentro del unity
    private int bestScore;                     //Se encarga de tener la maxima puntuacion historica
    public GameObject DerrapeDER;              //Derrape derecho
    public GameObject DerrapeIZQ;              //Derrape Izquierdo
                      

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Puntos = 0;                       //Empiezas con cero puntos
        rb = GetComponent<Rigidbody2D>(); //Asignamos rigidbody

    }

    // Update is called once per frame
    void Update()
    {
        //Llamamos a la funcion del movimiento
        Movimiento();
        //Llamaos a la funcion del movimiento con el dedo
        //MovimientoDedo();

        if (Input.GetKey(KeyCode.Tab))
        {
            //Llamamos a la funcion de maxima puntuacion
            CheckBestScore();

        }

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
    //Colisiones trigger en 2D
    private void OnTriggerEnter2D(Collider2D collider)
    {

        //Detecta que el personaje colisiona con un objeto con el tag ( se puede usar el .tag normal de toda la vida)
        if (collider.gameObject.CompareTag("Moneda"))
        {
            //Destruye al personaje al tocar el objeto
            Destroy(collider.gameObject);
            //Suma puntos en el interfaz
            Puntos  ++;
            //Cambiar el texto de "MarcadorMonedas" a ": junto con el valor de la variable Puntos", esto se crea con el codigo (MarcadorMonedas.text = ": "+ Puntos;)
            MarcadorPuntos.text = ": " + Puntos;

        }

    }
    //Funcion para el movimiento con el dedo
    private void MovimientoDedo()
    {

        //Detecta que estoy tocando la pantalla con el dedo
        if (Input.touchCount > 0)
        {
            //Detecta que estoy moviendo el dedo
            float fingerMovementX = Input.touches[0].deltaPosition.x;
            //Movimiento (Transform)
            transform.Translate(fingerMovementX * Velocidad * Time.deltaTime, 0, 0);
            
        }
        else
        {
            //Detener movimiento (RigidBody)
            rb.linearVelocityX = 0;

        }

    }
    //Funcion para el movimiento del personaje al tocar la pantalla
    private void Movimiento()
    {

        //Detecta que estoy tocando la pantalla con el dedo
        if (Input.touchCount > 0)
        {
            //En que posicion de la X estamos tocando
            float touchScreamPositionX = Input.touches[0].position.x;
            //Cual es el centro de la pantalla
            float screamCenter = Screen.width / 2;

            //Detecta que el lugar donde estoy tocando con el dedo es menor al centro para mover el personaje
            if (touchScreamPositionX < screamCenter)
            {

                //Mueve el personaje a la izquierda
                transform.Translate(-Velocidad * Time.deltaTime, 0, 0);
                //Activa las particulas del derrape derecho al moverse a la izquierda
                DerrapeIZQ.SetActive(false);
                DerrapeDER.SetActive(true);

            }
            //Detecta que el lugar donde estoy tocando con el dedo es mayor al centro para mover el personaje0
            if (touchScreamPositionX > screamCenter)
            {

                //Mueve el personaje a la derecha
                transform.Translate(Velocidad * Time.deltaTime, 0, 0);
                //Activa las partiuclas del derrape izquierdo al moverse a la derecha
                DerrapeIZQ.SetActive(true);
                DerrapeDER.SetActive(false);

            }

        }
        

    }
    //Void para mejor puntuacion 
    private void CheckBestScore()
    {

        //Sirve para guardar la mejor puntuacion en una tabla local para manetenerla
        if (Puntos >= PlayerPrefs.GetInt("bestScore"))
        {
            //Guarda la maxima puntuacion en el computador
            PlayerPrefs.SetInt("bestScore", Puntos);
            //Aumenta la puntuacion maxima
            //bestScore = Puntos;
            PlayerPrefs.DeleteKey("bestScore");

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
