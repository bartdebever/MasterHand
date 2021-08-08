using System;

namespace MeleeLib.MeleeTypes
{
	public struct SectionHeader
	{
		public uint StringOffset { get { return _stringOffset; } set { _stringOffset = value; } }

		public uint DataOffset { get { return _dataOffset; } set { _dataOffset = value; } }

		private buint _dataOffset;
		private buint _stringOffset;
	}
}
