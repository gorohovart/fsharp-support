﻿using System.Collections.Generic;
using static Module;

namespace ClassLibrary1
{
    public class Class1
    {
        public Class1()
        {
            var r = new R(123);
            int f = r.Foo;
            int fError = r.Compiled;
        }
    }
}
