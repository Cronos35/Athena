using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Work Information Manager")]
public class WorkInfoManager : ScriptableObject
{
    [SerializeField] private TextAsset WorkFile;
    [SerializeField] private TextAsset HobbiesFile;

    private Work.WorkList workinfo;
    private Hobby.HobbyList hobbies;

    public Work.WorkList LoadWorkInformation()
    {
        workinfo = JsonUtility.FromJson<Work.WorkList>(WorkFile.text);
        hobbies = JsonUtility.FromJson<Hobby.HobbyList>(HobbiesFile.text);

        for(int i = 0; i < hobbies.HobbiesWithDetails.Length; i++)
        {
            hobbies.HobbiesWithDetails[i].Name = hobbies.HobbiesWithDetails[i].Name.Trim();
        }

        foreach (Work work in workinfo.WorkwithDetails)
        {
            work.SplitToArray();
            string[] workHobbyNames = work.getHobbyNames();
            
            foreach (string hobbyName in workHobbyNames)
            {
                foreach (Hobby hobby in hobbies.HobbiesWithDetails)
                {
                    if (hobby.Name == hobbyName)
                    {
                        work.AddHobbyInfo(hobby);
                    }
                }
            }
        }

        return workinfo;
    }
}
