using System.Linq;
using System.Transactions;
using System.Threading;
public class Reflection : Activity
{

    //attributes (member variables)

    string[] _reflectionQuestionsExperience =
    [
        "Who is a person that you have helped this week?",
        "What is a goal you recently worked toward, and how?",
        "What is an experience you are grateful for?",
        "When was a time you overcame a challenge?",
        "What is a memory that brings you joy?"
    ];

    string [] _reflectionQuestionsPersonal = 
    [
        "Who is a personal hero you wish to emulate with your life?",
        "What is one thing you could do better starting today?",
        "What is an important goal in your life?",
    ];

    string[] _experienceReflections =
    [
        "What made this experience meaningful?",
        "How did you feel afterwards?",
        "Why did it happen?",
        "Would you have done anything different?",
        "Have you had a similar experience?"
    ];

    string[] _personalReflections =
    [
        "What is the most important aspect?",
        "What will you gain if you succeed?",
        "What will happen if you fail?",
        "What has held you back from this so far?"
    ];
    

    //behaviors (member functions or *methods*)

    public Reflection()
    {
        SetPrompt("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        SetUniqueBehavior(ReflectionActivity);
    }

    public void ReflectionActivity(int time)
    {
        Console.WriteLine("Consider the following prompt:");

        Random rand = new();
        int selectedList = rand.Next(0,2);

        string [] chosenQuestion;
        string [] chosenQuestions;

        if (selectedList == 0)
        {
            chosenQuestion = _reflectionQuestionsExperience;
            chosenQuestions = _experienceReflections;

        }
        else
        {
            chosenQuestion = _reflectionQuestionsPersonal;
            chosenQuestions = _personalReflections;
        }

        int randomQuestion = rand.Next(0,chosenQuestion.Length);

        Console.WriteLine (chosenQuestion[randomQuestion]);
        Console.WriteLine("\nWhen you have something in mind, press enter.");

        Console.ReadLine();

        Console.Write("Please reflect on the following questions, beginning in: ");
        SecondCountdown(5000);

        DateTime endTime = DateTime.Now.AddSeconds(time);

        Console.Write('\n');

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(chosenQuestions[rand.Next(0,chosenQuestions.Length)]);

            LoadingCircle(10000);
        }

    }
   

}