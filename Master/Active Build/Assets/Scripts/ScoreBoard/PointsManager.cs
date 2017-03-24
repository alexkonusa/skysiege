using UnityEngine;
using System.Collections;

public class PointsManager : MonoBehaviour
{

    public static void AddPoints(int pointsToAdd)
    {

        StatsManager.playerPoints += pointsToAdd;

    }

}
