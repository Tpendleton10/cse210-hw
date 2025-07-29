using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold all the videos
        List<Video> videos = new List<Video>();

        // First Video
        Video video1 = new Video("Exploring the Mountains", "NatureLover", 420);
        video1.AddComment(new Comment("Alice", "Wow, those views are incredible!"));
        video1.AddComment(new Comment("Bob", "I wish I could go there someday."));
        video1.AddComment(new Comment("Charlie", "Amazing footage!"));
        videos.Add(video1);

        // Second Video
        Video video2 = new Video("Top 10 Coding Tips", "CodeMaster", 600);
        video2.AddComment(new Comment("Dave", "These are super helpful, thanks!"));
        video2.AddComment(new Comment("Eve", "I learned something new today."));
        video2.AddComment(new Comment("Frank", "Great video, very clear explanations."));
        videos.Add(video2);

        // Third Video
        Video video3 = new Video("How to Bake Bread", "ChefDaily", 480);
        video3.AddComment(new Comment("Grace", "Mine turned out great, thanks!"));
        video3.AddComment(new Comment("Heidi", "Very informative and easy to follow."));
        video3.AddComment(new Comment("Ivan", "Tried this today and loved it!"));
        videos.Add(video3);

        // Fourth Video
        Video video4 = new Video("Space Documentary", "ScienceWorld", 900);
        video4.AddComment(new Comment("Judy", "Mind-blowing facts!"));
        video4.AddComment(new Comment("Kevin", "Space is so fascinating."));
        video4.AddComment(new Comment("Laura", "Thanks for this amazing content."));
        videos.Add(video4);

        // Display info for each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}

// ----------------- Video Class -----------------

class Video
{
    private string title;
    private string author;
    private int length; // in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        this.title = title;
        this.author = author;
        this.length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public string GetTitle()
    {
        return title;
    }

    public string GetAuthor()
    {
        return author;
    }

    public int GetLength()
    {
        return length;
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

// ----------------- Comment Class -----------------

class Comment
{
    private string name;
    private string text;

    public Comment(string name, string text)
    {
        this.name = name;
        this.text = text;
    }

    public string GetName()
    {
        return name;
    }

    public string GetText()
    {
        return text;
    }
}
