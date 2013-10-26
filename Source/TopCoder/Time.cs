using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/* start 11:10
 * end 11:17 (with tests and sumbit)
 * 
 * result: 183.30/200.00
 */
public class Time
{
    public string whatTime(int seconds)
    {
        return String.Format("{0}:{1}:{2}",
            (seconds / 3600).ToString(),
            ((seconds % 3600) / 60).ToString(),
            (seconds % 60).ToString());
    }
}

