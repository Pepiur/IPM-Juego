using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeButtons : MonoBehaviour
{
    public TimeData timeData; // Script compartido

    [Header("Minutos")]
    public Button sumarMin;
    public Button restarMin;
    public TextMeshProUGUI displayMin;

    [Header("Segundos")]
    public Button sumarSeg;
    public Button restarSeg;
    public TextMeshProUGUI displaySeg;

    [Header("Descanso Min")]
    public Button sumarMinDescanso;
    public Button restarMinDescanso;
    public TextMeshProUGUI displayMinDescanso;

    [Header("Descanso Seg")]
    public Button sumarSegDescanso;
    public Button restarSegDescanso;
    public TextMeshProUGUI displaySegDescanso;

    
    void Start()
    {
        // MINUTOS
        sumarMin.onClick.AddListener(() =>
        {
            timeData.setMinutos(Mathf.Min(99, timeData.minutos + 1));
            ActualizarTexto();
        });

        restarMin.onClick.AddListener(() =>
        {
            timeData.setMinutos(Mathf.Max(0, timeData.minutos - 1));
            ActualizarTexto();
        });

        // SEGUNDOS
        sumarSeg.onClick.AddListener(() =>
        {
            timeData.setSegundos((timeData.segundos + 1) % 60);
            ActualizarTexto();
        });

        restarSeg.onClick.AddListener(() =>
        {
            timeData.setSegundos((timeData.segundos - 1 + 60) % 60);
            ActualizarTexto();
        });

        sumarMinDescanso.onClick.AddListener(() =>
        {
            timeData.setMinutosDescanso(Mathf.Min(99, timeData.minutosDescanso + 1));
            ActualizarTexto();
        });

        restarMinDescanso.onClick.AddListener(() =>
        {
            timeData.setMinutosDescanso(Mathf.Max(0, timeData.minutosDescanso - 1));
            ActualizarTexto();
        });

        // DESCANSO SEGUNDOS
        sumarSegDescanso.onClick.AddListener(() =>
        {
            timeData.setSegundosDescanso((timeData.segundosDescanso + 1) % 60);
            ActualizarTexto();
        });

        restarSegDescanso.onClick.AddListener(() =>
        {
            timeData.setSegundosDescanso((timeData.segundosDescanso - 1 + 60) % 60);
            ActualizarTexto();
        });

        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        displayMin.text = $"{timeData.minutos:00}";
        displaySeg.text = $"{timeData.segundos:00}";

        displayMinDescanso.text = $"{timeData.minutosDescanso:00}";
        displaySegDescanso.text = $"{timeData.segundosDescanso:00}";
    }
}