using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* start: 11:24 
 * zrozumiałem zadanie: 11:31
 * koniec analizy i opisu: 11:35
 * napisane testy: 11:41
 * napisany kod + submit: 11:54
 * 
 * result: 625.12/1100.00
 */

/*
 * redefinicja problemu:
 *      dostaje krawędzie drzewa - trzeba znaleźć max drogę przejścia 
 *      od roota przez wszystkie wierzchołków (bez wracania do roota)
 *      
 *      przez to, że nie trzeba wracać - każdą drogą w drzewie trzeba przejść 2 razy
 *      poza 1 drogą od roota do dowolnego liścia, którą trzeba przejść tylko 1 raz
 *      
 *      celem jest więc znalzienie najdłuższej drogi od roota do liścia
 *      
 *      wynik = sum(ductLength)*2 - longestWayFromRootToLeaf
 *      
 *  
 *      algorytm - zapuścić DFS na grafie znaleźć longestWayFromRootToLeaf jako max z BFS'a
 */
public class PowerOutage
{
    class Node
    {
        public Dictionary<Node, int> neighbours = new Dictionary<Node, int>();

        public int distFromRoot = 0;
        public bool visited = false;
    }

    class Graph
    {
        private List<Node> nodes = new List<Node>();

        public Graph(int[] fromJunction, int[] toJunction, int[] ductLength)
        {
            // create nodes
            for (int i = 0; i < 50; i++)
            {
                nodes.Add(new Node());
            }

            // create edges
            for (int i = 0; i < fromJunction.Length; i++)
            {
                nodes[fromJunction[i]].neighbours.Add(nodes[toJunction[i]], ductLength[i]);
                nodes[toJunction[i]].neighbours.Add(nodes[fromJunction[i]], ductLength[i]); // not sure if needed, but wont disturb
            }
        }

        private void DFS(Node currNode)
        {
            currNode.visited = true;
            foreach (var neighbour in currNode.neighbours)
	        {
                if (!neighbour.Key.visited)
                {
                    neighbour.Key.distFromRoot = currNode.distFromRoot + neighbour.Value;
                    DFS(neighbour.Key);
                }
	        }
        }

        public int FindMaxPathFromRootToLeaf()
        {
            DFS(nodes[0]);
            return nodes.Max(x => x.distFromRoot);
        }
    }

    public int estimateTimeOut(int[] fromJunction, int[] toJunction, int[] ductLength)
    {
        Graph graph = new Graph(fromJunction, toJunction, ductLength);
        int maxPathFromRootToLeaf = graph.FindMaxPathFromRootToLeaf();

        return ductLength.Sum() * 2 - maxPathFromRootToLeaf;
    }
}

