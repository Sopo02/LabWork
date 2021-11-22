using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTreeProject
{

    public class BinaryTree<T> : ICollection<T> where T : class, IComparable<T>
    {

        #region Node

        private enum Side { Left, Right }

        private class Node : IComparable<Node>
        {
            public T data;
            public Side parentSide;
            public Node parent;
            public Node right;
            public Node left;


            public Node(T _data)
            {
                data = _data;
                parent = null;
                right = null;
                left = null;
            }

            public int CompareTo(Node other)
            {
                return data.CompareTo(other.data);
            }
        }

        #endregion


        private Node root;


        public BinaryTree()
        {
            root = null;
            Count = 0;
        }


        public int Count { get; private set; }
        public bool IsReadOnly { get { return false; } }


        public void Add(T item)
        {
            var addNode = new Node(item);

            if (root == null) { root = addNode; Count++; return; }
            else
            {
                var currentNode = root;
                var prevNode = root;

                bool flag = true;
                while (flag)
                {
                    flag = false;

                    int index = currentNode.CompareTo(addNode);

                    //уходим в право
                    if (index < 0)
                    {
                        if (currentNode.right == null)
                        {
                            //установка родителя для новой ноди
                            addNode.parent = prevNode;
                            addNode.parentSide = Side.Right;

                            //присвоения ноди в дереве
                            currentNode.right = addNode;

                            Count++;
                            return;
                        }
                        else
                        {
                            //передвиг предадушей ноди на ноду текущую
                            currentNode = currentNode.right;
                            prevNode = currentNode;

                            flag = true;
                        }
                    }
                    //уходим в лево
                    else if (index > 0)
                    {
                        if (currentNode.left == null)
                        {
                            //установка родителя для новой ноди
                            addNode.parent = prevNode;
                            addNode.parentSide = Side.Left;


                            //присвоения ноди в дереве
                            currentNode.left = addNode;

                            Count++;
                            return;
                        }
                        else
                        {
                            currentNode = currentNode.left;
                            prevNode = currentNode;

                            flag = true;
                        }
                    }
                    else { throw new ArgumentException("Даний об'єк уже є в дереві."); }
                }
            }
        }
        public void Clear()
        {
            root = null;
            Count = 0;
        }
        public bool Contains(T item)
        {
            var currentNode = root;
            while (true)
            {
                if (currentNode == null) { return false; }

                int index = currentNode.data.CompareTo(item);

                if (index == 0) { return true; }
                else if (index < 0) { currentNode = currentNode.right; }
                else { currentNode = currentNode.left; }
            }
        }
        public bool Remove(T item)
        {
            var removeNode = GetNode(item);

            //Если корень null
            if (root == null) { return false; }
            //Если корень пустой очистить дерево
            if (removeNode.Equals(root) && root.left == null && root.right == null) { Clear(); return true; }


            //если правая и левая ноди пустие
            if (removeNode.left == null && removeNode.right == null)
            {
                var parentNode = removeNode.parent;
                if (removeNode.parentSide == Side.Left)
                {
                    parentNode.left = null;
                }
                else { parentNode.right = null; }
            }
            //если левая нода пустая
            else if (removeNode.left == null)
            {
                var parentNode = removeNode.parent;
                if (removeNode.parentSide == Side.Left)
                {
                    removeNode.right.parentSide = Side.Left;
                    removeNode.right.parent = parentNode;
                    parentNode.left = removeNode.right;
                }
                else
                {
                    removeNode.right.parentSide = Side.Right;
                    removeNode.right.parent = parentNode;
                    parentNode.right = removeNode.right;
                }
            }
            //если правая нода пустая
            else if (removeNode.right == null)
            {
                var parentNode = removeNode.parent;
                if (removeNode.parentSide == Side.Left)
                {
                    removeNode.left.parentSide = Side.Left;
                    removeNode.left.parent = parentNode;
                    parentNode.left = removeNode.left;
                }
                else
                {
                    removeNode.left.parentSide = Side.Right;
                    removeNode.left.parent = parentNode;
                    parentNode.right = removeNode.left;
                }
            }
            //когда правая и левая часть не null
            else
            {
                //если нада удалить корень
                if (removeNode == root)
                {
                    removeNode.right.parent = null;
                    root = removeNode.right;
                    AddNode(removeNode.left);
                }
                //если ето не корень
                else
                {
                    switch (removeNode.parentSide)
                    {
                        case Side.Left:
                            {
                                removeNode.parent.left = removeNode.right;
                                removeNode.right.parent = removeNode.parent;
                                removeNode.right.parentSide = Side.Left;
                                AddNode(removeNode.left);

                                break;
                            }
                        case Side.Right:
                            {
                                removeNode.right.parent = removeNode.parent;
                                removeNode.right.parentSide = Side.Right;
                                removeNode.parent.right = removeNode.right;
                                AddNode(removeNode.left);

                                break;
                            }
                    }
                }
            }


            Count--;
            return true;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }



        //Добавить ноду но без изменения Count
        private void AddNode(Node addNode)
        {
            if (root == null) { root = addNode; }
            else
            {
                var currentNode = root;
                var prevNode = root;

                bool flag = true;
                while (flag)
                {
                    flag = false;

                    int index = currentNode.CompareTo(addNode);

                    //уходим в право
                    if (index < 0)
                    {
                        if (currentNode.right == null)
                        {
                            //установка родителя для новой ноди
                            addNode.parent = prevNode;
                            addNode.parentSide = Side.Right;

                            //присвоения ноди в дереве
                            currentNode.right = addNode;

                            return;
                        }
                        else
                        {
                            //передвиг предадушей ноди на ноду текущую
                            currentNode = currentNode.right;
                            prevNode = currentNode;

                            flag = true;
                        }
                    }
                    //уходим в лево
                    else if (index > 0)
                    {
                        if (currentNode.left == null)
                        {
                            //установка родителя для новой ноди
                            addNode.parent = prevNode;
                            addNode.parentSide = Side.Left;


                            //присвоения ноди в дереве
                            currentNode.left = addNode;

                            return;
                        }
                        else
                        {
                            currentNode = currentNode.left;
                            prevNode = currentNode;

                            flag = true;
                        }
                    }
                    else { throw new ArgumentException("Даний об'єк уже є в дереві."); }
                }
            }
        }
        //получить ноду по даним
        private Node GetNode(T item)
        {
            var currentNode = root;
            while (true)
            {
                if (currentNode == null) { return null; }

                int index = currentNode.data.CompareTo(item);

                if (index == 0) { return currentNode; }
                else if (index < 0) { currentNode = currentNode.right; }
                else { currentNode = currentNode.left; }
            }
        }



        #region Enumerator

        //Итераторы 
        public IEnumerator<T> GetEnumerator() { return new PostOrder(root); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        
        //Обход дерева
        private class PostOrder : IEnumerator<T>
        {
            private Node mainNode;
            private Node currentNode;
            private List<Node> visitedNode;

            private bool goLeft;
            private bool goRight;

            private bool isFirst;


            public T Current => currentNode.data;
            object IEnumerator.Current => Current;


            public PostOrder(Node root)
            {
                mainNode = root;
                currentNode = mainNode;
                visitedNode = new List<Node>();

                goLeft = true;
                goRight = true;

                isFirst = true;
            }


            #region ServiceMethod

            private bool IsNotHere(Node node)
            {
                foreach (var item in visitedNode)
                {
                    if (item.CompareTo(node) == 0) { return false; }
                }
                return true;
            }
            private Node GetMaxLeftNode(Node node)
            {
                var tempNode = node;

                while (tempNode.left != null) { tempNode = tempNode.left; }

                return tempNode;
            }
            private bool GoCurrentNodes()
            {
                //проход до корня
                while (currentNode != mainNode)
                {
                    if (currentNode.left != null && IsNotHere(currentNode.left))
                    {
                        currentNode = GetMaxLeftNode(currentNode.left);

                        if (IsNotHere(currentNode))
                        {
                            visitedNode.Add(currentNode);
                            return true;
                        }

                    }
                    if (currentNode.right != null && IsNotHere(currentNode.right))
                    {
                        currentNode = GetMaxLeftNode(currentNode.right);

                        if (IsNotHere(currentNode))
                        {
                            visitedNode.Add(currentNode);
                            return true;
                        }
                    }


                    currentNode = currentNode.parent;


                    if (currentNode.left != null && IsNotHere(currentNode.left))
                    {
                        currentNode = GetMaxLeftNode(currentNode.left);

                        if (IsNotHere(currentNode))
                        {
                            visitedNode.Add(currentNode);
                            return true;
                        }

                    }
                    if (currentNode.right != null && IsNotHere(currentNode.right))
                    {
                        currentNode = GetMaxLeftNode(currentNode.right);

                        if (IsNotHere(currentNode))
                        {
                            visitedNode.Add(currentNode);
                            return true;
                        }
                    }


                    if (IsNotHere(currentNode))
                    {
                        visitedNode.Add(currentNode);
                        return true;
                    }
                }

                return false;
            }

            #endregion


            //Функция обхода
            public bool MoveNext()
            {
                if (mainNode == null) { return false; }
                if (!isFirst) { return false; }

                if (mainNode.left == null && mainNode.right == null && isFirst)
                {
                    isFirst = false;
                    currentNode = mainNode;
                    visitedNode.Add(currentNode);

                    return true;
                }


                if (mainNode.left != null && goLeft)
                {
                    goLeft = false;
                    currentNode = GetMaxLeftNode(mainNode.left);
                    visitedNode.Add(currentNode);

                    return true;
                }
                if (mainNode.left == null && mainNode.right != null && goRight)
                {
                    goRight = false;
                    currentNode = GetMaxLeftNode(mainNode.right);
                    visitedNode.Add(currentNode);

                    return true;
                }


                return GoCurrentNodes();
            }
            public void Reset() { currentNode = mainNode; }
            public void Dispose() { }
        }

        #endregion

    }
}
