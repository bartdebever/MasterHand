using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace MeleeLib
{
	public class DatFile
	{
		public string Filename { get; set; }

		public DatHeader Header { get; }

		public Dictionary<string, SectionHeader> Section1Entries { get; } = new Dictionary<string, SectionHeader>();

		public Dictionary<string, SectionHeader> Section2Entries { get; } = new Dictionary<string, SectionHeader>();

		public FTHeader FTHeader { get;}

		public List<Attribute> Attributes { get; } = new List<Attribute>();

		public List<Subaction> Subactions { get; } = new List<Subaction>();

		private static readonly int _headerLenght = 0x20;
		private readonly byte[] rawHeader = new byte[_headerLenght];
		private readonly byte[] rawdata;

		public unsafe DatFile(string filename)
		{
			Filename = filename;

			//Load up file
			var stream = File.OpenRead(filename);
			stream.Read(rawHeader, 0, _headerLenght);

			//Get the Header
			fixed (byte* ptr = rawHeader)
			{
				Header = *(DatHeader*)ptr;
			}

			//Allocate space for the rest of the file
			rawdata = new byte[Header.Filesize - _headerLenght];

			//Read rest of file
			stream.Read(rawdata, 0, rawdata.Count());

			//Compute offset base for the section name strings (They are near the end of the file)
			var stringoffsetbase = Header.Datasize + Header.OffsetCount * 4 + Header.SectionType1Count * 8 + Header.SectionType2Count * 8;

			//Read SectionType1s
			for (var i = 0; i < Header.SectionType1Count; i++)
			{
				fixed (byte* ptr = rawdata)
				{
					var section = *(SectionHeader*)(ptr + Header.Datasize + Header.OffsetCount * 4 + i * 8);
					var name = new string((sbyte*)ptr + stringoffsetbase + section.StringOffset);
					Section1Entries[name] = section;
				}
			}

			//Read SectionType2s
			for (var i = 0; i < Header.SectionType2Count; i++)
			{
				fixed (byte* ptr = rawdata)
				{
					var section = *(SectionHeader*)(ptr + Header.Datasize + Header.OffsetCount * 4 + Header.SectionType1Count * 8 + i * 8);
					var name = new string((sbyte*)ptr + stringoffsetbase + section.StringOffset);
					Section2Entries[name] = section;
				}
			}

			//FTHeader
			fixed (byte* ptr = rawdata)
			{
				int[] int_attributes = { 0x58, 0xa4, 0x98, 0x16c };
				FTHeader = *(FTHeader*)(ptr + Section1Entries.Values.First().DataOffset);
				var currentPointer = FTHeader.AttributesOffset + ptr;
				var endPointer = FTHeader.AttributesOffset2 + ptr;
				var iterator = 0;
				while (currentPointer < endPointer)
				{
					var attribute = new Attribute();
					if (!int_attributes.Contains(iterator))
					{
						attribute.Value = (float)*(bfloat*)currentPointer;
					}
					else
					{
						attribute.Value = (uint)*(buint*)currentPointer;
					}

					attribute.Offset = iterator;
					Attributes.Add(attribute);
					iterator += 4;
					currentPointer += 4;
				}
			}

			//Subactions
			fixed (byte* ptr = rawdata)
			{
				var currentPointer = FTHeader.SubactionStartOffset + ptr;
				var endPointer = FTHeader.SubactionEndOffset + ptr;
				var iterator = 0;
				while (currentPointer < endPointer)
				{
					var subaction = new Subaction {
						Header = *(SubactionHeader*)currentPointer
					};

					var actionName = new string((sbyte*)ptr + subaction.Header.StringOffset);

					if (actionName.Contains("ACTION_"))
					{
						actionName = actionName[(actionName.LastIndexOf("ACTION_") + 7)..].Replace("_figatree", "");
					}

					if (string.IsNullOrWhiteSpace(actionName))
					{
						actionName = "[No name]";
					}
					subaction.Name = actionName;
					subaction.Index = iterator;
					subaction.Commands = ReadScript(ptr + subaction.Header.ScriptOffset);
					Subactions.Add(subaction);
					iterator += 1;
					currentPointer += 4 * 6;
				}
			}

		}
		private unsafe static List<ScriptCommand> ReadScript(byte* ptr)
		{
			var list = new List<ScriptCommand>();
			var scriptCommand = ScriptCommand.Factory(ptr);
			while (scriptCommand.Type != 0)
			{
				list.Add(scriptCommand);
				ptr += scriptCommand.Length;
				scriptCommand = ScriptCommand.Factory(ptr);
			}

			return list;
		}
	}
}
