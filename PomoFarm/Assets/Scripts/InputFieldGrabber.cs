using UnityEngine;
using TMPro;

public class InputFieldGrabber : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("the value we got from the input field")]
    [SerializeField] private string inputText;


    public void GrabeFromInputField (string input)
    {
        inputText = input;
        Debug.Log(gameObject.GetComponent<TextMeshPro>().text.);
        
    }

    public void TakeInfoButton()
    {

    }

}
