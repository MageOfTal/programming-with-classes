using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new("243 Maple Ave", "Villeville", "Washington", "USA");
        Address address2 = new("111 Oak Lane", "Bestland", "Oregon", "Japan");
        Gathering gathering = new("Fun Picnic", "Come join eat Our Special Food until you bloat, and further! We will feast. We will feast.", "12/12/24", "12:15 PM", address1, "Thunderstorm");
        Lecture lecture = new("Why YOU are Stupid", "Did you ever wish you were as awesome as Dr. Sigma, winner of the Nobel Prize, an Emmy, two Oscars, and five Olympic events? Well, you can't be! Come learn why!", "12/13/24", "6:30 PM", address2, "Dr. Sigma", 100);
        Reception reception = new("Welcoming Dark Lord Escraznor", "Join us as we usher in a new era with the turn of the year! Returning from being banished in the void dimension for five thousand years is Great Spirit-Render, Consumer of Minds Escraznor!\nCome early to witness the unsealing ceremony, and stick around to submit your will and life energy to the great cause of Evil!", "1/1/25", "12:01 AM", address2, "officialescraznorsociety@outlook.com");
        
        void ShowAll(Event e)
        {
            Console.WriteLine(e.StandardDetails());
            Console.WriteLine(e.FullDetails());
            Console.WriteLine(e.ShortDescription());
        }

        ShowAll(gathering);
        ShowAll(lecture);
        ShowAll(reception);
    }

}