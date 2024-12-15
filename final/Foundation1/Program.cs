using System;

class Program
{
    static void Main(string[] args)
    {

        List<Video> videos = new();
        Video video1 = new();
        
        video1._title = "How to eat a lot of beans";
        video1._author = "BeanEaters";
        video1._length = 300;
        
        video1._comments.Add(new Comment("BeanConsumer1", "Great tutorial, very clear!"));
        video1._comments.Add(new Comment("ILoveBeans", "Helped me a lot, thanks!"));
        video1._comments.Add(new Comment("PeaEnjoyer", "Could you cover peas next?"));

        Video video2 = new();

        video2._title = "The Drama Situation is Crazy";
        video2._author = "SlopServer";
        video2._length = 3000;
        
        video2._comments.Add(new Comment("Piggy", "It's over for him"));
        video2._comments.Add(new Comment("SlopGobbler", "I can't believe he would do this"));
        video2._comments.Add(new Comment("DramaLover", "How is anyone suprised he did this? I always knew he was a bad guy."));

        Video video3 = new Video
        {
            _title = "This pixel just changed Garble 67 speedruns forever",
            _author = "Game-R Us",
            _length = 10000
        };
        video3._comments.Add(new Comment("BasementDweller", "Best two-and-a-half hours of my life."));
        video3._comments.Add(new Comment("GarbleSpeedKing", "I'm getting that crown back."));
        video3._comments.Add(new Comment("NormalGuy", "Ok but how will this effect the job market"));

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine(video._title);
            Console.WriteLine(video._author);
            Console.WriteLine(video._length);

            Console.WriteLine(video.GetCommentCount());
            foreach (Comment comment in video._comments)
            {
                Console.WriteLine(comment._username);
                Console.WriteLine(comment._text);
            }
        }

    }
}