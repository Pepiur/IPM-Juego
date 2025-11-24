using UnityEngine;
using TMPro;
using System.IO;

public class InputFieldGrabber : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("the value we got from the input field")]
    [SerializeField] private string inputText;

    [SerializeField] private TMP_InputField text;

    [SerializeField] private Calendar calendario;


    public void GrabeFromInputField (string input)
    {
        inputText = input;
        Debug.Log(inputText);

        text.text = "";
    }

    public void TakeInfoButton()
    {
        //Debug.Log(text.text);
        //text.text = "";
    }

}
