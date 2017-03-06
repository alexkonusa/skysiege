using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FUCKTHEAI : MonoBehaviour
{

    public List<GameObject> currentActiveEnemies;

    public Button killAI;
    public Button SpawnWave;

    WaveManager wavemanager;

    // Use this for initialization
	void Start ()
    {

        StartCoroutine(timer(5f));
        SpawnWave.interactable = false;

        wavemanager = GameObject.Find("GameManagers").GetComponent<WaveManager>();


    }

    public void SpawnAI()
    {
        StartCoroutine(timer(2f));
        killAI.interactable = true;
        SpawnWave.interactable = false;

        wavemanager.CalculatingNumberOfShipsToSpawn(0);


    }

    public void KillAi()
    {

        foreach (GameObject enemy in currentActiveEnemies.ToArray())
        {

            Destroy(enemy.gameObject);
            killAI.interactable = false;
            SpawnWave.interactable = true;

        }

    }

    IEnumerator timer(float time)
    {

        yield return new WaitForSeconds(time);
        currentActiveEnemies = new List<GameObject>( GameObject.FindGameObjectsWithTag("Enemy"));


    }
}
