using System;
using System.Runtime.InteropServices;

namespace System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct VoidPtr
    {
        //address
        public void* address;

        public byte Byte { get { return *(byte*)address; } }
        public sbyte SByte { get { return *(sbyte*)address; } }
        public ushort UShort { get { return *(bushort*)address; } }
        public short Short { get { return *(bshort*)address; } }
        public uint UInt { get { return *(buint*)address; } }
        public int Int { get { return *(bint*)address; } }
        public float Single { get { return *(bfloat*)address; } }

        public static VoidPtr operator +(VoidPtr p1, VoidPtr p2) { return new VoidPtr() { address = (void*)((uint)p1.address + (uint)p2.address) }; }
        public static VoidPtr operator -(VoidPtr p1, VoidPtr p2) { return new VoidPtr() { address = (void*)((uint)p1.address - (uint)p2.address) }; }
        public static VoidPtr operator +(VoidPtr p1, uint addr) { return new VoidPtr() { address = (void*)((uint)p1.address + addr) }; }
        public static VoidPtr operator +(VoidPtr p1, int addr) { return new VoidPtr() { address = (void*)((uint)p1.address + addr) }; }
        public static VoidPtr operator -(VoidPtr p1, int addr) { return new VoidPtr() { address = (void*)((uint)p1.address - (uint)addr) }; }
        public static bool operator >(VoidPtr p1, VoidPtr p2) { return p1.address > p2.address; }
        public static bool operator <(VoidPtr p1, VoidPtr p2) { return p1.address < p2.address; }
        public static bool operator >=(VoidPtr p1, VoidPtr p2) { return p1.address >= p2.address; }
        public static bool operator <=(VoidPtr p1, VoidPtr p2) { return p1.address <= p2.address; }
        public static bool operator ==(VoidPtr p1, VoidPtr p2) { return p1.address == p2.address; }
        public static bool operator !=(VoidPtr p1, VoidPtr p2) { return p1.address != p2.address; }

        public VoidPtr this[int count, int stride] { get { return this + (count * stride); } }

        //type casts
        public static implicit operator bool(VoidPtr ptr) { return ptr.address != null; }
        public static implicit operator void*(VoidPtr ptr) { return ptr.address; }
        public static implicit operator VoidPtr(void* ptr) { return new VoidPtr() { address = ptr }; }
        public static implicit operator uint(VoidPtr ptr) { return (uint)ptr.address; }
        public static implicit operator VoidPtr(uint ptr) { return new VoidPtr() { address = (void*)ptr }; }
        public static implicit operator int(VoidPtr ptr) { return (int)ptr.address; }
        public static implicit operator VoidPtr(int ptr) { return new VoidPtr() { address = (void*)ptr }; }
        public static implicit operator VoidPtr(IntPtr ptr) { return new VoidPtr() { address = (void*)ptr }; }
        public static implicit operator IntPtr(VoidPtr ptr) { return (IntPtr)ptr.address; }

        public override int GetHashCode() { return (int)address; }
        public override bool Equals(object obj) { return base.Equals(obj); }

        public static void Swap(float* p1, float* p2) { float f = *p1; *p1 = *p2; *p2 = f; }
        public static void Swap(int* p1, int* p2) { int f = *p1; *p1 = *p2; *p2 = f; }
        public static void Swap(short* p1, short* p2) { short f = *p1; *p1 = *p2; *p2 = f; }
        public static void Swap(ushort* p1, ushort* p2) { ushort f = *p1; *p1 = *p2; *p2 = f; }
        public static void Swap(byte* p1, byte* p2) { byte f = *p1; *p1 = *p2; *p2 = f; }
    }
}
