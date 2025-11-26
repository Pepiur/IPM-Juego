using UnityEngine;
using UnityEngine.SceneManagement;
public class GestorScenas : MonoBehaviour
{
    private TimeData tiempo;

    public void CargarIncio()
    {
        SceneManager.LoadScene(0);
   
    }
    public void CargarJuego()
    {
        SceneManager.LoadScene(1);
    }
    public void CargarAjustes()
    {
        SceneManager.LoadScene(2);
    }

    public void CargarPlanificar()
    {
        SceneManager.LoadScene(3);
    }

    public void CargarCalendario()
    {
        SceneManager.LoadScene(4);
    }
    public void CargarTiempoEstudio()
    {
        SceneManager.LoadScene(5);
    }

    public void CargarPersonalizar()
    {
        SceneManager.LoadScene(6);
    }
    public void DestuirObjeto()
    {
        tiempo = FindObjectOfType<TimeData>();
        DestroyObject(tiempo);
    }
}
