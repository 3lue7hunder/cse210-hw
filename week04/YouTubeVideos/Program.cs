using System;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("C# Tutorial for Beginners", "CodeAcademy", 600);
        Video video2 = new Video("Learn OOP in C#", "TechExplained", 850);
        Video video3 = new Video("C# LINQ Basics", "DevSimplified", 720);

        // Add comments to video1
        video1.AddComment(new Comment("Alice", "Great tutorial, very helpful!"));
        video1.AddComment(new Comment("Bob", "Could you explain more about classes?"));
        video1.AddComment(new Comment("Charlie", "Loved this, keep making more videos!"));

        // Add comments to video2
        video2.AddComment(new Comment("David", "This really clarified OOP for me."));
        video2.AddComment(new Comment("Eve", "Best explanation of inheritance I’ve seen."));
        video2.AddComment(new Comment("Frank", "What about interfaces?"));

        // Add comments to video3
        video3.AddComment(new Comment("Grace", "LINQ is so powerful, thanks for this!"));
        video3.AddComment(new Comment("Hank", "Could you cover advanced queries next?"));
        video3.AddComment(new Comment("Ivy", "Very well explained."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information for each video
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}