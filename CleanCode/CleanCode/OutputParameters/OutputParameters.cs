using CleanCode.Comments;
using System;
using System.Collections.Generic;

namespace CleanCode.OutputParameters
{
    public class InClassName
    {
        public InClassName(int pageIndex)
        {
            PageIndex = pageIndex;
        }

        public int PageIndex { get; private set; }
    }

    public class OutputParameters
    {
        public void DisplayCustomers()
        {
            const int pageIndex = 1;
            var tuple = GetCustomers(new InClassName(pageIndex));

            Console.WriteLine("Total customers: " + tuple.Item1);
            foreach (var c in tuple.Item2)
                Console.WriteLine(c);
        }

        public Tuple<int, IEnumerable<Customer>> GetCustomers(InClassName inClassName)
        {
            var totalCount = 100;
            return Tuple.Create(totalCount, (IEnumerable<Customer>) new List<Customer>());
        }
    }
}
