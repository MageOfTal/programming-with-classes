class Scriptures
{
    //attributes (member variables)

    private Dictionary<string, string> testScriptures = new Dictionary<string, string>
    {
        { "Philippians 4:6-7", "Do not be anxious about anything, but in every situation, by prayer and petition, with thanksgiving, present your requests to God. And the peace of God, which transcends all understanding, will guard your hearts and your minds in Christ Jesus." },
        { "Romans 8:28", "And we know that in all things God works for the good of those who love him, who have been called according to his purpose." },
        { "Jeremiah 29:11", "For I know the plans I have for you, declares the Lord, plans to prosper you and not to harm you, plans to give you hope and a future." },
        { "Isaiah 40:30-31", "Even youths grow tired and weary, and young men stumble and fall; but those who hope in the Lord will renew their strength. They will soar on wings like eagles; they will run and not grow weary, they will walk and not be faint." },
        { "Matthew 11:28-30", "Come to me, all you who are weary and burdened, and I will give you rest. Take my yoke upon you and learn from me, for I am gentle and humble in heart, and you will find rest for your souls. For my yoke is easy and my burden is light." }
    };



    //behaviors (member functions or *methods*)

    public static Dictionary<string,string> get()
    {
        return testScriptures;
    }

    public void set(Dictionary<string,string> newScripture)
    {
        testScriptures = newScripture;
    }

}