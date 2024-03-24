internal class Program
{
    private static void Main(string[] args)
    {
        SayaTubeVideo video1 = new SayaTubeVideo("Tutorial Design By Contract – Yousef");
        video1.PrintVideoDetails();
        
        SayaTubeVideo video2 = new SayaTubeVideo("");
        video2.PrintVideoDetails();

        SayaTubeVideo video3 = new SayaTubeVideo("Mengecek penambahan playcounter lebih dari 10.000.000 dan juga title yang lebih dari seratus karakter");
        video3.IncreasePlayCount(100000001);
        video3.PrintVideoDetails();

        SayaTubeVideo video4 = new SayaTubeVideo("Mengecek playcount overflow");
        for (int i = 0; i < 2; i++)
        {
            video4.IncreasePlayCount(1000000000);
        }
        video4.PrintVideoDetails();
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

        try
        {
            this.title = title;

            if (title == "")
            {
                throw new ArgumentNullException();
            }

            if (title.Length > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        catch (ArgumentNullException)
        {
            Console.WriteLine("Title tidak boleh kosong");
        }

        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Title harus kurang dari 100 karakter");
        }
    }

    public void IncreasePlayCount(int increment)
    {
        try
        {
            checked
            {
                playCount += increment;
                if (playCount + increment > 10000000) throw new ArgumentOutOfRangeException();
            }
        }

        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Play count tidak boleh lebih dari 10 juta");
        }

        catch (OverflowException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("ID: " + id);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Play count: " + playCount);
        Console.WriteLine("");
    }
}