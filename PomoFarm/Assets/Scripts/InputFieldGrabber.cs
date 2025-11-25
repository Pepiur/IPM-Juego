using UnityEngine;
using TMPro;
using System.IO;
using JetBrains.Annotations;

public class InputFieldGrabber : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("the value we got from the input field")]
    [SerializeField] private string inputText;

    [SerializeField] private TMP_InputField text;

    [SerializeField] private Calendar calendario;


    public class Mensaje
    {
        public string dia;
        public int id;
        public string mensaje;
    }

    public void GrabeFromInputField (string input)
    {
        calendario.GuardarInfo(input);
        text.text = "";
    }

    

}
