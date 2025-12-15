using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;                              //Libreria del Dotween
using UnityEngine.UI;                           //Libreria del interfaz u know

public class MenuPrincipal : MonoBehaviour
{
    public RectTransform BotonEmpezar;  //Referencia al boton de empezar
    public Ease BotonEmpezarEase;       //Referencia para poner transiciones o animaciones (algo asi)
    public Image FadeScreen;            //Referencia para hacer un fade en cambio de escenas
    public RectTransform BotonJugar;
    public Ease BotonJugarEase;
    public RectTransform BotonSalir;
    public Ease BotonSalirEase;
    [SerializeField]
    float Duracion;                     //Cambia la duraicon del efecto 

    public void Start()
    {        
        //Hace un fade en el cambio de escena, cambiando de opaco a transparente en 2 segundos
        FadeScreen.DOFade(0, 2).OnComplete(() =>
        {
            //Hace que el boton aumente su tamaño al iniciar el juego y ejecute animaciones en loop (El set loops es para que sea en bucle. El -1 hace que sea infinito)
            //El OnComplete y (() => {}); hace que cargue lo que ponga dentro de las llaves, en esto caso que cargue la escena 1
            BotonEmpezar.DOScale(2, Duracion).SetEase(BotonEmpezarEase).OnComplete(() =>
            {
                //Hace que el boto empiece a vibrar justo en el momento que termina la animación
                BotonEmpezar.DOShakePosition(1, 10, vibrato: 100).SetLoops(-1);
                BotonJugar.DOScale(1, 2).SetEase(BotonJugarEase);
                BotonSalir.DOScale(1, 2).SetEase(BotonSalirEase);

            });

        });
        

    }
    //Funcion para cargar una escena
    public void LoadGame()
    {
        //Hace un fade en el cambio de escena, cambiando de opaco a transparente en 2 segundos
        FadeScreen.DOFade(1, 2).OnComplete(() => 
        {            
            //Carga la escena del juego
            SceneManager.LoadScene("Prueba");
        });
        

    }
   
}
