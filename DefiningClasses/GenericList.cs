namespace ThreeDSpace
{
    using System;
    using System.Text;
    using System.Collections;
    using System.Collections.Generic;

    public class GenericList<T> where T : IComparable<T>
    {
        private T[] elements;
        public int count;
        public int capacity;

        public GenericList(int capacity = 0)
        {
            this.Capacity = capacity;
            this.Elements = new T[Capacity];
            this.Count = 0;
        }

        private T[] Elements
        {
            get
            {
                return this.elements;
            }
            set
            {
                this.elements = value;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                this.count = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        public void Add(T element)
        {
            this.Count++;
            this.Resize(this.Count);
            this.Elements[this.Count - 1] = element;
        }

        public T this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                {
                    throw new IndexOutOfRangeException("Index is out of range!");
                }
                T result = elements[index];
                return result;
            }
            set
            {
                if (index >= count || index < 0)
                {
                    throw new IndexOutOfRangeException("Index is out of range!");
                }
                this.Elements[index] = value;
            }
        }

        public void Remove(int index)
        {
            for (int i = index - 1; i < this.Count - 1; i++)
            {
                this.Elements[i] = this.Elements[i + 1];
            }
            this.Count--;
        }

        public void Insert(T element, int position)
        {
            if (position < 0 || position >= this.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            this.Count++;

            T[] clonedArr = new T[this.Count];
            for (int i = 0; i < position - 1; i++)
            {
                clonedArr[i] = this.Elements[i];
            }
            clonedArr[position - 1] = element;

            for (int i = position; i < clonedArr.Length; i++)
            {
                clonedArr[i] = this.Elements[i - 1];
            }
            this.Elements = new T[clonedArr.Length];

            for (int i = 0; i < this.Elements.Length; i++)
            {
                this.Elements[i] = clonedArr[i];
            }
        }

        public void Clear()
        {
            this.Count = 0;
            this.Capacity = 0;
        }

        public int FindElement(T element)
        {
            return Array.IndexOf(this.Elements, element);
        }

        public override string ToString()
        {
            if (this.Count == 0)
            {
                return "Empty list!";
            }

            var result = new StringBuilder();
            result.Append("Element: ");
            for (int i = 0; i < this.Count; i++)
            {
                result.AppendFormat("{0}", this.Elements[i]);
                if (i + 1 < this.Count)
                {
                    result.Append(", ");
                }
            }
            return result.ToString();
        }

        private void Resize(int capacity)
        {
            this.Capacity = 2 * capacity;
            Array.Resize(ref this.elements, this.Capacity);
        }

        public T Min()
        {
            T result = this.Elements[Count];
            if (Count == 0)
            {
                Console.WriteLine("The list is empty!");
                return result;
            }
            else
            {
                for (int i = 0; i <= this.Count; i++)
                {
                    if (this.Elements[i].CompareTo(result) < 0)
                    {
                        result = this.Elements[i];
                    }
                }
            }

            return result;
        }
        
        public T Max()
        {
            T result = default(T);
            if (Count == 0)
            {
                Console.WriteLine("The list is empty!");
                return result;
            }
            else
            {
                for (int i = 0; i <= this.Count; i++)
                {
                    if (this.Elements[i].CompareTo(result) > 0)
                    {
                        result = this.Elements[i];
                    }
                }

                return result;
            }
        }
    }
}
