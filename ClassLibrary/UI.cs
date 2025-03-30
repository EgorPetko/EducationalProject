namespace ClassLibrary;

public class UI
{
    private string[] RuleForEnd = { "", "end" };

    public void StartGeometricProgression()
    {
        Greeting("What number is missing in the progression?");
        Play(GenQuestionForGeometricProgression);
    }

    public void StartSmallestCommonMultiple()
    {
        Greeting("Find the smallest common multiple of given numbers.");
        Play(GenQuestionForSmallestCommonMultiple);
    }

    private void Play(Func<(string, int)> qu)
    {
        var request = "";
        do
        {
            (string question, int answer) = qu();

            Console.WriteLine($"Question: {question}");
            Console.WriteLine("Your answer: ");

            request = Console.ReadLine();
            if (RuleForEnd.Contains(request))
            {
                break;
            }

            if (!int.TryParse(request, out var number))
            {
                Console.WriteLine("Incorrect format!");
                Console.WriteLine($"Right answer: {answer}");
                continue;
            }

            if (number == answer)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect!");
                Console.WriteLine($"Right answer: {answer}");
            }
        } while (true);

        Console.WriteLine("END");
    }

    private void Greeting(string str)
    {
        Console.WriteLine("Welcome to the Brain Games!");
        Console.WriteLine("May I have your name? ");
        var name = Console.ReadLine();
        Console.WriteLine($"Hello, {name}!");
        Console.WriteLine(str);
    }

    private (string, int) GenQuestionForSmallestCommonMultiple()
    {
        const int count = 3;
        const int downNumber = 2;
        const int upNumber = 10;
        var arr = new int[count];
        var random = new Random();

        string str = "";
        for (int i = 0; i < count; i++)
        {
            arr[i] = random.Next(downNumber, upNumber);
            str += arr[i].ToString() + " ";
        }
        return (str, Nok(arr));
    }

    private int Nok(int[] number)
    {
        var max = number.Max();
        var divider = 1;
        var composition = 1;
        var answer = 1;
        foreach (var item in number)
        {
            composition *= item;
        }

        while (composition / divider >= max)
        { 
            if(composition % divider == 0 && number.All(x => (composition / divider) % x == 0))
            {
                answer = composition / divider;
            }
            divider++;
        }

        return answer;
    }

    private (string, int) GenQuestionForGeometricProgression()
    {
        const int count = 7;
        const int downNumber = 2;
        const int upNumber = 10;

        var arr = new int[count];
        var random = new Random();
        var k = random.Next(downNumber, upNumber);
        var n = random.Next(0, count);
        var answer = 0;
        var str = "";

        arr[0] = k;
        for (var i = 1; i < count; i++)
        {
            arr[i] = arr[i - 1] * k;
        }

        for (var i = 0; i < count; i++)
        {
            if (i == n)
            {
                answer = arr[i];
                str += ".. ";
                continue;
            }
            str += arr[i].ToString() + " ";
        }

        return (str, answer);
    }
}
