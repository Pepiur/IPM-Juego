using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TimeData timeData;

    public TextMeshProUGUI displayTiempo;
    public TextMeshProUGUI titulo;

    private float tiempoRestante;
    private bool contando = false;

    void Start()
    {
        timeData = FindObjectOfType<TimeData>();
        if(timeData == null)
        {
            timeData = new TimeData(0,10,0,5, true);
        }
        Iniciar();
    }

    void Update()
    {
        if (!contando)
        {
            MostrarTiempoActual();
            return;
        }

        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante > 0)
        {
            int m = Mathf.FloorToInt(tiempoRestante / 60);
            int s = Mathf.FloorToInt(tiempoRestante % 60);
            displayTiempo.text = $"{m:00}:{s:00}";
        }
        else
        {
            CambiarFase();
        }
    }

    void Iniciar()
    {
        if (timeData.esEstudio)
        {
            titulo.text = "Tiempo de estudio";
            tiempoRestante = timeData.minutos * 60 + timeData.segundos;
        }
        else
        {
            titulo.text = "Tiempo de descanso";
            tiempoRestante = timeData.minutosDescanso * 60 + timeData.segundosDescanso;
        }
         

        contando = tiempoRestante > 0;
    }

    void CambiarFase()
    {
        contando = false;
        timeData.esEstudio = !timeData.esEstudio;
        Iniciar();
    }

    void MostrarTiempoActual()
    {
        if (timeData.esEstudio)
            displayTiempo.text = $"{timeData.minutos:00}:{timeData.segundos:00}";
        else
            displayTiempo.text = $"{timeData.minutosDescanso:00}:{timeData.segundosDescanso:00}";
    }
}
