namespace MeleeLib
{
	public struct Attribute
	{
		public string Name
		{
			get {
				return Offset switch {
					0x000 => "Walk Initial Velocity",
					0x004 => "Walk Acceleration?",
					0x008 => "Walk Maximum Velocity",
					0x00C => "Walk Animation Speed",
					0x014 => "Same as 0xC?",
					0x018 => "Friction",
					0x01C => "Dash Initial Velocity",
					0x020 => "StopTurn Initial Velocity",
					0x028 => "Run Initial Velocity?",
					0x030 => "Run Acceleration",
					0x038 => "Jump Startup Lag (Frames)",
					0x03C => "same as 0x034?",
					0x040 => "Jump V Initial Velocity???",
					0x044 => "same as 0x03C",
					0x048 => "Jump H Initial Velocity???",
					0x04C => "Hop V Initial Velocity???",
					0x050 => "Air Jump Multiplier",
					0x054 => "Same as 0x04C",
					0x058 => "Number of Jumps",
					0x05C => "Gravity",
					0x060 => "Terminal Velocity",
					0x064 => "Aerial Mobility",
					0x068 => "Aerial Stopping Mobility",
					0x06C => "Max Aerial H Velocity",
					0x070 => "Fast Fall Gravity?",
					0x074 => "Fast Fall Terminal Velocity",
					0x078 => "0024?",
					0x088 => "Weight",
					0x08C => "Model Scaling",
					0x090 => "Shield Size",
					0x094 => "Shield Break Initial Velocity",
					0x0A8 => "Ledgejump Horizontal Velocity",
					0x0AC => "Ledgejump Vertical Velocity",
					0x0E4 => "Normal Landing Lag",
					0x0E8 => "N-Air Landing Lag",
					0x0EC => "F-Air Landing Lag",
					0x0F0 => "B-Air Landing Lag",
					0x0F4 => "U-Air Landing Lag",
					0x0F8 => "D-Air Landing Lag",
					0x104 => "Walljump H Velocity?",
					0x108 => "Walljump V Velocity?",
					0x160 => "Ice Traction?",
					0x17C => "Special Jump Action = -1...?",
					_ => string.Empty
				};
			}
		}

		public int Offset { get; set; }

		public object Value { get; set; }
	}
}
