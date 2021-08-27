namespace MeleeLib.Commands
{
	public unsafe abstract class CollisionCommand : ScriptCommand
	{
		protected CollisionCommand(byte* dataPointer) : base(dataPointer) { }
		protected CollisionCommand(byte* dataPointer, uint length) : base(dataPointer, length) { }
		protected CollisionCommand(byte* dataPointer, string name, uint length) : base(dataPointer, name, length) { }

	}
}
