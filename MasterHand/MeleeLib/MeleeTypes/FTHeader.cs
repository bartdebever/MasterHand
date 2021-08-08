using System;

namespace MeleeLib.MeleeTypes
{
	public unsafe struct FTHeader
	{
		public uint AttributesOffset { get { return _attributesOffset; } }

		public uint AttributesOffset2 { get { return _attributesOffset2; } }

		public uint SubactionStartOffset
		{
			get { return _subactionStart; }
		}

		public uint SubactionEndOffset
		{
			get { return _subactionEnd; }
		}

		private buint _attributesOffset;
		private buint _attributesOffset2;
		private buint _unknown1;
		private buint _subactionStart;
		private buint _unknown2;
		private buint _subactionEnd;
		public fixed uint values[18];

	}
}
