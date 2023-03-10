using System.Text;

namespace HitAndBlow;

public class HitAndBlowGame
{
    private Random Random { get; }
    
    public int Digits { get; }
    
    public string Number { get; private set; }

    public bool IsEnded { get; private set; } = true;
    public bool IsLastSuccess { get; private set; } = false;
    public int TriedTimes { get; private set; } = 0;
    public int RoundTriedTimes { get; private set; } = 0;
    public int TriedRounds { get; private set; } = 0;
    public int SuccessTimes { get; private set; } = 0;
    
    public HitAndBlowGame(int digits)
    {
        if (digits is > 10 or < 2)
        {
            throw new ArgumentException("Digits must less than 10 and more than 2.");
        }

        Random = new Random();

        Digits = digits;
    }

    public string New()
    {
        IsEnded = false;
        TriedRounds += 1;
        RoundTriedTimes = 0;
        
        StringBuilder builder = new();
        for (var i = 0; i < Digits; i++)
        {
            builder.Append(Random.Next(0, 10));
        }

        Number = builder.ToString();
        return Number;
    }

    public (int Hit, int Blow) Guess(string number)
    {
        if (number.Length != Digits)
        {
            throw new ArgumentException($"Guess length mismatch with {Digits}!");
        }

        if (number.Length != number.Distinct().Count())
        {
            throw new ArgumentException($"Distinct length mismatched with {Digits}.");
        }

        if (IsEnded)
        {
            throw new InvalidOperationException("Round ended!");
        }
        
        TriedTimes += 1;
        RoundTriedTimes += 1;
        
        var hit = 0;
        var blow = 0;

        for (var i = 0; i < Digits; i++)
        {
            if (Number[i] == number[i])
            {
                hit += 1;
            } 
            else if (Number.Contains(number[i]))
            {
                blow += 1;
            }
        }
        
        if (hit == Digits && blow == 0)
        {
            SuccessTimes += 1;
            IsLastSuccess = true;
            IsEnded = true;
        }
        else
        {
            IsLastSuccess = false;
        }
        
        return (hit, blow);
    }
}