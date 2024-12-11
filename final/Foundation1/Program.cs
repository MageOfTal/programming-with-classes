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
        video2._length = 5000;
        
        video2._comments.Add(new Comment("Piggy", "It's over for him"));
        video2._comments.Add(new Comment("SlopGobbler", "I can't believe he would do this"));
        video2._comments.Add(new Comment("DramaLover", "How is anyone suprised he did this? I always knew he was a bad guy."));

        Video video3 = new Video
        {
            _title = "This pixel just changed Florbus speedruns forever",
            _author = "Game-R Us",
            _length = 450
        };
        video3._comments.Add(new Comment("Grace", "Best explanation I've seen."));
        video3._comments.Add(new Comment("Hank", "A bit too fast-paced."));
        video3._comments.Add(new Comment("Ivy", "Thank you for this!"));

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

    }
}