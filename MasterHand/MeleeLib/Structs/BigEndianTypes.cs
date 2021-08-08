using System;
using System.Runtime.InteropServices;

namespace System
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct bint
    {
        public int _data;
        public static implicit operator int(bint val) { return val._data.Reverse(); }
        public static implicit operator bint(int val) { return new bint { _data = val.Reverse() }; }
        public static explicit operator uint(bint val) { return (uint)val._data.Reverse(); }
        public static explicit operator bint(uint val) { return new bint { _data = (int)val.Reverse() }; }

        public VoidPtr Address { get { fixed (void* p = &this)return p; } }

        public int Value { get { return (int)this; } }
        public override string ToString()
        {
            return Value.ToString();
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct buint
    {
        public uint _data;
        public static implicit operator uint(buint val) { return val._data.Reverse(); }
        public static implicit operator buint(uint val) { return new buint { _data = val.Reverse() }; }
        public static explicit operator int(buint val) { return (int)val._data.Reverse(); }
        public static explicit operator buint(int val) { return new buint { _data = (uint)val.Reverse() }; }

        public VoidPtr Address { get { fixed (void* p = &this)return p; } }

        public uint Value { get { return (uint)this; } }
        public override string ToString()
        {
            return Value.ToString();
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct bfloat
    {
        public float _data;
        public static implicit operator float(bfloat val) { return val._data.Reverse(); }
        public static implicit operator bfloat(float val) { return new bfloat { _data = val.Reverse() }; }

        public VoidPtr Address { get { fixed (void* p = &this)return p; } }

        public float Value { get { return (float)this; } }
        public override string ToString()
        {
            return Value.ToString();
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct bshort
    {
        public short _data;
        public static implicit operator short(bshort val) { return val._data.Reverse(); }
        public static implicit operator bshort(short val) { return new bshort { _data = val.Reverse() }; }
        public static explicit operator ushort(bshort val) { return (ushort)val._data.Reverse(); }
        public static explicit operator bshort(ushort val) { return new bshort { _data = (short)val.Reverse() }; }

        public VoidPtr Address { get { fixed (void* p = &this)return p; } }

        public short Value { get { return (short)this; } }
        public override string ToString()
        {
            return Value.ToString();
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct bushort
    {
        public ushort _data;
        public static implicit operator ushort(bushort val) { return val._data.Reverse(); }
        public static implicit operator bushort(ushort val) { return new bushort { _data = val.Reverse() }; }
        public static explicit operator short(bushort val) { return (short)val._data.Reverse(); }
        public static explicit operator bushort(short val) { return new bushort { _data = (ushort)val.Reverse() }; }

        public VoidPtr Address { get { fixed (void* p = &this)return p; } }

        public ushort Value { get { return (ushort)this; } }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
