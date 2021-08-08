using System;

namespace MeleeLib.MeleeTypes
{
	public struct SubactionHeader
	{
		public uint StringOffset { get { return _stringOffset; } set { _stringOffset = value; } }

		public uint ScriptOffset { get { return _scriptOffset; } set { _scriptOffset = value; } }

		public uint Unknown1Offset { get { return _unknown1; } set { _unknown1 = value; } }

		public uint Unknown2Offset { get { return _unknown2; } set { _unknown2 = value; } }

		public uint Unknown3Flags { get { return _unknown3; } set { _unknown3 = value; } }

		public uint Unknown4Offset { get { return _unknown4; } set { _unknown4 = value; } }

		public buint _stringOffset;
		private buint _unknown1;
		private buint _unknown2;
		public buint _scriptOffset;
		private buint _unknown3;
		private buint _unknown4;
	}
}
