using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Assessment Games Manager")]
public class AssessmentManager : ScriptableObject
{
    [SerializeField] private List<string> GamesList;
    [SerializeField] private WorkInfoManager workInfoManager;
    //[SerializeField] private 

    private int searchCounter = 0;
    private int sortingCounter = 0;
    private int intelligenceCounter = 0;
    private int sortedLength = 0;
    private int gameCounter = 0;
    private Work workSortRankUp;
    private Work workSortRankDown;
    public Work.WorkList workinfo { get; set;}

    public Dictionary<Intelligences, int> IntelligencesScored = new Dictionary<Intelligences, int>()
    {
        {Intelligences.BodilyKinesthetic, 0},
        {Intelligences.Interpersonal, 0},
        {Intelligences.Intrapersonal, 0},
        {Intelligences.Musical, 0},
        {Intelligences.Naturalistic, 0},
        {Intelligences.VisualSpatial, 0},
        {Intelligences.LogicalMathematical, 0}
    };

    private List<Intelligences> IntelligencesRanked = new List<Intelligences>();

    //public List<Intelligences> IntelligencesList = 
    public void RankIntelligences()
    {
        foreach (KeyValuePair<Intelligences, int> intelligenceWithScore in IntelligencesScored.OrderByDescending(key => key.Value))
        {
            IntelligencesRanked.Add(intelligenceWithScore.Key);
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(GamesList[gameCounter]);
        gameCounter++;

        if (gameCounter == GamesList.Count - 1)
        {
            RankIntelligences();
        }
    }

    public Work.WorkList sortWorkByIntelligence(Work.WorkList workListWithInfo)
    {
        for (intelligenceCounter = 0; intelligenceCounter < IntelligencesRanked.Count; intelligenceCounter++)
        {
            for (searchCounter = 0; searchCounter < sortedLength; searchCounter++)
            {
                if (intelligenceCounter < workListWithInfo.WorkwithDetails[searchCounter].IntelligencesSeparated.Count)
                {
                    if (workListWithInfo.WorkwithDetails[searchCounter].IntelligencesSeparated[intelligenceCounter] == IntelligencesRanked[intelligenceCounter])
                    {
                        workSortRankUp = workListWithInfo.WorkwithDetails[searchCounter];
                        workSortRankDown = workListWithInfo.WorkwithDetails[sortingCounter];
                        workListWithInfo.WorkwithDetails[sortingCounter] = workSortRankUp;
                        workListWithInfo.WorkwithDetails[searchCounter] = workSortRankDown;

                        sortingCounter++;
                    }
                }
            }

            sortedLength = sortingCounter;
            sortingCounter = 0;
        }

        return workListWithInfo;
    }
}
