using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tamagotchi.Service;

namespace Tamagotchi.Persistence
{
    class Hamster: Pet
    {
        public Hamster(string name, View view) : base(name, view)
        {
        }
        public override void Init()
        {
            methods.Add(new Tuple<string, Action>("Takarítás", () => Clean_Cage()));
            methods.Add(new Tuple<string, Action>("Hörcsögkerék", () => Wheel()));
            Start();

        }
        public void Clean_Cage()
        {
            _view.msg(Name, "Takarítják a ketrecem!");
            Thread.Sleep(5000);
            Health += 10;
            _view.msg(Name, "Tiszta a ketrec! Örülök!");
        }
        public void Wheel()
        {
            _view.msg(Name, "Beletettek a hörcsögkerékbe! Ideje kifutni magam");
            Thread.Sleep(2000);
            Health += 20;
            _view.msg(Name, "Kifutottam magam!");
        }
    }
}
