using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    private string input;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadStringInput(string s)
    {
        int numOfGrass = int.Parse(s);
        Debug.Log(input);
    }
    
    public void ReadStringInputWolves(string s)
    {
        input = s;
        Debug.Log(input);
    }
    
    public void ReadStringInputRabbits(string s)
    {
        input = s;
        Debug.Log(input);
    }
}

