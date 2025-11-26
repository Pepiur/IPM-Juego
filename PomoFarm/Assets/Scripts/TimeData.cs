using UnityEngine;

public class TimeData : MonoBehaviour
{
    public int minutos = 0;
    public int segundos = 0;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
