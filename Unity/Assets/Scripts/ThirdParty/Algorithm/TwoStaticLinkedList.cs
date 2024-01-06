using System;
using System.Collections.Generic;

namespace M.Algorithm
{
    public class TwoStaticLinkedList<T> //: IEnumerable<T>
    {
        public struct Element
        {
            public int left;
            public int right;
            public T   element;
        }

        private Element[] _elements;
        private int       _totalLength; //总长度
        private int       _effectiveLength; //有效长度
        private int       _jump;

        public int Length
        {
            private set { _effectiveLength = value; }
            get { return _effectiveLength; }
        }

        /// <summary>
        /// 长度不能小于4
        /// </summary>
        /// <param name="length"></param>
        public TwoStaticLinkedList(int jump, int length)
        {
            if (length < 4)
            {
                length = 4;
            }

            _jump = jump;
            this._totalLength = length;
            var list = new Element[length];
            this._elements = list;
            var value = length - 1;

            for (int i = 2; i < value; i++)
            {
                list[i].right = i + 1;
            }

            //[0]的元素代表未使用的链表的起点，[1]的元素代表已使用的链表的起点   //[2,3]是初始的空值
            list[0].right = 2;
            list[1].right = 0;
            list[value].right = 1;
            this.Length = 0;
        }

        public int Add(T t)
        {
            var list = this._elements;

            if (list[0].right == 1) //思考什么情况是这样，初始设置时最后一个的right 为1，即未使用的为最后一个
            {
                this.Expansion();
                list = this._elements;
            }

            var right1 = list[0].right;   //2
            var right2 = list[1].right;   //0
            list[0].right = list[right1].right;  //下一个可用的索引为当前用掉的right
            list[right1].left = 1;   //2的左边是 原来的起点1，这样每次找新的被使用都是
            list[right1].right = right2;  // 每次插到 1和当前的中间
            list[right2].left = right1; // 为上一个使用的赋左值为当前新的
            list[1].right = right1; // 最新的为1的right
            list[right1].element = t;

            Length += 1;

            //返回的是当前最后被使用的元素索引
            return right1;
        }

        /// <summary>
        /// 这个是干嘛
        /// </summary>
        /// <param name="t"></param>
        /// <param name="compare"></param>
        /// <returns></returns>
        public int Add(T t, Func<T, T, bool> compare)
        {
            var list = this._elements;

            if (list[0].right == 1)
            {
                this.Expansion();
                list = this._elements;
            }

            var lastCur = 1;
            var cur = lastCur;
            var cur1 = cur;
            var b = Length <= _jump;

            while (true)
            {
                if (b)
                {
                    lastCur = cur;
                    cur = list[lastCur].right; //上一个有元素的
                    //0代表没有元素   //还需要比较加入的元素和最新的元素
                    if (cur == 0 || compare(t, list[cur].element))
                    {
                        Length += 1;
                        int index;

                        if (lastCur == 1)
                        {
                            var right1 = list[0].right;
                            var right2 = list[1].right;
                            list[0].right = list[right1].right;
                            list[right1].left = 1;
                            list[right1].right = right2;
                            list[right2].left = right1;
                            list[1].right = right1;
                            list[right1].element = t;
                            index = right1;
                        }
                        else
                        {
                            if (cur == 0) //理论上应该没0
                            {
                                var right = list[0].right;
                                list[0].right = list[right].right;
                                list[right].left = lastCur;
                                list[right].right = 0;
                                list[lastCur].right = right;
                                list[right].element = t;
                                index = right;
                            }
                            else
                            {
                                var right = list[0].right;
                                list[0].right = list[right].right;
                                list[right].left = list[cur].left;
                                list[right].right = cur;
                                list[list[cur].left].right = right;
                                list[cur].left = right;
                                list[right].element = t;
                                index = right;
                            }
                        }

                        return index;
                    }

                    if (Length > _jump && cur == cur1) 
                    {
                        b = false;
                    }
                }
                else
                {
                    cur1 = cur;
                    var result = false;

                    for (int i = 0; i < _jump; i++)
                    {
                        cur1 = list[cur1].right;

                        if (cur1 == 0)
                        {
                            result = true;

                            break;
                        }
                    }

                    if (result || compare(t, list[cur1].element))
                    {
                        b = true;
                    }
                    else
                    {
                        cur = cur1;
                    }
                }
            }
        }

        public void Remove(T t)
        {
            var list = this._elements;
            var lastCur = 1;
            var cur = list[lastCur].right;

            while (cur != 0)
            {
                if (EqualityComparer<T>.Default.Equals(list[cur].element, t))
                {
                    var right = list[cur].right;
                    list[cur].element = default; //已经置空
                    list[lastCur].right = right;
                    list[right].left = lastCur;
                    list[cur].right = list[0].right; //把删除的继续作为为使用的头
                    list[0].right = cur;

                    Length -= 1;

                    return;
                }

                lastCur = cur;
                cur = list[lastCur].right;
            }
        }

        public void Remove(int index)
        {
            if (index < 2 || index >= this._totalLength)
            {
                throw new IndexOutOfRangeException("数组索引溢出或该索引禁止访问");
            }

            var list = this._elements;
            var left = list[index].left;
            var right = list[index].right;
            list[index].element = default;
            list[left].right = right;
            list[right].left = left;
            list[index].right = list[0].right;
            list[0].right = index;
            Length -= 1;
        }

        public T Remove(Func<T, bool> call)
        {
            var list = this._elements;
            var lastCur = 1;
            var cur = list[lastCur].right;

            while (cur != 0)
            {
                if (call(list[cur].element))  //这个删除其实可以封装出来
                {
                    var element = list[cur].element;
                    var right = list[cur].right;
                    list[cur].element = default;
                    list[lastCur].right = right;
                    list[right].left = lastCur;
                    list[cur].right = list[0].right;
                    list[0].right = cur;

                    Length -= 1;

                    return element;
                }

                lastCur = cur;
                cur = list[lastCur].right;
            }

            return default;
        }

        public bool Contains(T t)
        {
            var list = this._elements;
            var temp = this._elements[1];

            while (temp.right != 0)
            {
                temp = list[temp.right];

                if (EqualityComparer<T>.Default.Equals(temp.element, t))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 扩容一倍
        /// </summary>
        private void Expansion()
        {
            this._totalLength *= 2;
            var tempElements = new Element[this._totalLength];
            var length = this._elements.Length;
            var value = this._totalLength - 1;

            Array.Copy(this._elements, 0, tempElements, 0, length);

            for (int i = length; i < value; i++)
            {
                tempElements[i].right = i + 1;
            }

            tempElements[0].right = length;
            tempElements[value].right = 1;
            this._elements = tempElements;
        }

        public void Clear()
        {
            var list = this._elements;
            var len = this._totalLength - 1;

            for (int i = 2; i < len; i++)
            {
                list[i].right = i + 1;
                list[i].element = default;
            }

            //0代表未使用的链表，1代表已使用的链表
            list[0].right = 2;
            list[1].right = 0;
            list[len].right = 1;
            list[len].element = default;
            this.Length = 0;
        }

        public T GetValue(int i)
        {
            return this._elements[i].element;
        }

        public Element this[int i]
        {
            set => _elements[i] = value;
            get => _elements[i];
        }

        //public IEnumerator<T> GetEnumerator()
        //{
        //    var list = this._elements;
        //    var cur = list[1].right;

        //    while (cur != 0)
        //    {
        //        yield return list[cur].element;
        //        cur = list[cur].right;
        //    }
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return this.GetEnumerator();
        //}
    }
}