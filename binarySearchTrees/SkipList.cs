﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarySearchTrees
{
    public class SkipList<T> : ICollection<T> where T : IComparable
    {
        SkipListNode<T> head;

        //SkipListNode<T> startNode = new SkipListNode<T>(default(T));

        public int ChooseRandomHeight(int height)
        {
            Random rand = new Random();
            int headORtail = rand.Next(0, 2);

            int maxHeight = head.height + 1;

            while (headORtail != 1 || height >= maxHeight)
            {
                //heads
                height++;
                ChooseRandomHeight(height);
            }
            //tails
            return height;
        }

        public void Add(T value)
        {
            SkipListNode<T> toInsert = new SkipListNode<T>(value);

            if (head == null)
            {
                head = toInsert;
                toInsert.height = 1;
                return;
            }
            else
            {
                int size = 0;

                //count how many is in array
                while (head.neighbors?[size] != null)
                {
                    size++;
                }

                //resize
                SkipListNode<T>[] temp = new SkipListNode<T>[size];
                for (int i = 0; i < size; i++)
                {
                    temp[i] = head.neighbors[i];
                }
                head.neighbors = temp;

                toInsert.height = ChooseRandomHeight(1);
                head.neighbors[0] = toInsert;

            }


            //toInsert.height = ChooseRandomHeight(1);

        }

        public void Clear()
        {
            head = null;
        }

        public bool Contains(T value)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] list, int index)
        {
            throw new NotImplementedException();
        }
        public int Count
        {
            //throw new NotImplementedException();
            get { return head.height; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Remove(T value)
        {

        }

        bool ICollection<T>.Contains(T item)
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
