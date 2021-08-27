using System.ComponentModel;

namespace MeleeLib.Commands
{
	public unsafe class BodyStateCommand : ScriptCommand
	{
		public BodyStateCommand(byte* dataPointer)
			: base(dataPointer) { }

		public BodyStateCommand(byte* dataPointer, string name)
			: base(dataPointer, name) { }

		public enum BodyTypes
		{
			Normal = 0x0,
			Invulnerable = 0x1,
			Intangible = 0x2
		}
		protected override string[] DisplayParams
		{
			get { return new[] { BodyType.ToString() }; }
		}

		[Category("Parameters")]
		public BodyTypes BodyType
		{
			get { return (BodyTypes)(*(Data + 3) & 0x3); }
		}
	}
}
