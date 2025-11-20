// Program.cs
class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video v1 = new Video("How to Cook Rice", "Chef Miguel", 300);
        v1.AddComment(new Comment("Luis", "Great tutorial!"));
        v1.AddComment(new Comment("Ana", "Very helpful, thanks!"));
        v1.AddComment(new Comment("Pedro", "I tried it and it worked perfectly."));
        videos.Add(v1);

        Video v2 = new Video("Learn C# in 10 Minutes", "CodeMaster", 600);
        v2.AddComment(new Comment("Carlos", "Super clear explanation."));
        v2.AddComment(new Comment("María", "I learned a lot from this video."));
        v2.AddComment(new Comment("Elena", "Please make more content like this!"));
        videos.Add(v2);

        Video v3 = new Video("Top 10 Travel Destinations", "AdventuresTV", 480);
        v3.AddComment(new Comment("Jorge", "Amazing list!"));
        v3.AddComment(new Comment("Lucía", "I want to go to all of these places."));
        v3.AddComment(new Comment("Sofía", "Great recommendations!"));
        videos.Add(v3);

        // Display all videos
        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}
