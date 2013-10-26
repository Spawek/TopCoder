using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* 
 * start: 01.03
 * end: 01.21
 * 
 * 187.24/250.00
 */


public class ImageDithering
{
    public int count(string dithered, string[] screen)
    {
        SortedSet<char> ditheredSet = new SortedSet<char>();
        foreach (var item in dithered)
	    {
            ditheredSet.Add(item);
        }

        int count = 0;
        foreach (var item in screen)
        {
            foreach (var c in item)
	        {
		        if(ditheredSet.Contains(c))
                {
                    count++;
                }
	        }
        }

        return count;
    }
}

