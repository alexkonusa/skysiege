using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveMachine : MonoBehaviour
{

    public float startTimer;
    public float maxTimer;
    public int waveCounter = 0;
    public Text waveTimerText;
    public Text waveTimer;

    public bool startWave = false;
    public bool test = false;

    WaveManager waveManager;

    void Start()
    {

        waveManager = GameObject.Find("GameManagers").GetComponent<WaveManager>();
        StartCoroutine(timer(45f));

        maxTimer = startTimer;
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
            waveTimerText.text = "Next Wave Starts In: ";
            waveTimer.text = "" + Mathf.Round(startTimer);

            if (startTimer < 0)
            {

                startWave = true;
                waveManager.CalculatingNumberOfShipsToSpawn(waveCounter);

                waveTimerText.text = "";
                waveTimer.text = "";
		startTimer = maxTimer;

            }

        }
    }

     public void CheckIfThereAreNoEnemiesLeft()
    {

        if (startWave == true && waveManager.CurrentActiveEnemies.Count == 0)
        {

            startWave = false;
            waveCounter++;
            StartWave();

        }

    }

    IEnumerator timer(float time)
    {

        while (true)
        {
            yield return new WaitForSeconds(time);
            startTimer = maxTimer;
            CheckIfThereAreNoEnemiesLeft();

        }
    }
}
