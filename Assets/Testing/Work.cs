using System.Collections.Generic;

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

    public string[] getHobbyNames()
    {
        return HobbiesSeparatedTemp;
    }

    public void SplitToArray()
    {
        CoursesSeparated = Courses.Split(',');
        HobbiesSeparatedTemp = Hobbies.Split(',');
        IntelligencesSeparatedTemp = Intelligences.Split(',');

        int counter = 0;
        foreach (string intelligence in IntelligencesSeparatedTemp)
        {
            IntelligencesSeparatedTemp[counter] = intelligence.Trim();
            counter++;
        }

        for (int i = 0; i < HobbiesSeparatedTemp.Length; i++)
        {
            HobbiesSeparatedTemp[i] = HobbiesSeparatedTemp[i].Trim();
        }


        for (int i = 0; i < IntelligencesSeparatedTemp.Length; i++)
        {
            ToEnum(IntelligencesSeparatedTemp[i]);
        }
    }

    public void AddHobbyInfo(Hobby hobby)
    {
        HobbiesSeparated.Add(hobby);
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

    public class WorkList
    {
        public Work[] WorkwithDetails;
    }
}