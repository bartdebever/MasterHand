using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class Int32Extension
    {
        public static int Reverse(this int value)
        {
            return ((value >> 24) & 0xFF) | (value << 24) | ((value >> 8) & 0xFF00) | ((value & 0xFF00) << 8);
        }
    }
}
