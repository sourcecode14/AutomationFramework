using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation
{
    public abstract class TestBase
    {
        public TestBase() 
        {
            
        }

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Setup");
        }

        [OneTimeSetUp]

        public void OnTimeSetup() 
        {
            Console.WriteLine("OnetimeSetup");
        }

        

    }
}
