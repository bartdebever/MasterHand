using System;
using System.ComponentModel;

namespace MeleeLib.Commands
{
	public unsafe class StartLoopCommand : ScriptCommand
	{
		public StartLoopCommand(byte* dataPointer) : base(dataPointer)
		{
		}

		public StartLoopCommand(byte* dataPointer, string name) : base(dataPointer, name)
		{
		}

		protected override string[] DisplayParams
		{
			get { return new[] { Iterations.ToString() }; }
		}

		[Category("Loop Params")]
		public ushort Iterations
		{
			get { return *(bushort*)(Data + 2); }
		}
	}
}
