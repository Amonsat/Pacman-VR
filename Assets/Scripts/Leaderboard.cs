using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour 
{
    public Text[] names;
    public Text[] scores;

    void OnEnable() {
        GameManager.instance.isMenu = true;
        UpdateLeaderboard();
    }

	public void UpdateLeaderboard()
    {
        for (var i = 0; i < names.Length; i++)
        {
            var leaderName = PlayerPrefs.GetString("LeaderName_" + i);
            names[i].text = leaderName;

            var leaderScore = PlayerPrefs.GetInt("LeaderScore_" + i);            
            scores[i].text = leaderScore.ToString("D5");
        }
    }
    
    public void SaveScore(string leaderName, int leaderScore)
    {
        var leaderNames = new List<string>();
        var leaderScores = new List<int>();

        for (var i = 0; i < names.Length; i++)
        {
            leaderNames.Add(PlayerPrefs.GetString("LeaderName_" + i, ""));
            leaderScores.Add(PlayerPrefs.GetInt("LeaderScore_" + i, 0));
        }

        for (var i = 0; i < names.Length; i++)
        {
            if (leaderScore > leaderScores[i])
            {
                leaderNames.Insert(i, leaderName);
                leaderScores.Insert(i, leaderScore);
                break;
            }
        }

        for (var i = 0; i < names.Length; i++)
        {
            PlayerPrefs.SetString("LeaderName_" + i, leaderNames[i]);
            PlayerPrefs.SetInt("LeaderScore_" + i, leaderScores[i]);
        }
    }
}
