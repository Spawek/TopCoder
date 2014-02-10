using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * start 01:53
 * po przeczytaniu tresci zadania poszedłem spać ;)
 * 
 * re start: 17:00
 * re end: 17:30
 * 
 * re start: 20:10
 * 
 */

public class VendingMachine
{
    class MachineSimulator
    {
        const int ITEM_TAKEN = -666;
        public List<List<int>> items = new List<List<int>>();
        public int moveTime = 0;
        public int lastTime = 0;
        public int currCol = 0;
        public int colCount;
        public int rowCount;

        public MachineSimulator(string[] prices)
        {
            rowCount = prices.Length;
            for(int i = 0; i < prices.Length; i++)
            {
                items.Add(new List<int>());
                string[] splittedPrice = prices[i].Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string price in splittedPrice)
                {
                    items[i].Add(Convert.ToInt32(price));
                }
                colCount = splittedPrice.Length;
            }
            MoveToMaxMaxCol();
        }

        public bool TakeItem(int col, int row, int time)
        {
            if (items[row][col] == ITEM_TAKEN)
            {
                return false;
            }
            items[row][col] = ITEM_TAKEN;

            if (time - lastTime >= 5)
            {
                MoveToMaxMaxCol();
            }
            MoveToCol(col);

            lastTime = time;
            return true;
        }

        private void MoveToCol(int col)
        {
            moveTime += Math.Min(Math.Abs(col - currCol), colCount - Math.Abs(col - currCol));
            currCol = col;
        }

        private void MoveToMaxMaxCol()
        {
            int currColVal = 0;
            for (int i = 0; i < rowCount; i++)
            {
                currColVal += items[i][currCol];
            }


            int maxCol = 0;
            int maxVal = 0;
            for (int i = 0; i < colCount; i++)
            {
                int currVal = 0;
                for (int j = 0; j < rowCount; j++)
                {
                    currVal += items[j][i];
                }

                if (currVal > maxVal)
                {
                    maxVal = currVal;
                    maxCol = i;
                }
            }

            if (maxVal > currColVal)
            {
                MoveToCol(maxCol);
            }
        }

        public int MakePurchaese(List<Purchase> purchases)
        {
            foreach (var purchase in purchases)
            {
                if (!TakeItem(purchase.col, purchase.row, purchase.time))
                {
                    return -1;
                }
            }

            return moveTime;
        }
    }

    public class Purchase
    {
        public int row;
        public int col;
        public int time;

        public Purchase(int row_, int col_, int time_)
        {
            row = row_;
            col = col_;
            time = time_;
        }
    }

    public List<Purchase> parsePurchases(string[] purchases)
    {
        List<Purchase> ret = new List<Purchase>();

        foreach (string item in purchases)
        {
            string[] splitted = item.Split(new char[] { ',', ':' }, StringSplitOptions.RemoveEmptyEntries);
            ret.Add(new Purchase(Convert.ToInt32(splitted[0]), Convert.ToInt32(splitted[1]), Convert.ToInt32(splitted[2])));
        }

        return ret;
    }

    public int motorUse(string[] prices, string[] purchases)
    {
        MachineSimulator ms = new MachineSimulator(prices);
        List<Purchase> purs = parsePurchases(purchases);
        return ms.MakePurchaese(purs);
    }
}
