using UnityEngine;

public class TimeData : MonoBehaviour
{
    public int minutos = 0;
    public int segundos = 0;

    public int minutosDescanso = 0;
    public int segundosDescanso = 0;

    public bool esEstudio = true;

    public TimeData(int minutos, int segundos, int minutosDescanso, int segundosDescanso, bool esEstudio)
    {
        this.minutos = minutos;
        this.segundos = segundos;
        this.minutosDescanso = minutosDescanso;
        this.segundosDescanso = segundosDescanso;
        this.esEstudio = esEstudio;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public void setMinutos(int valor)
    {
        minutos = valor;
    }
    public void setSegundos(int valor)
    {
        segundos = valor;
    }
    public void setMinutosDescanso(int valor)
    {
        minutosDescanso = valor;
    }
    public void setSegundosDescanso(int valor)
    {
        segundosDescanso = valor;
    }
}
