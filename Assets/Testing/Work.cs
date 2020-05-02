using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Work
{
    public string Name;
    public string Intelligences;
    public string Description;
    public string Courses;
    public string Hobbies;

    private string[] CoursesSeparated;
    private string[] HobbiesSeparatedTemp;
    private string[] IntelligencesSeparatedTemp;

    public List<Hobby> HobbiesSeparated = new List<Hobby>(); 
    public List<Intelligences> IntelligencesSeparated = new List<Intelligences>();

    public void SplitToArray()
    {
        CoursesSeparated = Courses.Split(',');
        HobbiesSeparatedTemp = Hobbies.Split(',');
        IntelligencesSeparatedTemp = Intelligences.Split(',');

        int counter = 0;
        //foreach (string hobby in HobbiesSeparatedTemp)
        //{
        //    HobbiesSeparated[counter].Name = hobby;
        //    counter++;
        //}

        counter = 0;
        foreach (string intelligence in IntelligencesSeparatedTemp)
        {
            IntelligencesSeparatedTemp[counter] = intelligence.Trim();
            counter++;
        }

        for (int i = 0; i < IntelligencesSeparatedTemp.Length; i++)
        {
            ToEnum(IntelligencesSeparatedTemp[i]);
        }
    }

    private void ToEnum(string IntelligenceName)
    {
        switch (IntelligenceName)
        {
            case "Visual-Spatial":
                IntelligencesSeparated.Add(global::Intelligences.VisualSpatial);
                break;

            case "Musical":
                IntelligencesSeparated.Add(global::Intelligences.Musical);
                break;

            case "Logical-Mathematical":
                IntelligencesSeparated.Add(global::Intelligences.LogicalMathematical);
                break;

            case "Linguistic-Verbal":
                IntelligencesSeparated.Add(global::Intelligences.LinguisticVerbal);
                break;

            case "Naturalistic":
                IntelligencesSeparated.Add(global::Intelligences.Naturalistic);
                break;

            case "Interpersonal":
                IntelligencesSeparated.Add(global::Intelligences.Interpersonal);
                break;

            case "Intrapersonal":
                IntelligencesSeparated.Add(global::Intelligences.Intrapersonal);
                break;

            case "Bodily-Kinesthetic":
                IntelligencesSeparated.Add(global::Intelligences.BodilyKinesthetic);
                break;
        }
    }
}