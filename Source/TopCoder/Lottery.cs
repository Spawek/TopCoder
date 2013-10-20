using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /*
    * 16:30 - start
    * 17:13 - utknąłem na problemie z sorted + not unique - nie wiem jak to policzyć
    * 17:26 - teoria zrobiona (jestem ciulem - nie zauważyłem, że widziałem rozwiązanie)
    * 17:46 - zrobione testy do obliczeń
    * 18:03 - zrobiona część obliczeniowa
    * 18:22 - zrobione parsowanie stringa
    * 18:47 - wszystko połączone - przeszły podstawowe testy
    * 18:49 - kurwa nie ma tam ICompare ... i się nie buduje
    * 18:54 - Submission was successful for 174.57pts - nie ogarniam o co chodzi z tymi punktami - wygląda na to, że wszystkie testy przeszły, a to było zadanie na 550pkt 
    */
public class Lottery
{
    public string[] sortByOdds(string[] rules)
    {
        List<LotteryRecord> records = new List<LotteryRecord>(rules.Length);
        foreach (var rule in rules)
        {
            records.Add(Lottery.ParseLotteryRecord(rule));
        }

        records.Sort(new LotteryRecordComparer());

        string[] output = new string[rules.Length];
        for (int i = 0; i < rules.Length; i++)
        {
            output[i] = records[i].name;
        }

        return output;
    }

    public class LotteryRecordComparer : IComparer<LotteryRecord>
    {
        public int Compare(LotteryRecord x, LotteryRecord y)
        {
            if (x.possibilities != y.possibilities)
            {
                if (x.possibilities < y.possibilities)
                {
                    return -1;
                }
                return 1;
            }

            return x.name.CompareTo(y.name);
        }
    }

    public class LotteryRecord
    {
        public string name;
        public int choices;
        public int blanks;
        public bool sorted;
        public bool unique;
        public long possibilities;

        public LotteryRecord(string _name, int _choices, int _blanks, bool _sorted, bool _unique)
        {
            name = _name;
            choices = _choices;
            blanks = _blanks;
            sorted = _sorted;
            unique = _unique;
            possibilities = Lottery.CalcPossibilities(this);
        }
    }

    public static LotteryRecord ParseLotteryRecord(string record)
    {
        string[] splittedNameAndData = record.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
        string[] splittedData = splittedNameAndData[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string name = splittedNameAndData[0];
        int choices = Convert.ToInt32(splittedData[0]);
        int blanks = Convert.ToInt32(splittedData[1]);

        bool sorted = false;
        if (splittedData[2] == "T") sorted = true;

        bool unique = false;
        if(splittedData[3] == "T") unique = true;

        return new LotteryRecord(name, choices, blanks, sorted, unique);
    }

    static long Factorial(long n)
    {
        if (n == 0) return 1;
        long t = n;
        while (n-- > 2) t *= n;
        return t;
    }

    static long FallingPower(long n, long p)
    {
        long t = 1;
        for (long i = 0; i < p; i++) t *= n--;
        return t;
    }

    static long BinomialCoeff(long n, long k)
    {
        if ((k < 0) || (k > n)) return 0;
        k = (k > n / 2) ? n - k : k;
        return FallingPower(n, k) / Factorial(k);
    }

    static long CombinationsWithRepeatings(long n, long k)
    {
        if ((k < 0) || (k > n)) return 0;
        k = (k > n / 2) ? n - k : k;
        return FallingPower(n, k);
    }

    static long Pow(long a, long b)
    {
        long ret = a;
        for (int i = 0; i < b - 1; i++) ret *= a;
        return ret;
    }

    public static long CalcPossibilities(LotteryRecord record)
    {
        return CalcPossibilities(record.choices, record.blanks, record.sorted, record.unique);
    }

    public static long CalcPossibilities(int choices, int blanks, bool sorted, bool unique)
    {
        if (sorted)
        {
            if (unique)
            {
                return BinomialCoeff(choices, blanks);
            }
            else
            {
                return BinomialCoeff(choices + blanks - 1, blanks);
            }
        }
        else
        {
            if (unique)
            {
                return CombinationsWithRepeatings(choices, blanks);
            }
            else
            {
                return Pow(choices, blanks);
            }
        }
    }
    
}

