using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tamagotchi.Model;

namespace Tamagotchi.Service
{
    public class TamagotchiService
    {
        public void Initialize()
        {

            View view = new View();
            Console.WriteLine("Válassz állatot");
            Console.WriteLine("1-Cica");
            Console.WriteLine("2-Kutya");
            Console.WriteLine("3-Hörcsög");


            int animal = view.input(1, 3);
            if (animal == -1)
            {
                Console.WriteLine("hibás bemenet!");
                Initialize();
            }
            Console.Clear();
            Console.Write("Mi az állatod neve:");
            string petname = Console.ReadLine();
            switch (animal)
            {
                case 1:Cat cat = new Cat(petname,view);cat.Init();break;
                case 2: Dog dog = new Dog(petname, view); dog.Init(); break;
                case 3: Hamster hamster = new Hamster(petname, view); hamster.Init(); break;
            }



        }
       
    }
}
