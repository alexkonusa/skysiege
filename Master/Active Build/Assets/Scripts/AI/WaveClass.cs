using UnityEngine;
using System.Collections;

[System.Serializable]
public class WaveClass
{

    public string roundName;
    public int numberOfShips;
    public float ship1Precentage;
    public float ship2Precentage;
    public float ship3Precentage;
    public float ship4Precentage;
    public float ship5Precentage;

    public WaveClass(string roundName,int numberOfShips, float ship1Precentage, float ship2Precentage, 
        float ship3Precentage, float ship4Precentage, float ship5Precentage)
    {

        roundName = roundName;
        numberOfShips = numberOfShips;
        ship1Precentage = ship1Precentage;
        ship2Precentage = ship2Precentage;
        ship3Precentage = ship3Precentage;
        ship4Precentage = ship4Precentage;
        ship5Precentage = ship5Precentage;

    }
}
