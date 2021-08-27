using System;
using System.ComponentModel;

namespace MeleeLib.Commands
{
	public unsafe class PartialBodyStateCommand : BodyStateCommand
	{
		public PartialBodyStateCommand(byte* dataPointer, string s) : base(dataPointer, s)
		{
		}
		protected override string[] DisplayParams
		{
			get
			{
				return new[] { Bone.ToString(), BodyType.ToString() };
			}
		}
		[Category("Parameters")]
		public ushort Bone
		{
			get { return (ushort)(*(bushort*)(Data) & 0x7F); }
		}
	}
}
