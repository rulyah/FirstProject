using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class Main : MonoBehaviour
{
    public TMP_InputField field;
    
    public void OnClick()
    {
        Debug.Log(field.text);
    }
    
    double lengthRoom = 2.5;
    double widthRoom = 2.5;
    

    public void CalculateSizeRoom(double width, double length)
    {
        double squer = length * width;
        double perimeter = (length + width) * 2;
        Debug.Log("squere" + squer + " perimeter" + perimeter);
    }
    
        void Start()
        {
            
            CalculateSizeRoom(lengthRoom, widthRoom);

            // int randomNum = Random.Range(1, 50);
            // Debug.Log("The number is: "+ randomNum;
            // for(int i = 0; i <= randomNum; i++)
            // if (i == randomNum)
            // Debug.Log("Password is: " + i);
        }
        
        
        void Update()
        {
        }
    }