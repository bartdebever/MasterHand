namespace System
{
    public static class SingleExtension
    {
        public unsafe static float Reverse(this float value)
        {
            *(uint*)(&value) = ((uint*)&value)->Reverse();
            return value;
        }
    }
}
