﻿using platform;

namespace account.core
{
    public class Startup : IStartup
    {
        public void _runStart()
        {
            System.Console.WriteLine("hello world!");
        }
    }
}