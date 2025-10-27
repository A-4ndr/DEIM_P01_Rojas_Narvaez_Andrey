using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    static LevelGenerator instance;     //Creamos un static level generator para generar el Singleton del levelgenerator
    public List<GameObject> Piece;      //Variable para la pieza

    //Se ejecutan antes del start
    private void Awake()
    {
        //Iniciacion del singleton
        instance = this;

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //variable publica para generar piezas en otro codigo
    public static void Añadir()
    {
        //Crea una pieza otra vez de forma aleatoria en la misma posicion en la que estaba (Quaternion.identity "Sirve para que no altere la rotacion")
        Instantiate(instance.Piece[Random.Range(0, instance.Piece.Count)], new Vector3(0, -30f, 0), Quaternion.identity);

    }
}
