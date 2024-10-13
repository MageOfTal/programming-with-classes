using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

class prompt
{
    //attributes (member variables)

    public List<string> promptList = [
            "What made you smile today?",
            "Describe a recent challenge and what you learned from it.",
            "What are three things you’re grateful for right now?",
            "How do you define success for yourself?",
            "What are your current goals, and what steps can you take to achieve them?",
            "Write about a person who inspires you and why.",
            "What is one thing you wish you could change about your life?",
            "How do you feel about your current work or studies?",
            "What are your favorite self-care activities?",
            "What is a memory that brings you joy?"];
    public string SelectPrompt()
    {
        Random randomNumbers = new();
        int promptNum = randomNumbers.Next(0, promptList.Count());
        return promptList[promptNum];
    }

}