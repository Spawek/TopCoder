using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * start: 01.29
 * rozkmina zrobiona: 01.35
 * testy zrobione: 01.39
 * commit: 01.48
 * 
 * 359.00/500
 */
public class ExerciseMachine
{
    public int getPercentages(string time)
    {
        string[] splitted = time.Split(':');
        int secs = Convert.ToInt32(splitted[0]) * 3600 + Convert.ToInt32(splitted[1]) * 60 + Convert.ToInt32(splitted[2]);

        double interval = (double)secs / 100.0d;

        int multipler = 0;
        for (int i = 1; i < 100; i++)
        {
            if ((interval * i) % 1 < 0.001)
            {
                multipler = i;
                break;
            }
        }

        if (multipler == 0)
        {
            return 0;
        }

        return 100 / multipler - 1;
    }
}
