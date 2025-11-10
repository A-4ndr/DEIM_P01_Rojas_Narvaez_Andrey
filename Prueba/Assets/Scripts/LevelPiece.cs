using UnityEngine;

public class LevelPiece : MonoBehaviour
{
    public float Velocidad = 5f;        //Creamos vairable de velocidad en float
    public float Tamaño;                //Creamos una variable de tamaño en float

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento automatico de la escena
        transform.Translate(0, Velocidad * Time.deltaTime, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Detecta que el personaje colisiona con un objeto con el tag ( se puede usar el .tag normal de toda la vida)
        if (collision.gameObject.CompareTag("DestruccionPieza"))
        {
            //Destruye al personaje al tocar el objeto
            Destroy(gameObject);

        }
        else if (collision.CompareTag("Respawn"))   //Y si toca el otro tag
        {
            //Añade niveles desde el codigo de LevelGenerator (La crea desde la posicion anterior de la ultima pieza)
            LevelGenerator.Añadir(transform.position - new Vector3(0, Tamaño, 0));                     

        }

    }
}
