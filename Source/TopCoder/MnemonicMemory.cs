using Microsoft.VisualStudio.TestTools.UnitTesting;

/* start time: 14:31 */
/* all basic test passed: 14:57 */
/* 75 / 250 pts on submit */

/**
 * PROBLEM STATEMENT: 
It is often helpful to have a mnemonic phrase handy for a math test. For example, the number 25735 can be remembered as "is there anybody out there". If we count the number of characters in every word, we would get the sequence 2, 5, 7, 3, 5, which represents the original number!
 * Unfortunately for you, your professor likes to make the students memorize random numbers and then test them. To beat the system, your plan is to come up with mnemonic phrases that will represent the numbers you must memorize.
 * You are given a string number and a string[] dictionary. Return a single space delimited list of words, where each word is an element of dictionary, and no element of dictionary is used more than once. The phrase must contain exactly n words, where n is the number of digits in the number, and the length of the i-th word must be equal to the i-th digit of the number for all i. If more than one phrase is possible, return the one that comes first alphabetically (in other words, if you have several words of the same length, you should use them in alphabetical order).
 * 
 */

/**
 * LIMITS:
 * time limit: 2.000s
 * memory limit: 64MB
 */

/**
 * CONSTRAINTS: 
Constraints-dictionary will contain between 1 and 50 elements, inclusive.-Each element of dictionary will contain between 1 and 9 characters, inclusive.-Each element of dictionary will contain only lowercase letters ('a'-'z').-number will contain between 1 and 50 characters, inclusive.-number will contain only digits between '1' and '9', inclusive.-There will always be a possible solution with the given dictionary.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MnemonicMemory
{
	public string getPhrase(string number, string[] dictionary)
	{
        var dict = dictionary.ToList();
        dict.Sort();

        string ret = String.Empty;
        int numSize = number.Length;

        for (int i = 0; i < numSize; i++)
        {
            if (i != 0) ret += " ";
            int currNum = Convert.ToInt32(number[i].ToString());
            var curr = dict.FindIndex(x => x.Length == currNum);
            ret += dict[curr];
            dict.RemoveAt(curr);
        }

        return ret;
	}
}

[TestClass]
public class MnemonicMemoryTests
{

	[TestMethod]
	 public void TestCase0()
	{
		MnemonicMemory mnemonicmemory = new MnemonicMemory();
        Assert.AreEqual("is there anybody out there", mnemonicmemory.getPhrase("25735", new string[] { "is", "there", "anybody", "out", "there" }));
	}

    //[TestMethod]
    // public void TestCase1()
    //{
    //    MnemonicMemory mnemonicmemory = new MnemonicMemory();
    //    Assert.AreEqual({"may", "i", "have", "a", "large", "container", "of", "coffee"}, mnemonicmemory.getPhrase("31415926");
    //}

    //[TestMethod]
    // public void TestCase2()
    //{
    //    MnemonicMemory mnemonicmemory = new MnemonicMemory();
    //    Assert.AreEqual({"a", "aa", "a", "aa"}, mnemonicmemory.getPhrase("1212");
    //}

    [TestMethod]
     public void TestCase3()
    {
        MnemonicMemory mnemonicmemory = new MnemonicMemory();
        Assert.AreEqual("a a b c d e e f z az za", mnemonicmemory.getPhrase("11111111122", new string[] { "a", "b", "d", "c", "a", "e", "f", "z", "zz", "za", "az", "e" }));
    }

    //[TestMethod]
    // public void TestCase4()
    //{
    //    MnemonicMemory mnemonicmemory = new MnemonicMemory();
    //    Assert.AreEqual({"ab", "cd", "ef", "a", "b", "ab"}, mnemonicmemory.getPhrase("2222");
    //}
}