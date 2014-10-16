//using Microsoft.VisualStudio.TestTools.UnitTesting;

///* start time: xx:xx */
///* all basic test passed: xx:xx */
///* 150 / 500 pts on submit */

///**
// * PROBLEM STATEMENT: 
//The hotel industry is difficult to thrive in, especially when competing at a resort city like Las Vegas. Marketing is essential and often gets a large part of total revenues. You have a list of cities you can market at, and a good estimate of how many customers you will get for a certain amount of money spent at each city.  You are given int[]s customers and cost. cost[i] is the amount of money required to get customers[i] customers from the i-th city. You are only allowed to spend integer multiples of the cost for any city. For example, if it costs 9 to get 3 customers from a certain city, you can spend 9 to get 3 customer, 18 to get 6 customers, 27 to get 9 customers, but not 3 to get 1 customer, or 12 to get 4 customers. Each city has an unlimited number of potential customers. Return the minimum amount of money required to get at least minCustomers customers.
// * 
// */

///**
// * LIMITS:
// * time limit: 2.000s
// * memory limit: 64MB
// */

///**
// * CONSTRAINTS: 
// * Constraints-minCustomers will be between 1 and 1000, inclusive.-customers will contain between 1 and 20 elements, inclusive.-cost will have the same number of elements as customers.-Each element of cost and customers will be between 1 and 100, inclusive.
// */

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//public class Hotel
//{
//    public int marketCost(int minCustomers, int[] customers, int[] cost)
//    {
//        if (minCustomers <= 0)
//            return 0;

//        var matching = Enumerable.Range(0, cost.Length).Where(x => customers[x] >= minCustomers);
//        if (matching.Count() > 0)
//        {
//            return matching.Min(x => cost[x]);
//        }

//        double minPricePerCustomer = Enumerable.Range(0, cost.Length).Min(x => customers[x] >= minCustomers ? (double)cost[x] / (double)minCustomers : (double)cost[x] / (double)customers[x]);
//        int i = Enumerable.Range(0, cost.Length).First(x => (customers[x] >= minCustomers ? (double)cost[x] / (double)minCustomers : (double)cost[x] / (double)customers[x]) == minPricePerCustomer);

//        int multipler = minCustomers / customers[i];
//        int customersHere = multipler * customers[i];
//        int price = multipler * cost[i];

//        return price + marketCost(minCustomers - customersHere, customers, cost);
//    }
//}

//[TestClass]
//public class HotelTests
//{

//    [TestMethod]
//    public void TestCase0()
//    {
//        Hotel hotel = new Hotel();
//        Assert.AreEqual(4, hotel.marketCost(10, new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 }));
//    }

//    [TestMethod]
//    public void TestCase1()
//    {
//        Hotel hotel = new Hotel();
//        Assert.AreEqual(10, hotel.marketCost(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));
//    }

//    [TestMethod]
//    public void TestCase2()
//    {
//        Hotel hotel = new Hotel();
//        Assert.AreEqual(8, hotel.marketCost(12, new int[] { 5, 1 }, new int[] { 3, 1 }));
//    }

//    [TestMethod]
//    public void TestCase3()
//    {
//        Hotel hotel = new Hotel();
//        Assert.AreEqual(45, hotel.marketCost(100, new int[] { 9, 11, 4, 7, 2, 8 }, new int[] { 4, 9, 3, 8, 1, 9 }));
//    }
//}