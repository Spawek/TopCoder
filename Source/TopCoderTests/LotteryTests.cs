using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TopCoder;

namespace TopCoderTests
{
    [TestClass]
    public class LotteryTests
    {
        [TestMethod]
        public void SortedUnique()
        {
            int choices = 10;
            int blanks = 2;
            bool sorted = true;
            bool unique = true;

            Assert.AreEqual(45, Lottery.CalcPossibilities(choices, blanks, sorted, unique));
        }

        [TestMethod]
        public void SortedUnique2()
        {
            int choices = 100;
            int blanks = 8;
            bool sorted = true;
            bool unique = true;

            Assert.AreEqual(186087894300, Lottery.CalcPossibilities(choices, blanks, sorted, unique));
        }

        [TestMethod]
        public void NotSortedNotUnique()
        {
            int choices = 10;
            int blanks = 2;
            bool sorted = false;
            bool unique = false;

            Assert.AreEqual(100, Lottery.CalcPossibilities(choices, blanks, sorted, unique));
        }

        [TestMethod]
        public void SortedNotUnique()
        {
            int choices = 10;
            int blanks = 2;
            bool sorted = true;
            bool unique = false;

            Assert.AreEqual(55, Lottery.CalcPossibilities(choices, blanks, sorted, unique));
        }

        [TestMethod]
        public void SortedNotUnique2()
        {
            int choices = 93;
            int blanks = 8;
            bool sorted = true;
            bool unique = false;

            Assert.AreEqual(186087894300, Lottery.CalcPossibilities(choices, blanks, sorted, unique));
        }


        [TestMethod]
        public void NotSortedUnique()
        {
            int choices = 10;
            int blanks = 2;
            bool sorted = false;
            bool unique = true;

            Assert.AreEqual(90, Lottery.CalcPossibilities(choices, blanks, sorted, unique));
        }

        [TestMethod]
        public void ParseTest1()
        {
            string record = "PICK ANY TWO: 10 2 F F";

            var parsed = Lottery.ParseLotteryRecord(record);

            Assert.AreEqual("PICK ANY TWO", parsed.name);
            Assert.AreEqual(10 , parsed.choices);
            Assert.AreEqual(2, parsed.blanks);
            Assert.AreEqual(false, parsed.sorted);
            Assert.AreEqual(false, parsed.unique);
        }

        [TestMethod]
        public void ParseTest2()
        {
            string record = "PICK ANY TWO : 1000000000 2 T T";

            var parsed = Lottery.ParseLotteryRecord(record);

            Assert.AreEqual("PICK ANY TWO ", parsed.name);
            Assert.AreEqual(1000000000, parsed.choices);
            Assert.AreEqual(2, parsed.blanks);
            Assert.AreEqual(true, parsed.sorted);
            Assert.AreEqual(true, parsed.unique);
        }

        [TestMethod]
        public void LotteryFullTest1()
        {
            string[] rules = {"PICK ANY TWO: 10 2 F F",
                              "PICK TWO IN ORDER: 10 2 T F",
                              "PICK TWO DIFFERENT: 10 2 F T",
                              "PICK TWO LIMITED: 10 2 T T"};

            string[] expectedOutput = { "PICK TWO LIMITED",
                                        "PICK TWO IN ORDER",
                                        "PICK TWO DIFFERENT",
                                        "PICK ANY TWO" };

            Lottery lottery = new Lottery();
            string[] actual = lottery.sortByOdds(rules);
            CollectionAssert.AreEquivalent(expectedOutput, actual);
        }

        [TestMethod]
        public void LotteryFullTest2()
        {
            string[] rules = {"INDIGO: 93 8 T F",
                            "ORANGE: 29 8 F T",
                            "VIOLET: 76 6 F F",
                            "BLUE: 100 8 T T",
                            "RED: 99 8 T T",
                            "GREEN: 78 6 F T",
                            "YELLOW: 75 6 F F"};

            string[] expectedOutput = { "RED",  
                                        "ORANGE",  
                                        "YELLOW",  
                                        "GREEN",  
                                        "BLUE",  
                                        "INDIGO",  
                                        "VIOLET" };

            Lottery lottery = new Lottery();
            string[] actual = lottery.sortByOdds(rules);
            CollectionAssert.AreEquivalent(expectedOutput, actual);
        }
    }
}

