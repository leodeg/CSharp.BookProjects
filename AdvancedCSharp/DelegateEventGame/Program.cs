using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventGame
{
	class Program
	{
		static void Main (string[] args)
		{
			GameSession gameSession = new GameSession ();
			gameSession.StartGameSession ();
		}
	}
}
