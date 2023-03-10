using HitAndBlow;

HitAndBlowGame game = null;

Console.WriteLine("Hello, Hit & Blow.");

while (true)
{
    Console.WriteLine("Please key-in operations:");
    var operation = Console.ReadLine();
    
    if (operation.StartsWith("new"))
    {
        var split = operation.Split(" ");
        if (split.Length != 2)
        {
            Console.WriteLine("Invalid input.");
            continue;
        }
        
        if (int.TryParse(split[1], out var digits))
        {
            try
            {
                game = new HitAndBlowGame(digits);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        Console.WriteLine("A new game.");
    }
    else if (operation.StartsWith("analyze"))
    {
        if (game is null)
        {
            Console.WriteLine("Game is null!");
            continue;
        }

        var round = game.TriedRounds;
        var tried = game.TriedTimes;
        var succeed = game.SuccessTimes;
        Console.WriteLine($"{succeed} succeed of {tried} tries in {round} rounds.");
    }
    else if (operation.StartsWith("next"))
    {
        if (game is null)
        {
            Console.WriteLine("Game is null!");
            continue;
        }
        
        game.New();
        Console.WriteLine("Next round.");
    }
    else if (operation.StartsWith("guess"))
    {
        if (game is null)
        {
            Console.WriteLine("Game is null!");
            continue;
        }

        var split = operation.Split(" ");
        if (split.Length != 2)
        {
            Console.WriteLine("Invalid input.");
            continue;
        }

        if (game.IsEnded)
        {
            Console.WriteLine("Round ended.");
        }
        
        try
        {
            var result = game.Guess(split[1]);

            Console.WriteLine($"Hit/Blow: {result.Hit} {result.Blow}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
    else if (operation.StartsWith("exit"))
    {
        if (game is null)
        {
            Console.WriteLine("Game is null!");
            continue;
        }

        var round = game.TriedRounds;
        var tried = game.TriedTimes;
        var succeed = game.SuccessTimes;
        Console.WriteLine($"{succeed} succeed of {tried} tries in {round} rounds.");
        
        break;
    }
}
