using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp
{
	static class Program
	{
		static void Main (string[] args)
		{
			CounterTest ();
		}

		static void CounterTest ()
		{
			Counter counter = new Counter ();           // Create a reference of the class
			Handle_I handler_one = new Handle_I ();     // Create a subscribers
			Handle_II handler_two = new Handle_II ();   // Create a subscribers

			counter.onCount += handler_one.Message;     // Add the subscribers on event
			counter.onCount += handler_two.Message;     // Add the subscribers on event

			counter.Count ();                           // Start count method
		}

		static void PlayerTest ()
		{
			Player player = new Player ("Player_one", 100);

			Enemy enemy_one = new Enemy ("Enemy_one", 50);
			Enemy enemy_two = new Enemy ("Enemy_two", 50);

			player.onAlive += enemy_one.StartAttack;
			player.onAlive += enemy_two.StartAttack;

			player.onDead += enemy_one.StopAttack;
			player.onDead += enemy_two.StopAttack;

			player.onDead += enemy_one.Win;
			player.onDead += enemy_two.Win;

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine ("Start GameSession\n");
			Console.ForegroundColor = ConsoleColor.White;

			player.SetDamage (50);

			Console.WriteLine ();
			player.SetDamage (25);

			Console.WriteLine ();
			player.SetDamage (25);
		}

		static void MoreDelegateExampleTest ()
		{
			MoreDelegateExample example = new MoreDelegateExample ();
			example.VoidExampleDelegateTest ();
		}

		static void DisplayPlayerNamesTest ()
		{
			PlayerStats[] stats =
			{
				new PlayerStats { name = "Name1", kills = 15, deaths = 10, flagCaptured = 5 },
				new PlayerStats { name = "Name2", kills = 5,  deaths = 15, flagCaptured = 0 },
				new PlayerStats { name = "Name3", kills = 15, deaths = 8,  flagCaptured = 7 },
				new PlayerStats { name = "Name4", kills = 7,  deaths = 5,  flagCaptured = 3 },
				new PlayerStats { name = "Name5", kills = 8,  deaths = 2,  flagCaptured = 6 },
			};

			DisplayPlayerNames names = new DisplayPlayerNames ();
			names.OnGameOver (stats);
		}

		public static void CharacterTest ()
		{
			// Create character
			Character character = new Character ();

			// Add subscriber
			Achievements achievements = new Achievements (character);
			UserInterface userInterface = new UserInterface (character);

			Console.WriteLine ("[Example 1]");
			character.Die ();
			Console.WriteLine ("\n[Example 2]");
			character.Die ();
		}
	}

	#region Simple Game Events

	class Player
	{
		public string Name { get; private set; }
		public int HitPoints { get; private set; }

		public delegate void State ();
		public event State onAlive;
		public event State onDead;

		public Player (string name, int hitPoints)
		{
			Name = name;
			HitPoints = hitPoints;
		}

		public void SetDamage (int damage)
		{
			if (damage <= HitPoints)
			{
				HitPoints -= damage;
			}

			if (HitPoints > 0)
			{
				Console.WriteLine ($"{Name} has a {HitPoints} hit points.");
				Alive ();
			}
			else
			{
				Dead ();
			}
		}

		private void Alive ()
		{
			Console.WriteLine ("Player is alive");
			onAlive?.Invoke ();
		}

		private void Dead ()
		{
			Console.WriteLine ("Player is dead");
			onDead?.Invoke ();
		}
	}

	class Enemy
	{
		public string Name { get; private set; }
		public int Damage { get; private set; }


		public Enemy (string name, int damage)
		{
			Name = name;
			Damage = damage;
		}


		public void StartAttack ()
		{
			Console.WriteLine ($"{Name} attack the player.");
		}

		public void StopAttack ()
		{
			Console.WriteLine ($"{Name} stop attack the player.");
		}

		public void Win ()
		{
			Console.WriteLine ($"{Name}: Yes! Player is dead!");
		}
	}

	#endregion

	#region Event Example

	public class Counter
	{
		public delegate void CountHandler ();
		public event Action onCount;

		public void Count ()
		{
			for (int i = 0; i < 100; i++)
			{
				if (i == 71)
				{
					onCount?.Invoke ();
				}
			}
		}
	}

	public class Handle_I
	{
		public void Message ()
		{
			Console.WriteLine ("Let's go!! 71!");
		}
	}

	public class Handle_II
	{
		public void Message ()
		{
			Console.WriteLine ("You are right!! 71!");
		}
	}

	#endregion

	#region Delegate Example

	class DelegateCalculator
	{
		// Create delegate
		//private delegate double OperationDelegate (double x, double y);

		// Use Func<TValue, TResult> delegate
		private Dictionary<string, Func<double, double, double>> _operations;

		public DelegateCalculator ()
		{
			_operations = new Dictionary<string, Func<double, double, double>>
			{
				{"+", (x, y) => x + y }, // You can use lambda
				{"-", delegate(double x, double y) { return x - y; } }, // You can use delegate
				{"*", DoMultiplication }, // You can use method
				{"/", DoDivision },
				{"%", DoMod }
			};
		}

		// You can also use the delegate as a method parameter too
		//private void DelExample (OperationDelegate del)
		//{

		//}

		// You can get an operation
		public double PerformOperation (string operations, double x, double y)
		{
			if (!_operations.ContainsKey (operations))
			{
				throw new ArgumentException ($"Operation <{operations}> is invalid");
			}

			return _operations[operations] (x, y);
		}

		// You easily can add a new operation to the dictionary
		public void DefineOperation (string operation, Func<double, double, double> body)
		{
			if (_operations.ContainsKey (operation))
			{
				throw new ArgumentException ($"Operation <{operation}> already exists");
			}

			_operations.Add (operation, body);
		}

		private double DoAddition (double x, double y) => x + y;
		private double DoSubstraction (double x, double y) => x - y;
		private double DoMultiplication (double x, double y) => x * y;
		private double DoDivision (double x, double y) => x / y;
		private double DoMod (double x, double y) => x % y;
	}

	class MoreDelegateExample
	{
		public delegate void VoidExampleDelegate (int x);

		public void VoidExampleDelegateTest ()
		{
			VoidExampleDelegate exampleDelegate = VoidExampleOne;
			Console.WriteLine ("[Example 1]");
			exampleDelegate?.Invoke (10);

			Console.WriteLine ("[Example 2]");
			exampleDelegate = VoidExampleTwo;
			exampleDelegate?.Invoke (20);

			Console.WriteLine ("[Destroy instances]");
			exampleDelegate = null;
			//exampleDelegate (30); // Error
			exampleDelegate?.Invoke (30);

			Console.WriteLine ("[Example 3]");
			exampleDelegate = VoidExampleTwo;
			exampleDelegate += VoidExampleOne;
			exampleDelegate += VoidExampleTwo;
			exampleDelegate += VoidExampleOne;
			exampleDelegate?.Invoke (30);

			Console.WriteLine ("[Example 4]");
			exampleDelegate -= VoidExampleOne;
			exampleDelegate?.Invoke (40);
		}

		public void VoidExampleOne (int x)
		{
			Console.WriteLine ("Void Example One {0}", x);
		}

		public void VoidExampleTwo (int x)
		{
			Console.WriteLine ("Void Example Two {0}", x);
		}
	}

	#endregion

	#region Delegate Example Two

	class PlayerStats
	{
		public string name = "Default";
		public int kills;
		public int deaths;
		public int flagCaptured;
	}


	class DisplayPlayerNames
	{
		public delegate int ScoreDelegate (PlayerStats stats);

		public void OnGameOver (PlayerStats[] playerStats)
		{
			//string topKills = GetPlayerNameTopScore (playerStats, ScoreByKillCount);
			//string topDeaths = GetPlayerNameTopScore (playerStats, ScoreByDeathCount);
			//string topFlagCaptured = GetPlayerNameTopScore (playerStats, ScoreByFlagCapturedCount);

			string topKills = GetPlayerNameTopScore (playerStats, calculate => calculate.kills);
			string topDeaths = GetPlayerNameTopScore (playerStats, calculate => calculate.deaths);
			string topFlagCaptured = GetPlayerNameTopScore (playerStats, calculate => calculate.flagCaptured);

			Console.WriteLine ("Top kills: {0}", topKills);
			Console.WriteLine ("Top deaths: {0}", topDeaths);
			Console.WriteLine ("Top flagCaptured: {0}", topFlagCaptured);
		}

		int ScoreByKillCount (PlayerStats stats) => stats.kills;
		int ScoreByDeathCount (PlayerStats stats) => stats.deaths;
		int ScoreByFlagCapturedCount (PlayerStats stats) => stats.deaths;

		public string GetPlayerNameTopScore (PlayerStats[] playerStats, ScoreDelegate calculate)
		{
			string name = string.Empty;
			int bestScore = 0;

			foreach (PlayerStats stats in playerStats)
			{
				int score = calculate (stats);
				if (score > bestScore)
				{
					bestScore = score;
					name = stats.name;
				}
			}

			return name;
		}
	}

	#endregion

	#region Event Example Two

	public class Character
	{
		//public delegate void DeathDelegate ();
		public event Action deathEvent;

		public void Die ()
		{
			deathEvent?.Invoke ();
		}
	}

	public class Achievements
	{
		private Character character;

		public Achievements (Character character)
		{
			this.character = character;
			this.character.deathEvent += OnPlayerDeath;
		}

		public void OnPlayerDeath ()
		{
			Console.WriteLine ("Achievements:: player is dead");
			Console.WriteLine ("Achievements:: end");
			character.deathEvent -= OnPlayerDeath;
		}
	}

	public class UserInterface
	{
		private Character character;

		public UserInterface (Character character)
		{
			this.character = character;
			this.character.deathEvent += OnPlayerDeath;
		}

		public void OnPlayerDeath ()
		{
			Console.WriteLine ("UserInterface:: player is dead");
			Console.WriteLine ("UserInterface:: end");
			character.deathEvent -= OnPlayerDeath;
		}
	}

	#endregion
}
