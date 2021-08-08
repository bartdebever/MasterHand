namespace System
{
    public static class UInt32Extension
    {
        public static uint Reverse(this uint value)
        {
            return ((value >> 24) & 0xFF) | (value << 24) | ((value >> 8) & 0xFF00) | ((value & 0xFF00) << 8);
        }
    }
}
