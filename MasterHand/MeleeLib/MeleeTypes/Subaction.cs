using System.Collections.Generic;

namespace MeleeLib.MeleeTypes
{
	public class Subaction
	{
		public int Index { get; set; }

		public SubactionHeader Header { get; set; }

		public List<ScriptCommand> Commands { get; set; }

		public string Name { get; set; }

	}
}
