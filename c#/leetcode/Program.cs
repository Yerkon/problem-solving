using System;
using System.Collections.Generic;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solution sol = new Solution();

            Node rootNode = sol.GetTest1();

            int[] result = sol.Postorder(rootNode);
            List<int> mock = sol.GetMock1();

            Console.WriteLine("Test1");
            Console.WriteLine(string.Join(", ", result));
            Console.WriteLine(string.Join(", ", mock));

            rootNode = sol.getTest2();

            result = sol.Postorder(rootNode);
            mock = sol.GetMock2();

            Console.WriteLine("Test2");
            Console.WriteLine(string.Join(", ", result));
            Console.WriteLine(string.Join(", ", mock));
        }
    }

    public class Solution
    {
        /**
        with stack
         */
        public int[] Postorder(Node root)
        {
            Stack<int> stackResult = new Stack<int>();

            if (root == null)
            {
                return stackResult.ToArray();
            }

            Node parentNode = null;
            Node currNode = root;

            while (currNode != null)
            {
                if (currNode.children.Count == 0)
                {
                    
                }
                else
                {
                    stackResult.Push(currNode.val);
                    parentNode = currNode;
                    currNode = currNode.children[0];
                }

            }

            return stackResult.ToArray();
        }

        /**
        with list
        */
        public List<int> Postorder1(Node root)
        {
            List<int> listResult = new List<int>();

            if (root == null)
            {
                return listResult;
            }

            Node parentNode = null;
            Node currNode = root;

            while (currNode != null)
            {
                if (currNode.children.Count == 0)
                {
                    // there is no child
                    if (currNode == root)
                    {
                        listResult.Add(currNode.val);
                        currNode = null;
                        continue;
                    }

                    listResult.Add(currNode.val);
                    parentNode.children.Remove(currNode);

                    // start from beginning
                    currNode = root;
                }
                else
                {
                    parentNode = currNode;
                    currNode = currNode.children[0];
                }

            }

            return listResult;
        }


        /**
        Recursive solution
         */
        public void ProceedPostOrder(Node root, List<int> result)
        {

            foreach (var child in root.children)
            {
                ProceedPostOrder(child, result);
                result.Add(child.val);
            }
        }

        public Node GetTest1()
        {
            Node root = new Node(1, new List<Node>());

            Node child1 = new Node(3, new List<Node>());
            Node child2 = new Node(2, new List<Node>());
            Node child3 = new Node(4, new List<Node>());

            child1.children.Add(new Node(5, new List<Node>()));
            child1.children.Add(new Node(6, new List<Node>()));

            root.children = new List<Node>(){
                child1,
                child2,
                child3
            };

            return root;
        }

        public List<int> GetMock1()
        {
            return new List<int>() { 5, 6, 3, 2, 4, 1 };
        }
        public Node getTest2()
        {

            Node root = new Node(1, new List<Node>());

            Node child1 = new Node(10, new List<Node>());
            Node child2 = new Node(3, new List<Node>());

            child1.children.Add(new Node(5, new List<Node>()));
            child1.children.Add(new Node(0, new List<Node>()));

            child2.children.Add(new Node(6, new List<Node>()));


            root.children = new List<Node>(){
                child1,
                child2,
            };

            return root;
        }

        public List<int> GetMock2()
        {
            return new List<int>(){
                5,0,10,6,3,1
            };
        }
    }
}

public class Node
{
    public int val;
    public IList<Node> children;

    public Node() { }
    public Node(int _val, IList<Node> _children)
    {
        val = _val;
        children = _children;
    }
}

