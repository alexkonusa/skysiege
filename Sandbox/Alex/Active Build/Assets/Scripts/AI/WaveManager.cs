using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{ 

    public List<WaveClass> WaveData = new List<WaveClass>();

    public int index = 0;

    public int numShip1ToSpawn;
    public int numShip2ToSpawn;
    public int numShip3ToSpawn;
    public int numShip4ToSpawn;
    public int numShip5ToSpawn;

    public GameObject enemyShip1;
    public GameObject enemyShip2;
    public GameObject enemyShip3;
    public GameObject enemyShip4;
    public GameObject enemyShip5;

    public int test = 0;

    public List<GameObject> StoreOurEnemies = new List<GameObject>();

    Grid_Spawner gridSpawner;

    private void Start()
    {

        gridSpawner = GameObject.FindGameObjectWithTag("Map").GetComponent<Grid_Spawner>();

        CalculatingNumberOfShipsToSpawn(index);

    }

    void SpawnOurEnemies()
    {

        foreach (GameObject enemy in StoreOurEnemies.ToArray())
        {

            int spawnPoint = Random.Range(0, (gridSpawner.hexLayerThree.Count));
            GameObject ourPickedHex = gridSpawner.hexLayerThree[spawnPoint].gameObject;

            GameObject enemyToInst = (GameObject)Instantiate(enemy.gameObject, gridSpawner.hexLayerThree[spawnPoint].transform.position, 
                gridSpawner.hexLayerThree[spawnPoint].transform.rotation);

            StoreOurEnemies.Remove(enemy.gameObject);
            test++;


        }

    }

    void CollectOurEnemies()
    {

        for (int i = 0; i < numShip1ToSpawn; i++)
        {

            StoreOurEnemies.Add(enemyShip1);

        }

        for (int i = 0; i < numShip2ToSpawn; i++)
        {

            StoreOurEnemies.Add(enemyShip2);

        }

        for (int i = 0; i < numShip3ToSpawn; i++)
        {

            StoreOurEnemies.Add(enemyShip3);

        }

        for (int i = 0; i < numShip4ToSpawn; i++)
        {

            StoreOurEnemies.Add(enemyShip4);

        }

        for (int i = 0; i < numShip5ToSpawn; i++)
        {

            StoreOurEnemies.Add(enemyShip5);

        }

        SpawnOurEnemies();
    }

    public void CalculatingNumberOfShipsToSpawn(int Index)
    {

        float ship1Percent;
        float ship2Percent;
        float ship3Percent;
        float ship4Percent;
        float ship5Percent;

        ship1Percent = (WaveData[Index].ship1Precentage / 100);
            Mathf.Round(ship1Percent * 100);
        ship2Percent = (WaveData[Index].ship2Precentage / 100);
            Mathf.Round(ship2Percent * 100);
        ship3Percent = (WaveData[Index].ship3Precentage / 100);
            Mathf.Round(ship3Percent * 100);
        ship4Percent = (WaveData[Index].ship4Precentage / 100);
            Mathf.Round(ship4Percent * 100);
        ship5Percent = (WaveData[Index].ship5Precentage / 100);
            Mathf.Round(ship5Percent * 100);

        numShip1ToSpawn = (int)(ship1Percent * WaveData[Index].numberOfShips);
        numShip2ToSpawn = (int)(ship2Percent * WaveData[Index].numberOfShips);
        numShip3ToSpawn = (int)(ship3Percent * WaveData[Index].numberOfShips);
        numShip4ToSpawn = (int)(ship4Percent * WaveData[Index].numberOfShips);
        numShip5ToSpawn = (int)(ship5Percent * WaveData[Index].numberOfShips);

        StartCoroutine(waitTimer(1f));
    }

    IEnumerator waitTimer(float time)
    {

        yield return new WaitForSeconds(time);
        CollectOurEnemies();
    }
}
