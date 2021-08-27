using System;
using System.ComponentModel;

namespace MeleeLib.Commands
{

	public unsafe class HitboxCommand : CollisionCommand
	{
		public enum ElementType
		{
			Normal = 0x00,
			Fire = 0x04,
			Electric = 0x08,
			Slash = 0x0C,
			Coin = 0x10,
			Ice = 0x14,
			Sleep = 0x18,
			Sleep2 = 0x1C,
			Grounded = 0x20,
			Grounded2 = 0x24,
			Cape = 0x28,
			Empty = 0x2C,
			Disabled = 0x30,
			ScrewAttack = 0x38,
			PoisonFlower = 0x3C,
			Nothing = 0x40
		}
		public HitboxCommand(byte* ptr) : base(ptr, "Hitbox", 0x14) { }

		public enum HurtboxInteractionFlags
		{
			NoClank, SomeClank, MoreClank, AllClank
		}

		[Category("Identifier")]
		public int ID
		{
			get { return *(bushort*)(Data) >> 7 & 0x7; }
		}

		[Category("Unknown")]
		public int UnknownR
		{
			get { return ((Data[1] & 0x7B) >> 2); }
		}

		[Category("Position")]
		public int BoneID
		{
			get { return *(bushort*)(Data + 1) >> 3 & 0x7F; }
		}
		[Category("Unknown")]
		public int Unknown0
		{
			get { return ((Data[2] & 0x07) >> 1); }
		}

		[Category("Position")]
		public int Size
		{
			get { return *(bushort*)(Data + 4) >> 0 & 0xFFFF; }
		}

		[Category("Position")]
		public int ZOffset
		{
			get { return *(bshort*)(Data + 6); }
		}

		[Category("Position")]
		public int YOffset
		{
			get { return *(bshort*)(Data + 8); }
		}

		[Category("Position")]
		public int XOffset
		{
			get { return *(bshort*)(Data + 10); }
		}

		[Category("Unknown")]
		public int UnknownQ
		{
			get { return (Data[15]) >> 2 & 0x7; }
		}

		[Category("Flags")]
		public HurtboxInteractionFlags HurtboxInteraction
		{
			get { return (HurtboxInteractionFlags)((Data[15]) >> 0 & 0x3); }
		}

		[Category("Stats")]
		public int BaseKnockback
		{
			get { return *(bushort*)(Data + 16) >> 7 & 0xFFFF; }
		}

		[Category("Unknown")]
		public int UnknownV
		{
			get { return (Data[17]) >> 1 & 0x1; }
		}

		[Category("Stats")]
		public int ShieldDamage
		{
			get { return *(bushort*)(Data + 17) >> 2 & 0x3F; }
		}

		[Category("Cosmetic")]
		public int SFX
		{
			get { return *(bushort*)(Data + 18) >> 2 & 0xFF; }
		}

		[Category("Flags")]
		public bool HitsGround
		{
			get { return Convert.ToBoolean((Data[19]) >> 1 & 0x1); }
		}

		[Category("Flags")]
		public bool HitsAir
		{
			get { return Convert.ToBoolean((Data[19]) >> 0 & 0x1); }
		}

		protected override string[] DisplayParams
		{
			get { return new [] { ID.ToString() }; }
		}

		[Category("Stats")]
		public int Damage
		{
			get { return *(bushort*)(Data + 2) >> 0 & 0x1FF; }
		}

		[Category("Stats")]
		public int KnockbackGrowth
		{
			get { return *(bushort*)(Data + 13) >> 6 & 0x1FF; }
		}

		[Category("Stats")]
		public int WeightDependantKnockback
		{
			get { return *(bushort*)(Data + 14) >> 5 & 0x1FF; }
		}

		[Category("Cosmetic")]
		public ElementType Element
		{
			get { return (ElementType)(*(bushort*)(Data + 17) >> 2 & 0x1F); }
		}

		[Category("Stats")]
		public int Angle
		{
			get { return *(bushort*)(Data + 12) >> 7 & 0xFFFF; }
		}

	}
}
