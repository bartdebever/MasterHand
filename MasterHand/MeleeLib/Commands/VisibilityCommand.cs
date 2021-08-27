using System.ComponentModel;

namespace MeleeLib.Commands
{
	public unsafe class VisibilityCommand : ScriptCommand
	{
		public VisibilityCommand(byte* dataPointer) : base(dataPointer)
		{
		}

		public enum VisibilityConstant
		{
			Invisible = 0x0,
			Visible = 0x1
		}

		[Category("Parameters")]
		public VisibilityConstant Visibility
		{
			get { return (VisibilityConstant)((Data[3]) >> 0 & 0x1); }
		}

		protected override string[] DisplayParams
		{
			get { return new[] { Visibility.ToString() }; }
		}
	}
}
