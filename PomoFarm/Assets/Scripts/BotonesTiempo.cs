using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BotonesTiempo : MonoBehaviour
{
    public TimeData timeData;

    public Button sumarMin;
    public Button restarMin;
    public Button sumarSeg;
    public Button restarSeg;

    public TextMeshProUGUI displayTiempo;

    void Start()
    {
        sumarMin.onClick.AddListener(() => { timeData.minutos++; ActualizarTexto(); });
        restarMin.onClick.AddListener(() => { timeData.minutos = Mathf.Max(0, timeData.minutos - 1); ActualizarTexto(); });

        sumarSeg.onClick.AddListener(() =>
        {
            timeData.segundos = (timeData.segundos + 1) % 60;
            ActualizarTexto();
        });

        restarSeg.onClick.AddListener(() =>
        {
            timeData.segundos = (timeData.segundos - 1 + 60) % 60;
            ActualizarTexto();
        });

        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        displayTiempo.text = $"{timeData.minutos:00}:{timeData.segundos:00}";
    }
}
