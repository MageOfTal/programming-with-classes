class promptTest
{
    //attributes (member variables)

    public string headWear;

    public string handWear;

    public string footWear;

    public string torsoWear;

    public string legWear;

    public string extraWear;

    //behaviors (member functions or *methods*)

    public string ShowWardrobe()
    {
        string result = "";
        result += "\nHeadwear: " + headWear;
        result += "\nHandwear: " + handWear;
        result += "\nFootwear: " + footWear;
        result += "\nTorsowear: " + torsoWear;
        result += "\nLegwear: " + legWear;
        result += "\nExtrawear: " + extraWear;

        Console.WriteLine(result + "\n");
        return "test";
    }

}