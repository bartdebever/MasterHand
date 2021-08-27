using System;
using System.ComponentModel;

namespace MeleeLib.Commands
{
	public unsafe class AutoCancelCommand : ScriptCommand
	{
		public AutoCancelCommand(byte* dataPointer) : base(dataPointer)
		{
		}

		public AutoCancelCommand(byte* ptr, uint length) : base(ptr, length)
		{
		}

		public AutoCancelCommand(byte* dataPointer, string name) : base(dataPointer, name)
		{
		}

		public AutoCancelCommand(byte* dataPointer, string name, uint length) : base(dataPointer, name, length)
		{
		}

		[Category("Properties")]
		public bool AutoCancelEnabled
		{
			get
			{
				return !Convert.ToBoolean((Data[3]) >> 0 & 0x1);
			}
		}
	}
}
