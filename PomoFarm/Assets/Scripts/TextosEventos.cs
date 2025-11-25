using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextosEventos : MonoBehaviour
{

    public Calendar calendario;

    public GameObject eventos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateContend()
    {
        deleteHijos();
        for (int i = 0; i < calendario.listaMensajes.mensajes.Count; i++)
        {
            GameObject evento;
            evento = Instantiate(eventos, this.transform.position, Quaternion.identity, this.transform);
            int dia = calendario.listaMensajes.mensajes[i].dia;
            int mes = calendario.listaMensajes.mensajes[i].mes;
            string msg = calendario.listaMensajes.mensajes[i].mensaje;
            int id = i;
            evento.GetComponent<TMP_Text>().text = "Evento " + id.ToString() + " del día " + dia.ToString() + "/" + mes.ToString() + ": " + msg; 
            
        }
    }
    public void deleteHijos()
    {
        int hijos = this.transform.childCount;
        for (int i= 0; i < hijos; i++)
        {
            Debug.Log(this.transform.GetChild(i).gameObject);
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }
}
