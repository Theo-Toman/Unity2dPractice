using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayItemDescription : MonoBehaviour
{
    //[SerializeField] private 

    private void Start()
    {

    }
    
    public void DisplayInformation(string thing)
    {
        Debug.Log(thing);
    }

    public void HideInformation(string thing1)
    {
        Debug.Log(thing1);
    }
    
}
