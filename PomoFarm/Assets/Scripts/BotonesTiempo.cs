using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private int valorTimer = 0;
    public int Tiempo;
    public void SetTimer()
    {
        Tiempo = valorTimer;
    }
}
