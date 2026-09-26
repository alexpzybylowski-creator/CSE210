class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video(
            "Learning C#",
            "Programming Channel",
            420
        );

        video1.AddComment(new Comment("Alex", "This video was very helpful."));
        video1.AddComment(new Comment("John", "I learned a lot from this."));
        video1.AddComment(new Comment("Maria", "Great explanation!"));

        Video video2 = new Video(
            "How to Build a PC",
            "Tech World",
            600
        );

        video2.AddComment(new Comment("Carlos", "This helped me choose my parts."));
        video2.AddComment(new Comment("Mike", "Very good video."));
        video2.AddComment(new Comment("Anna", "I liked the explanation."));
        video2.AddComment(new Comment("Lucas", "Thanks for the information."));

        Video video3 = new Video(
            "Introduction to Programming",
            "Code Academy",
            520
        );

        video3.AddComment(new Comment("James", "Good introduction."));
        video3.AddComment(new Comment("Sofia", "This was easy to understand."));
        video3.AddComment(new Comment("Daniel", "I will watch the next video."));

        Video video4 = new Video(
            "Git and GitHub Basics",
            "Developer Channel",
            480
        );

        video4.AddComment(new Comment("Robert", "GitHub is much easier now."));
        video4.AddComment(new Comment("Emily", "Very useful tutorial."));
        video4.AddComment(new Comment("David", "Thanks for teaching this."));
        video4.AddComment(new Comment("Laura", "Great video!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}