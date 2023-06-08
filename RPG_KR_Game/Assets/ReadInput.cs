using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    private const string filePath = "start_data.txt";

    private int grassCount = 400;
    private int wolvesCount = 200;
    private int rabbitsCount = 300;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadStringInputGrass(string s)
    {
        grassCount = int.Parse(s);
    }
    
    public void ReadStringInputWolves(string s)
    {
        wolvesCount = int.Parse(s);
    }
    
    public void ReadStringInputRabbits(string s)
    {
        rabbitsCount = int.Parse(s);
    }

    public void WriteData()
    {
        File.WriteAllText(filePath, string.Empty);
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(grassCount);
            writer.WriteLine(wolvesCount);
            writer.WriteLine(rabbitsCount);
        }
        Debug.Log("Data was written inside of file!");
    }
    
}

