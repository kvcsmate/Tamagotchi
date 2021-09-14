using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tamagotchi.Service;

namespace Tamagotchi.Model
{
    public class Dog : Pet
    {
        public Dog(string name,View view) : base( name, view)
        {
        }
        new public void Init()
        {
            methods.Add(new Tuple<string, Action>("Sétáltatás", () => Take_For_Walk()));
            methods.Add(new Tuple<string, Action>("Játék", () => Fetch()));
            Start();

        }
        public void Take_For_Walk()
        {
            _view.msg(Name, "Megyünk sétálni! Életem legjobb napja! ");
            Thread.Sleep(10000);
            Health += 30;
            _view.msg(Name, "Meg lettem sétáltatva!");
        }
        public void Fetch()
        {
            _view.msg(Name, "Futok a botért!");
            Thread.Sleep(1000);
            Health += 10;
            _view.msg(Name, "Visszahoztam a botot! Boldog vagyok!");
        }
    }
}
