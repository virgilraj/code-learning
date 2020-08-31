using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class MinStack
    {
        int[] stack { get; set; }
        int[] min { get; set; }
        int topPtr { get; set; }
        int minPtr { get; set; }
        public MinStack()
        {
            this.stack = new int[10000];
            this.min = new int[10000];
            this.topPtr = -1;
            this.minPtr = -1;
        }

       public void push(int ele)
        {
            if (this.topPtr >= 10000) return;
            this.stack[++this.topPtr] = ele;

            //Update Min stack
            if (this.minPtr >= 0)
            {
                if (this.min[this.minPtr] > ele)
                {
                    this.min[++this.minPtr] = ele;
                }
                else
                {
                    this.min[this.minPtr+1] = this.min[this.minPtr];
                }
            }
            else
            {
                this.min[++this.minPtr] = ele;
            }
        }

        public void pop()
        {
            if (this.topPtr < 0) return;
            this.topPtr--;
            this.minPtr--;
        }

        public int top()
        {
            return this.stack[this.topPtr];
        }
        public int getMin()
        {
            return this.min[this.minPtr];
        }
    }
}
