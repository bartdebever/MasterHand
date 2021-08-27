using MeleeLib.Commands;
using System;
using System.Text;
using System.ComponentModel;

namespace MeleeLib
{
	public unsafe class ScriptCommand
	{
		public static ScriptCommand Factory(byte* data)
		{
			return ((uint)data[0] >> 2) switch {
				0x00 => new ScriptCommand(data, "End"),
				0x01 => new TimerCommand(data, "Synchronous Timer"),
				0x02 => new TimerCommand(data, "Asynchronous Timer"),
				0x03 => new StartLoopCommand(data),
				0x05 => new PointerCommand(data, "Goto?"),
				0x07 => new PointerCommand(data, "Subroutine?"),
				0x0a => new UnsolvedCommand(data, "Graphic Effect", 0x14),
				0x0b => new HitboxCommand(data),
				0x10 => new ScriptCommand(data, "Remove Hitboxes"),
				0x11 => new UnsolvedCommand(data, "Sound Effect", 0xc),
				0x12 => new UnsolvedCommand(data, "Random Smash SFX"),
				0x13 => new AutoCancelCommand(data, "Autocancel"),
				0x14 => new UnsolvedCommand(data, "Reverse Direction"),
				0x17 => new ScriptCommand(data, "IASA"),
				0x19 => new VisibilityCommand(data),
				0x1a => new BodyStateCommand(data, "Body State 1"),
				0x1b => new BodyStateCommand(data, "Body State 2"),
				0x1c => new PartialBodyStateCommand(data, "Bone State"),
				0x1f => new UnsolvedCommand(data, "Model Mod"),
				0x22 => new ThrowCommand(data),
				0x2b => new	UnsolvedCommand(data, "Rumble"),
				0x33 => new UnsolvedCommand(data, "Self-Damage"),
				0x38 => new UnsolvedCommand(data, "Start Smash Charge", 0x8),
				_ => new UnsolvedCommand(data)
			};
		}

		protected const string DisplayFormat = "{0} [{1}]";
		protected const string DisplayDelimiter = " ";

		[Category("Name")]
		public string DisplayName
		{
			get { return DisplayParams == null ? Name : string.Format(DisplayFormat, Name, string.Join(DisplayDelimiter, DisplayParams)); }
		}

		protected ScriptCommand(byte* dataPointer) : this(dataPointer, null, 0x4) { }

		protected ScriptCommand(byte* ptr, uint length) : this(ptr, null, length) { }

		protected ScriptCommand(byte* dataPointer, string name) : this(dataPointer, name, 0x4) { }

		protected ScriptCommand(byte* dataPointer, string name, uint length)
		{
			Data = dataPointer;
			Name = name;
			Length = length;
		}

		private string _name;

		[Category("Name")]
		public string Name
		{
			get { return _name ?? string.Format("!Unknown 0x{0:X2}!", Type); }
			set { _name = value; }
		}

		[Category("Internal")]
		public uint Type { get { return (uint)Data[0] >> 2; } }

		private uint _length;

		[Category("Internal")]
		public uint Length
		{
			get { return _length == 0 ? 4 : _length; }
			set { _length = value; }
		}

		protected virtual string[] DisplayParams
		{
			get { return null; }
		}

		[Category("Internal")]
		public string HexString
		{
			get
			{
				var sb = new StringBuilder();
				for (var i = 0; i < Length; i++)
				{
					sb.AppendFormat("{0:X2} ", Data[i]);
				}

				return sb.ToString();
			}
		}

		protected byte* Data;
	}
}