using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hobby
{
    public string Work;
    public string Name;
    public string Description;

    private bool IsSelected;

    public class HobbyList
    {
        public Hobby[] HobbiesWithDetails;
    }
}
