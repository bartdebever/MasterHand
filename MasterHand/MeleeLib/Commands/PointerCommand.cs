using System;
using System.ComponentModel;

namespace MeleeLib.Commands
{
	public unsafe class PointerCommand : ScriptCommand
	{
		public PointerCommand(byte* dataPointer) : base(dataPointer, 0x8)
		{
		}

		public PointerCommand(byte* dataPointer, string name) : base(dataPointer, name, 0x8)
		{
		}

		protected override string[] DisplayParams
		{
			get { return new[] { String.Format("@{0:X8}", Pointer) }; }
		}

		[Category("Pointer Params")]
		public uint Pointer
		{
			get { return (*(uint*)(Data + 4)).Reverse(); }
		}
	}
}
