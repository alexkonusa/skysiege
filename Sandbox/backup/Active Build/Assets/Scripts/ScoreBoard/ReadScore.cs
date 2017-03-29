using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System;

[System.Serializable]
public struct player
{

    public string name;
    public string score;
    public string timestamp;

}


public class ReadScore : MonoBehaviour
{

    public string scoreURLs = "http://alex.cainkilgore.com/scores.php";
    public string json;

    public List<player> test = new List<player> ();

    //userScorePanelVariables
    public Transform userScorePanel;
    public Transform userScoreParent;
    public Text place;
    public Text playerName;
    public Text playerScore;
    public Text submittedDate;

    int index = 0;

    private void Start()
    {

        StartCoroutine(GetScores());
    }

    public void Test()
    {
        for (int i = 0; i < test.Count; i++)
        {
            int indexs = i + 1;
            place.text = "" + indexs;
            playerName.text = test[i].name;
            playerScore.text = test[i].score;
            submittedDate.text = test[i].timestamp;

            Transform testing = (Transform)Instantiate(userScorePanel, userScorePanel.transform.position, userScorePanel.transform.rotation);

            testing.transform.SetParent(userScoreParent, false);
            testing.transform.SetSiblingIndex(indexs);
        }

        //userScoreParent.transform.GetChild(0).transform.SetAsLastSibling();
    }

    public void SrotJson()
    {

        using (StringReader r = new StringReader(json))
        {
            string score;
            while((score = r.ReadLine()) != null)
            {
                try
                {
                    string player1 = score.Split(',')[0];
                    string playerscore = score.Split(',')[1].Split(',')[0];
                    string time = score.Split(',')[2];

                    var testing = new player();
                    testing.name = player1;
                    testing.score = playerscore;
                    testing.timestamp = time;

                    test.Add(testing);

                }
                catch (IndexOutOfRangeException e)
                {
                    // Ignore.
                }
                
            }

            Test();
        }
    }

    //Get our scores from the webpage!
    IEnumerator GetScores()
    {

        WWW scorePost = new WWW(scoreURLs);
        yield return scorePost;

        if (scorePost.error != null)
        {

            print("There was an Error" + scorePost.error);

        }
        else
        {

            json = scorePost.text;
            SrotJson();

        }

    }
 
}
