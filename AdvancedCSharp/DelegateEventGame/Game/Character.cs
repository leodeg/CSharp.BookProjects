using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventGame
{
	struct CharacterInfo
	{
		public string Name { get; set; }
		public int Kills { get; set; }
		public int Death { get; set; }
		public int FlagCaptured { get; set; }
	}

	class CharacterEventArgs : EventArgs
	{
		public CharacterInfo Info { get; set; }
	}

	class Character
	{
		private CharacterInfo info;
		public event EventHandler<CharacterEventArgs> IsDead;

		public Character (string name)
		{
			info.Name = name;
			ClearStats ();
		}

		public void OnDead ()
		{
			TextTool.PrintText ($"Player {this.info.Name} is dead", ConsoleColor.Red);
			IsDead?.Invoke (this, new CharacterEventArgs () { Info = info });
		}

		#region Character stats controllers

		private void ClearStats ()
		{
			info.Kills = 0;
			info.Death = 0;
			info.FlagCaptured = 0;
		}

		public void IncrementKills ()
		{
			info.Kills++;
			TextTool.PrintText ("Update Kills", ConsoleColor.DarkYellow);
		}

		public void IncrementDeath ()
		{
			info.Death++;
			TextTool.PrintText ("Update Death", ConsoleColor.DarkYellow);
		}

		public void IncrementFlagCaptured ()
		{
			info.FlagCaptured++;
			TextTool.PrintText ("Update Flag Captured", ConsoleColor.DarkYellow);
		}

		#endregion
	}
}
