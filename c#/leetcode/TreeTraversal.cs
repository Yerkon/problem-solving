using System.Collections.Generic;

// public class Solution
//     {

//         List<int> result = new List<int>();


//         // iterative way
//         public List<int> Preorder(Node root)
//         {
//             Stack<Node> tempStack = new Stack<Node>();
//             List<int> resList = new List<int>();

//             if (root == null) return resList;

//             tempStack.Push(root);

//             while (tempStack.Count > 0)
//             {
//                 Node currNode = tempStack.Pop();
//                 resList.Add(currNode.val);

//                 for (int i = currNode.children.Count - 1; i >= 0; i--)
//                 {
//                     Node currChild = currNode.children[i];
//                     tempStack.Push(currChild);
//                 }
//             }

//             return resList;
//         }

//         // recursive way
//         public IList<int> Preorder1(Node root)
//         {
//             if (root == null) return result;

//             result.Add(root.val);

//             for (int i = 0; i < root.children.Count; i++)
//             {
//                 Node currNode = root.children[i];
//                 this.Preorder(currNode);
//             }

//             return result;
//         }
//         /**
//         with stack
//          */
//         public int[] Postorder(Node root)
//         {
//             Stack<int> stackResult = new Stack<int>();
//             Stack<Node> tempStack = new Stack<Node>();

//             if (root == null)
//             {
//                 return stackResult.ToArray();
//             }

//             tempStack.Push(root);

//             while (tempStack.Count > 0)
//             {
//                 Node currNode = tempStack.Pop();
//                 for (int i = 0; i < currNode.children.Count; i++)
//                 {
//                     Node childNode = currNode.children[i];
//                     tempStack.Push(childNode);
//                 }

//                 stackResult.Push(currNode.val);
//             }

//             return stackResult.ToArray();
//         }

//         /**
//         with list
//         */
//         public List<int> Postorder1(Node root)
//         {
//             List<int> listResult = new List<int>();

//             if (root == null)
//             {
//                 return listResult;
//             }

//             Node parentNode = null;
//             Node currNode = root;

//             while (currNode != null)
//             {
//                 if (currNode.children.Count == 0)
//                 {
//                     // there is no child
//                     if (currNode == root)
//                     {
//                         listResult.Add(currNode.val);
//                         currNode = null;
//                         continue;
//                     }

//                     listResult.Add(currNode.val);
//                     parentNode.children.Remove(currNode);

//                     // start from beginning
//                     currNode = root;
//                 }
//                 else
//                 {
//                     parentNode = currNode;
//                     currNode = currNode.children[0];
//                 }

//             }

//             return listResult;
//         }

//         /**
//         Recursive solution
//          */
//         public void ProceedPostOrder(Node root, List<int> result)
//         {

//             foreach (var child in root.children)
//             {
//                 ProceedPostOrder(child, result);
//                 result.Add(child.val);
//             }
//         }

//         public Node GetTest1()
//         {
//             Node root = new Node(1, new List<Node>());

//             Node child1 = new Node(3, new List<Node>());
//             Node child2 = new Node(2, new List<Node>());
//             Node child3 = new Node(4, new List<Node>());

//             child1.children.Add(new Node(5, new List<Node>()));
//             child1.children.Add(new Node(6, new List<Node>()));

//             root.children = new List<Node>(){
//                 child1,
//                 child2,
//                 child3
//             };

//             return root;
//         }

//         public List<int> GetMock1()
//         {
//             return new List<int>() { 5, 6, 3, 2, 4, 1 };
//         }
//         public Node getTest2()
//         {

//             Node root = new Node(1, new List<Node>());

//             Node child1 = new Node(10, new List<Node>());
//             Node child2 = new Node(3, new List<Node>());

//             child1.children.Add(new Node(5, new List<Node>()));
//             child1.children.Add(new Node(0, new List<Node>()));

//             child2.children.Add(new Node(6, new List<Node>()));


//             root.children = new List<Node>(){
//                 child1,
//                 child2,
//             };

//             return root;
//         }

//         public List<int> GetMock2()
//         {
//             return new List<int>(){
//                 5,0,10,6,3,1
//             };
//         }
//     }
