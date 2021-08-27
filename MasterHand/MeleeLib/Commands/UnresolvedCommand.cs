namespace MeleeLib.Commands
{
	public unsafe class UnsolvedCommand : ScriptCommand
	{
		public UnsolvedCommand(byte* ptr)
			: base(ptr) { }

		public UnsolvedCommand(byte* ptr, string name, uint length) : base(ptr, name, length) { }

		public UnsolvedCommand(byte* ptr, string name) : base(ptr, name) { }

		public UnsolvedCommand(byte* ptr, uint length) : base(ptr, length) { }

		protected override string[] DisplayParams
		{
			get { return null; }
		}
	}
}
