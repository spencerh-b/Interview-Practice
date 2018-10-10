using System;
using System.Collections.Generic;

public static class Program{
    public static void Main(){
        string newStr = URLify("Mr John Smith",13);
        string compression = StrCompression("aabcccccaaas");
        Console.WriteLine(newStr);
        Console.WriteLine(compression);

        LinkedList<int> L1 = new LinkedList<int>();
        L1.AddLast(7);
        L1.AddLast(1);
        L1.AddLast(6);

        LinkedList<int> L2 = new LinkedList<int>();
        L2.AddLast(5);
        L2.AddLast(9);
        L2.AddLast(2);

        foreach (var item in sumLists(L1,L2))
        {
            Console.Write(item + "->");
        }
        Console.WriteLine("null");

        Stack<int> myStack = new Stack<int>();
        myStack.Push(6);
        myStack.Push(3);
        myStack.Push(9);
        myStack.Push(14);
        myStack.Push(-2);
        myStack.Push(5);
        myStack.Push(10);

        myStack = SortStack(myStack);

        foreach(var node in myStack){
            Console.WriteLine(node);
        }

        BSTree myBST = new BSTree();
        myBST.Add(40);
        myBST.Add(20);
        myBST.Add(60);
        myBST.Add(10);
        myBST.Add(30);
        myBST.Add(50);
        myBST.Add(70);
        myBST.Add(15);
        myBST.Add(35);
        myBST.Add(55);
        myBST.Add(75);
        myBST.Add(5);
        myBST.Add(25);
        myBST.Add(45);
        myBST.Add(65);

        List<List<TreeNode>> lists = TreeDepth(myBST);
        Console.WriteLine("");

        foreach(var level in lists){
            foreach(var node in level){
                Console.Write(node.Data + " ");
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }

        HashSet<int> mySet = new HashSet<int>();
        
        try
        {
            mySet.Add(5);
            mySet.Add(5);

            foreach(var node in mySet){
                Console.WriteLine(node);
            }
        }
        catch
        {
            Console.WriteLine("Welp... You done learned it.");
        }

        Dictionary<char,int> myDict = new Dictionary<char,int>();

        try
        {
            ++myDict['a'];
            Console.WriteLine("1");
            ++myDict['b'];
            Console.WriteLine("2");
            ++myDict['a'];
            Console.WriteLine("3");
            ++myDict['c'];
            Console.WriteLine("4");

            foreach(var node in myDict){
                Console.WriteLine(node.Key + "  " + node.Value);
            }
        }
        catch
        {
            Console.WriteLine("Welp... You done learned it #2.");
        }
    }

    private static string URLify(string oldStr, int trueLength){
        string[] subStrings = oldStr.Split(' ');
        string newStr = "";
        foreach(var str in subStrings){
            newStr = newStr + str + "%20";
        }
        newStr = newStr.Substring(0,newStr.Length-3);
        return newStr;
    }

    private static string StrCompression(string oldStr){
        string newStr = "";
        int count = 1;
        for (int index = 0; index < oldStr.Length - 1; index++)
        {
            if(oldStr[index] == oldStr[index+1]){
                count++;
            }
            else{
                newStr += oldStr[index].ToString() + count.ToString();
                count = 1;
            }
        }
        newStr += oldStr[oldStr.Length-1].ToString() + count.ToString();
        if (newStr.Length > oldStr.Length)
        {
            newStr = oldStr;
        }
        return newStr;
    }
   
    private static LinkedList<int> sumLists(LinkedList<int> L1, LinkedList<int> L2){
        int L1Value = Int32.Parse(AddList(L1.First));
        int L2Value = Int32.Parse(AddList(L2.First));
        string newValue = (L1Value + L2Value).ToString();
        LinkedList<int> newList = new LinkedList<int>();
        foreach(char digit in newValue){
            newList.AddLast(Int32.Parse(digit.ToString()));
        }
        return newList;
    }

    private static string AddList(LinkedListNode<int> pCur){
        if(pCur != null){
            return AddList(pCur.Next) + pCur.Value;
        }
        return "";
    }

    private static Stack<int> SortStack(Stack<int> unsortedStack){
        Stack<int> tempStack = new Stack<int> ();
        tempStack.Push(unsortedStack.Pop());
        int tempNode;
        while(unsortedStack.Count > 0){
            if (tempStack.Count == 0){
                tempStack.Push(unsortedStack.Pop());
            }
            if(tempStack.Peek()>unsortedStack.Peek()){
                tempNode = tempStack.Pop();
                tempStack.Push(unsortedStack.Pop());
                unsortedStack.Push(tempNode);
                unsortedStack.Push(tempStack.Pop());
            }
            else{
                tempStack.Push(unsortedStack.Pop());
            }
        }
        while(tempStack.Count > 0){
            unsortedStack.Push(tempStack.Pop());
        }
        return unsortedStack;
    }

    private static List<List<TreeNode>> TreeDepth(BSTree myTree){
        List<List<TreeNode>> lists = new List<List<TreeNode>>();
        Queue<TreeNode> depthQueue = new Queue<TreeNode>();
        depthQueue.Enqueue(myTree.Root);

        while(depthQueue.Count > 0){
            int tempCount = lists.Count;
            lists.Add(new List<TreeNode>());
            while(depthQueue.Count > 0){
                lists[tempCount].Add(depthQueue.Dequeue());
            }
            foreach(var node in lists[tempCount]){
                if(node.Left != null){
                    depthQueue.Enqueue(node.Left);
                }
                if(node.Right != null){
                    depthQueue.Enqueue(node.Right);
                }
            }
        }
        return lists;
    }
}
public class BSTree{
    void Tree(){
        root = null;
    }
    public void Add(int newNode){
        if(root != null){
            Add(root,newNode);
        }
        else{
            root = new TreeNode(newNode);
        }
    }
    private void Add(TreeNode pCur, int newNode){
        if(pCur.Data > newNode){
            if(pCur.Left != null){
                Add(pCur.Left,newNode);
            }
            else{
                pCur.Left = new TreeNode(newNode);
            }
        }
        else if(pCur.Data < newNode){
            if(pCur.Right != null){
                Add(pCur.Right,newNode);
            }
            else{
                pCur.Right = new TreeNode(newNode);
            }
        }
    }

    public void PreOrder(){
        PreOrder(root);
    }

    public void InOrder(){
        InOrder(root);
    }

    public void PostOrder(){
        PostOrder(root);
    }


    private void PreOrder(TreeNode pCur){
        if(pCur != null){
            Console.Write(pCur.Data.ToString() + " ");
            PreOrder(pCur.Left);
            PreOrder(pCur.Right);
        }
    }

    private void InOrder(TreeNode pCur){
        if(pCur != null){
            InOrder(pCur.Left);
            Console.Write(pCur.Data.ToString() + " ");
            InOrder(pCur.Right);
        }
    }

    private void PostOrder(TreeNode pCur){
        if(pCur != null){
            PostOrder(pCur.Left);
            PostOrder(pCur.Right);
            Console.Write(pCur.Data.ToString() + " ");
        }
    }

    private TreeNode root;

    public TreeNode Root{
        get{return root;}
    }
}

public class TreeNode{
    public TreeNode(int newData){
        data = newData;
        left = null;
        right = null;
    }
    private int data;
    private TreeNode left;
    private TreeNode right;

    public int Data{
        get{return data;}
        set{data = value;}
    }
    public TreeNode Left{
        get{return left;}
        set{left = value;}
    }

    public TreeNode Right{
        get{return right;}
        set{right = value;}
    }
}