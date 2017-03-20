using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveMachine : MonoBehaviour
{

    public float startTimer;
    public int waveCounter = 0;
    public Text waveTimer;

    public bool addToWaveCounter = true; 
    public bool startWave = false;
    public bool checkIfThereAreNoEnemies = true; // if this is true then next wave wont spawn

    WaveManager waveManager;

    void Start()
    {

        waveManager = GameObject.Find("GameManagers").GetComponent<WaveManager>();

    }

    void Update()
    {

        StartWave();

    }

    void StartWave()
    {
        if (startWave == false)
        {

            startTimer -= Time.deltaTime;
            waveTimer.text = "" + Mathf.Round(startTimer);

            if (startTimer < 0)
            {

                startWave = true;
                waveManager.CalculatingNumberOfShipsToSpawn(waveCounter);

                waveTimer.text = "";

                if (startWave == true)
                {


                    CheckIfThereAreNoEnemiesLeft();

                }

            }


        }

    }

    void CheckIfThereAreNoEnemiesLeft()
    {

        if (waveManager.CurrentActiveEnemies.Count == 0 && checkIfThereAreNoEnemies == true)
        {


                checkIfThereAreNoEnemies = false;
                SpawnNextWave(1);
                checkIfThereAreNoEnemies = true;
        }

    }

    void SpawnNextWave(int wave)
    {

        if (checkIfThereAreNoEnemies == false)
        {
            startTimer -= Time.deltaTime;
            waveTimer.text = "" + Mathf.Round(startTimer);

            if (startTimer < 0)
            {

                startWave = true;
                waveManager.CalculatingNumberOfShipsToSpawn(waveCounter);

                waveTimer.text = "";

            }

        }

    }
}
