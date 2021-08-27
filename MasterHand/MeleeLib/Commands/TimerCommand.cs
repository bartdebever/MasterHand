using System;
using System.ComponentModel;

namespace MeleeLib.Commands
{
	public unsafe class TimerCommand : ScriptCommand
	{
		public TimerCommand(byte* ptr)
			: base(ptr)
		{
		}

		public TimerCommand(byte* ptr, string name)
			: base(ptr, name)
		{
		}

		protected override string[] DisplayParams
		{
			get { return new[] { Frames.ToString() }; }
		}


		[Category("Parameters")]
		public ushort Frames
		{
			get { return *(bushort*)(Data + 2); }
		}
	}
}
