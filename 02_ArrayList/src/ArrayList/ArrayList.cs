using System;
using System.Text;

namespace ArrayList
{
    public class ArrayList<T>
    {
        private const int _defaultCapactity = 2;
        private const int _elementNotFound = -1;
        private int _size = 0;
        private T[] _elements;

        public ArrayList():this(_defaultCapactity)
        {
            
        }

        public ArrayList(int capacity)
        {
            capacity = capacity < _defaultCapactity? _defaultCapactity:capacity;
            _elements = new T[capacity];
        }


        //元素数量
        public int Size()
        {
            return this._size;
        }

        //是否为空                     
        public bool IsEmpty()
        {
            return this._size==0;
        }  

        //是否包含某个元素
        public bool Contains(T element)
        {
            return IndexOf(element) != _elementNotFound;
        }

        //添加元素到最后面
        public void Add(T element)
        {
            Add(_size,element);
        }  

        //往index位置添加元素
        public void Add(int index, T element)
        {
            RangeCheckForAdd(index);
            EnsureCapacity(_size +1);
            for (int i = _size; i > index; i--)
            {
                _elements[i] = _elements[i-1];
            }
            _elements[index] = element;
            _size++;
        }
        
        //返回index位置元素
        public T Get(int index)
        {
            RangeCheck(index);
            return _elements[index];
        }   

        //设置index位置元素
        public T Set(int index, T element)
        {
            RangeCheck(index);
            T oldElement =default(T);
            _elements[index] = element;
            return oldElement;
        } 

        //删除index位置元素
        public T Remove(int index)
        {
            RangeCheck(index);
            T oldElement = _elements[index];
            for (int i = index; i < _size - 1; i++)
            {
                _elements[i] = _elements[i+1];
            }
            _elements[--_size] = default(T);
            return oldElement;
        }           
        
        //查看元素位置
        public int IndexOf(T element)
        {
            if(element == null)
            {
                for (int i = 0; i < _size; i++)
                {
                    if(_elements[i] == null)
                        return i;
                }
            }
            else{
                for (int i = 0; i < _size; i++)
                {
                    if(element.Equals(_elements[i]))
                        return i;
                }   
            }
            
            return _elementNotFound;
        }
        
        //清除所有元素
        public void Clear()
        {
            for (int i = 0; i < _size; i++)
            {
                _elements[i] = default(T);
            }
            this._size = 0;
        }                   
        
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($" Size:{_size},[");
            for (int i = 0; i < _size; i++)
            {
                if (i != 0)
                    builder.Append(",");
                builder.Append(_elements[i]);
            }
            builder.Append("]");
            return builder.ToString();
        }

        private void RangeCheck(int index)
        {
            if(index <0 || index >= _size)
                IndexOutOfRangeException(index);
        }

        private void RangeCheckForAdd(int index)
        {
            if(index <0 || index > _size)
                IndexOutOfRangeException(index);
        }
        private void IndexOutOfRangeException(int index)
        {
            throw new IndexOutOfRangeException($"Size:{_size},Index:{index}");
        }

        //保证数组容量
        private void EnsureCapacity(int capacity)
        {
            int oldCapacity = _elements.Length;
            if(oldCapacity < capacity)
            {
                int newCapacity = oldCapacity + (oldCapacity >>1);
                T[] newElements = new T[newCapacity];
                for (int i = 0; i < _size; i++)
                {
                    newElements[i] = _elements[i];
                }
                _elements = newElements;
                System.Console.WriteLine($"{oldCapacity}扩容为{newCapacity}");
            }
        }

    }
}