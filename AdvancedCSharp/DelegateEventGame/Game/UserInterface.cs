using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventGame
{
	class UserInterface
	{
		public void OnCharacterIsDead (object source, CharacterEventArgs e)
		{
			TextTool.PrintText ($"Player {e.Info.Name} is dead!", ConsoleColor.Cyan);
			TextTool.PrintText ($"Character Stats: \nKills: {e.Info.Kills} \nDeath: {e.Info.Death} \nFlagCaptured {e.Info.FlagCaptured}", ConsoleColor.Cyan);
		}
	}
}
