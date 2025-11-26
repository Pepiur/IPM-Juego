using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TimeData timeData;
    public TextMeshProUGUI displayTiempo;
    public Button botonIniciar;

    bool contando = false;
    float tiempoRestante;

    void Start()
    {
        botonIniciar.onClick.AddListener(IniciarTemporizador);
    }

    void Update()
    {
        if (!contando)
        {
            // Mostrar el tiempo configurado antes de iniciar
            displayTiempo.text = $"{timeData.minutos:00}:{timeData.segundos:00}";
            return;
        }

        // Temporizador en marcha
        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante > 0)
        {
            int m = Mathf.FloorToInt(tiempoRestante / 60);
            int s = Mathf.FloorToInt(tiempoRestante % 60);

            displayTiempo.text = $"{m:00}:{s:00}";
        }
        else
        {
            contando = false;
            displayTiempo.text = "¡FIN!";
        }
    }

    void IniciarTemporizador()
    {
        tiempoRestante = timeData.minutos * 60 + timeData.segundos;
        contando = tiempoRestante > 0;
    }
}
