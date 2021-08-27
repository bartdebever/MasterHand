using System;
using System.ComponentModel;

namespace MeleeLib.Commands
{
	public unsafe class ThrowCommand : CollisionCommand
	{
		public enum ThrowElementType
		{
			Normal = 0x0,
			Fire = 0x1,
			Electric = 0x2,
			Ice = 0x5,
			Darkness = 0xD
		}

		public enum ThrowTypes
		{
			Throw = 0x00,
			Release = 0x01,
		}

		public ThrowCommand(byte* dataPointer) : base(dataPointer, "Throw", 0xc) { }

		public ThrowTypes ThrowType
		{
			get { return (ThrowTypes)(*(bushort*)(Data) >> 7 & 0x7); }
		}

		protected override string[] DisplayParams
		{
			get { return new[] { ThrowType.ToString() }; }
		}

		[Category("Stats")]
		public int Damage
		{
			get { return *(bushort*)(Data + 2) >> 0 & 0x1FF; }
		}

		[Category("Stats")]
		public int KnockbackGrowth
		{
			get { return *(bushort*)(Data + 5) >> 6 & 0x1FF; }
		}

		[Category("Stats")]
		public int WeightDependantKnockback
		{
			get { return *(bushort*)(Data + 6) >> 5 & 0x1FF; }
		}

		[Category("Cosmetic")]
		public ThrowElementType ThrowElement
		{
			get { return (ThrowElementType)(*(short*)(Data + 9) >> 3 & 0xF); }
		}

		[Category("Stats")]
		public int Angle
		{
			get { return *(bushort*)(Data + 4) >> 7 & 0x1FF; }
		}

		[Category("Stats")]
		public int BaseKnockback
		{
			get { return *(bushort*)(Data + 8) >> 7 & 0x1FF; }
		}
	}
}
