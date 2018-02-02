using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Duck
    {

        public string Name { get; set; }
        public Duck(string name)
        {
            Name = name;
        }
        public virtual void fly()
        {
            Console.WriteLine($"{Name}");
        }

    }
    public class WildDuck : Duck
    {
        public WildDuck(string name) : base(name)
        {

        }
        public override void fly()
        {
            Console.WriteLine(string.Format("I can fly {0}", "{Name}"));
        }

    }
    public class HomeDuck : Duck
    {
        public HomeDuck(string name) : base(name)
        {

        }
        public override void fly()
        {
            Console.WriteLine(string.Format("I can't fly {0}", "{Name}"));
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            WildDuck wd = new WildDuck("WD");
            HomeDuck hd = new HomeDuck("HD");
            DuckFly(wd);
            DuckFly(hd);
            Duck[] duck = new Duck[2] {new WildDuck(""),new HomeDuck("") };
        }
        public static void DuckFly(Duck duck)
        {
            duck.fly();
        }
        public static void DuckFly(Duck [] duck)
        {
            for (int i = 0; i<duck.Length-1;i++)
            {
                duck[i].fly();
             }
        }
    }
    
}
