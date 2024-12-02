using System;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> bible = new List<Scripture>
        {
            new Scripture("For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man.", 
                        "Moses", 1, 39),

            new Scripture("If ye love me, keep my commandments.", 
                        "John", 14, 15),

            new Scripture("Adam fell that men might be; and men are, that they might have joy.", 
                        "2 Nephi", 2, 25)
        
        };

        Random random = new();

        Scripture selectedVerse = bible[random.Next(bible.Count())];

        selectedVerse.memory();

        
    }
    
}