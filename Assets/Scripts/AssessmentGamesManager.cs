using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Assessment Games Manager")]
public class AssessmentGamesManager : ScriptableObject
{
    public Dictionary<Intelligences, int> IntelligencesScored = new Dictionary<Intelligences, int>()
    {
        {Intelligences.BodilyKinesthetic, 28},
        {Intelligences.Interpersonal, 30},
        {Intelligences.Intrapersonal, 22},
        {Intelligences.Musical, 28},
        {Intelligences.Naturalistic, 23},
        {Intelligences.VisualSpatial, 25},
        {Intelligences.LogicalMathematical, 27}
    };

    private List<Intelligences> IntelligencesRanked = new List<Intelligences>();

    //public List<Intelligences> IntelligencesList = 
    public List<string> GamesList;

    public void RankIntelligences()
    {
        foreach (KeyValuePair<Intelligences, int> intelligenceWithScore in IntelligencesScored.OrderByDescending(key => key.Value))
        {
            IntelligencesRanked.Add(intelligenceWithScore.Key);
        }

    }

    private void LoadGame(string GameName)
    {

    }
}
