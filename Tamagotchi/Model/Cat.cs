using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tamagotchi.Service;
using System.Linq;
namespace Tamagotchi.Model

{
    class Cat : Pet
    {
        public Cat(string name,View view): base(name,view)
        {
        }
        public  void Clean_litterbox()
        {
            Thread.Sleep(1000);
            Health += 10;
            _view.msg(Name, "Miau.Tiszta alom.Meg vagyok elégedve.");
        }
         public override  void Init()
        {
            methods.Remove(methods.First(m => m.Item1=="Simogatás"));
            methods.Add(new Tuple<string, Action>("Simogatás", () => Caress()));
            methods.Add(new Tuple<string, Action>("Új alom", () => Clean_litterbox()));
            Start();
        }
        new public void Caress()
        {
            Thread.Sleep(1000);
            Random coinflip = new Random();
            if(coinflip.Next(2)==1)
            {
                Health += 10;
                _view.msg(Name, "Meg lettem simogatva. Élveztem.");
            }
            else
            {
                _view.msg(Name, $"{Name} megmart és elfutott!");
            }
            
           
        }
    }
}
