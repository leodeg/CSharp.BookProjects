using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventGame
{
	class GameSession
	{
		private Character character;
		private UserInterface userInterface;

		public void StartGameSession ()
		{
			InitGameSession ();
			SetupEvents ();
			StartGame ();
		}

		private void InitGameSession ()
		{
			character = new Character ("Bob");
			userInterface = new UserInterface ();
		}

		private void SetupEvents ()
		{
			character.IsDead += userInterface.OnCharacterIsDead;
		}

		private void StartGame ()
		{
			character.IncrementKills ();
			character.IncrementKills ();
			character.IncrementKills ();

			character.IncrementDeath ();
			character.IncrementDeath ();
			character.IncrementDeath ();

			character.IncrementFlagCaptured ();

			character.OnDead ();
		}
	}
}
