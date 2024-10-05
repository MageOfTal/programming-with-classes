using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

class prompt
{
    //attributes (member variables)

    public List<string> promptList = ["thing","otherthing","lastthing"];
    public string SelectPrompt()
    {
        Random randomNumbers = new();
        int promptNum = randomNumbers.Next(0, promptList.Count());
        return promptList[promptNum];
    }

}