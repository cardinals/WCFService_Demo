﻿using OverloadableContract.Client.CalculatorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadableContract.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin to invocate generated proxy...");
            InvocateGeneratedProxy();

            Console.WriteLine("\nBegin to invocate revised proxy...");
            InvocateRevisedProxy();

            Console.Read();
        }

        static void InvocateGeneratedProxy()
        {
            using (CalculatorClient calculator = new CalculatorClient())
            {
                Console.WriteLine("x + y = {2} where x = {0} and y = {1}", 1, 2, calculator.AddWithTwoOperans(1, 2));
                Console.WriteLine("x + y + z = {3} where x = {0} and y = {1} and z = {2}", 1, 2, 3, calculator.AddWithThreeOperands(1, 2, 3));
            }
        }

        static void InvocateRevisedProxy()
        {
            using (MyCalculatorClient calculator = new MyCalculatorClient())
            {
                Console.WriteLine("x + y = {2} where x = {0} and y = {1}", 1, 2, calculator.Add(1, 2));
                Console.WriteLine("x + y + z = {3} where x = {0} and y = {1} and z = {2}", 1, 2, 3, calculator.Add(1, 2, 3));
            }
        }
    }
}
