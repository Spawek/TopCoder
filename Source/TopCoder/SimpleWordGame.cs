using Microsoft.VisualStudio.TestTools.UnitTesting;

/* start time: 16 października 2014 23:05:56 */
/* all basic test passed: xx:xx */ // took me like 3 min - i was fixing parser ;)
/* 137 / 300 pts on submit */

/**
 * PROBLEM STATEMENT: 
The Simple Word Game is a game where a player tries to remember as many words as possible from a given dictionary. The score for each distinct word that the player remembers correctly is the square of the word's length.
 * You are given a string[] player, each element of which is a word remembered by the player. There may be duplicate words, but if the same word appears multiple times, it should only be counted once. You are given the dictionary in the string[] dictionary, each element of which is a single distinct word. Return the player's total score.
 * 
 */

/**
 * LIMITS:
 * time limit: 2.000s
 * memory limit: 64MB
 */

/**
 * CONSTRAINTS: 
 * Constraints-player will contain between 1 and 50 elements, inclusive.-Each element of player will contain between 1 and 50 characters, inclusive.-Each character of each element of player will be a lowercase letter of English alphabet ('a' - 'z').-dictionary will contain between 1 and 50 elements, inclusive.-Each element of dictionary will contain between 1 and 50 characters, inclusive.-Each character of each element of dictionary will be a lowercase letter of English alphabet ('a' - 'z').-All elements of dictionary will be distinct.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SimpleWordGame
{
    public int points(string[] player, string[] dictionary)
    {
        var playerList = player.ToList();
        playerList.Sort();
        var playerListGood = playerList.Distinct();

        int score = 0;
        foreach (var p in playerListGood)
        {
            if (dictionary.Contains(p))
                score += p.Length * p.Length;
        }

        return score;
    }
}

[TestClass]
public class SimpleWordGameTests
{

    //The player has correctly remembered two words from the dictionary: "orange" (worth 6*6 = 36 points) and "strawberry" (worth 10*10 = 100 points). That gives a total score of 136 points.
    [TestMethod]
    public void TestCase0()
    {
        SimpleWordGame simplewordgame = new SimpleWordGame();
        Assert.AreEqual(136, simplewordgame.points(new string[] { "apple", "orange", "strawberry" }, new string[] { "strawberry", "orange", "grapefruit", "watermelon" }));
    }

    //The player has remembered just "apple" and it's not in the dictionary, so the score is 0.
    [TestMethod]
    public void TestCase1()
    {
        SimpleWordGame simplewordgame = new SimpleWordGame();
        Assert.AreEqual(0, simplewordgame.points(new string[] { "apple" }, new string[] { "strawberry", "orange", "grapefruit", "watermelon" }));
    }

    //The "orange" occurs twice in player, but should be counted just once towards the score.
    [TestMethod]
    public void TestCase2()
    {
        SimpleWordGame simplewordgame = new SimpleWordGame();
        Assert.AreEqual(36, simplewordgame.points(new string[] { "orange", "orange" }, new string[] { "strawberry", "orange", "grapefruit", "watermelon" }));
    }

    [TestMethod]
    public void TestCase3()
    {
        SimpleWordGame simplewordgame = new SimpleWordGame();
        Assert.AreEqual(186, simplewordgame.points(new string[] { "lidi", "o", "lidi", "gnbewjzb", "kten", "ebnelff", "gptsvqx", "rkauxq", "rkauxq", "kfkcdn" }, new string[] { "nava", "wk", "kfkcdn", "lidi", "gptsvqx", "ebnelff", "hgsppdezet", "ulf", "rkauxq", "wcicx" }));
    }
}