using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* start time: 15:55 */
/* tests done: 16:00 */
/* all basic test passed: 17:14 */
/* 109.9 / 300 pts on submit */ //but how it works???
public class BinaryCode
{
    public string[] decode(string inputString)
    {
        List<int> intputWith0AtStart = decodeToIntList(inputString, 0);
        List<int> intputWith1AtStart = new List<int>(intputWith0AtStart);
        intputWith1AtStart[1] = 1;

        string input0Decoded = stringifyDecoded(decodeList(intputWith0AtStart));
        string input1Decoded = stringifyDecoded(decodeList(intputWith1AtStart));

        return new string[] 
        { 
            input0Decoded,
            input1Decoded
        };
    }

    private List<int> decodeToIntList(string inputString, int assummed1stSign)
    {
        List<int> input = new List<int>() { 0, assummed1stSign };
        foreach (char item in inputString)
        {
            input.Add(Convert.ToInt32(item - '0'));
        }

        return input;
    }

    List<int> decodeList(List<int> input)
    {
        if (Math.Abs(input.Last() - input[input.Count - 2]) > 1)
        {
            return new List<int>();
        }

        List<int> decoded = new List<int>() { 0 };

        decoded.Add(input[1]);
        for (int i = 2; i < input.Count - 1; i++)
        {
            int newDecoded = input[i] - decoded[i - 2] - decoded[i - 1];
            if (newDecoded != 0 && newDecoded != 1)
            {
                return new List<int>();
            }
            decoded.Add(newDecoded);
        }

        return decoded.GetRange(1, decoded.Count() - 1);
    }

    string stringifyDecoded(List<int> input)
    {
        if (input.Count == 0)
        {
            return "NONE";
        }

        StringBuilder sb = new StringBuilder(input.Count);
        foreach (var item in input)
        {
            sb.Append(item.ToString());
        }

        return sb.ToString();
    }
}