using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    private string privateKey = "jfsdhfiusdhfisghiuehjet8w95y94erhgufihgeriu";
    public string addScoreURL = "http://alex.cainkilgore.com/submit.php?";
    public string scoreURLs = "http://alex.cainkilgore.com/scores.php";
    public string username = "YOLO";
    public int scoring = 32423545;
    public Text scoreBoard;

    // Use this for initialization
    void Start ()
    {

        StartCoroutine(AddScore(username, scoring));
        Debug.Log("This work?");


    }

    IEnumerator AddScore(string name, int score)
    {


        string scoreURL = addScoreURL + "key=" + privateKey + "&player=" + name + "&score=" + score;

        WWW scorePost = new WWW(scoreURL);
        yield return scorePost;

        if (scorePost.error != null)
        {

            print("There was an Error" + scorePost.error);

        }
    }
}
