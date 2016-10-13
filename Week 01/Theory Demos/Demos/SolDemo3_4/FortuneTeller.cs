using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolDemo3_4
{
    public class FortuneTeller<T>
    {
        private Random r;

        private T item1;
        private T item2;
        private T item3;
        private T item4;

        public FortuneTeller()
        {
            r = new Random();
        }

        public void SetItems(T item1,T item2,T item3,T item4)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
            this.item4 = item4;

            this.r = new Random();
        }

        public T GetAnswer()
        {
            int choice = r.Next(1, 5);
            switch (choice)
            {
                case 1: return item1;
                case 2: return item2;
                case 3: return item3;
                case 4: return item4;
            }

            return item1;
        }
    }
}
