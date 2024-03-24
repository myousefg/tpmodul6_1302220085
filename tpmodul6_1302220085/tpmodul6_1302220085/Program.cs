internal class Program
{
    private static void Main(string[] args)
    {
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – Yousef");
        video.PrintVideoDetails();
    }
}

class SayaTubeVideo {
    int id;
    string title;
    int playCount;

    public SayaTubeVideo(string title) 
    {
        this.title = title;
        Random randomId = new Random();
        id = randomId.Next(10000, 99999);
    }

    public void IncreasePlayCount(int increment)
    {
        playCount += increment;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("ID: " + id);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Play count: " + playCount);
    }
}