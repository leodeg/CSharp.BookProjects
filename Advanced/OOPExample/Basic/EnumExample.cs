using System;

namespace Advanced
{
    internal static class EnumExample
    {
        private enum EnumType : byte
        {
            Manager = 10,
            Grunt = 1,
            Contractor = 100,
            VicePresident = 9
        }

        //ERROR: byte cannot handle value more than 255
        private enum EnumErrorTypeValue : byte
        {
            Manager = 10,
            Grunt = 1,
            Contractor = 100,
            //VicePresident = 999 // ERROR
        }

        private enum EnumBeginDefault
        {
            Manager,        //0
            Grunt,          //1
            Contractor,     //2
            VicePresident   //3
        }

        private enum EnumBeginDefaultValue
        {
            Manager = 2,
            Grunt,          //3
            Contractor,     //4
            VicePresident   //5
        }

        public enum Character
        {
            Ninja,
            Mario,
            BestBoy,
            ShadowRuner
        }

        public static void AskForBonus(Character character)
        {
            switch (character)
            {
                case Character.Ninja:
                    Console.WriteLine("I'm a shadow");
                    break;

                case Character.Mario:
                    Console.WriteLine("Í best classical hero");
                    break;

                case Character.BestBoy:
                    Console.WriteLine("I'm best");
                    break;

                case Character.ShadowRuner:
                    Console.WriteLine("I'm live in shadows");
                    break;

                default:
                    Console.WriteLine("It's a not a hero.");
                    break;
            }
        }

        public static void AskForBonusTest()
        {
            AskForBonus(Character.ShadowRuner);
        }
    }
}