using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarLibrary
{
    public enum EngineState {  engineAlive, engineDead }

    public abstract class Car
    {
        public string Name { get; set; }
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }

        protected EngineState engineState = EngineState.engineAlive;
        public EngineState EngineState => engineState;
        public abstract void TurboBoost ();

        public Car () {}
        public Car (string name, int maxSpeed, int currentSpeed)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            CurrentSpeed = currentSpeed;
        }
    }

    public class SportsCar : Car
    {
        public SportsCar () { }
        public SportsCar (string name, int maxSpeed, int currentSpeed)
            : base(name, maxSpeed, currentSpeed) { }

        public override void TurboBoost ()
        {
            MessageBox.Show("Ramming speed!", "Faster is better...");
        }
    }

    public class MiniVan : Car
    {
        public MiniVan () { }
        public MiniVan (string name, int maxSpeed, int currentSpeed)
            : base(name, maxSpeed, currentSpeed) { }

        public override void TurboBoost ()
        {
            MessageBox.Show("Eek!", "Your Engine block exploded!");
        }
    }
}
