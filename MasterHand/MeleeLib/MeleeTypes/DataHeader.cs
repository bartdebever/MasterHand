using System;

namespace MeleeLib.MeleeTypes
{
	public unsafe struct DatHeader
	{
		public uint FileSize { get { return _fileSize; } set { _fileSize = value; } }

		public uint DataSize { get { return _dataSize; } set { _dataSize = value; } }

		public uint OffsetCount { get { return _offsetCount; } set { _offsetCount = value; } }

		public uint SectionTypeOneCount { get { return sectionTypeOneCount; } set { sectionTypeOneCount = value; } }

		public uint SectionTypeTwoCount { get { return sectionTypeTwoCount; } set { sectionTypeTwoCount = value; } }

		public uint Unknown1 { get { return _unknown1; } set { _unknown1 = value; } }

		public uint Unknown2 { get { return _unknown2; } set { _unknown2 = value; } }

		private buint _fileSize;
		private buint _dataSize;
		private buint _offsetCount;
		private buint sectionTypeOneCount;
		private buint sectionTypeTwoCount;
		private fixed byte version[4];
		private buint _unknown1;
		private buint _unknown2;
	}
}
