﻿namespace CustomXaml
{
    using System;

    public class Person
    {
        public Person()
        {
            this.Birthday = DateTime.Now;
        }

        public DateTime Birthday { get; private set; }

        // 名前と給料を追加
        public string FullName { get; set; }
        public int Salary { get; set; }
    }
}
