using System;
using System.Threading;
using System.Threading.Tasks;
using Tamagotchi.Persistence;
using Tamagotchi.Service;

namespace Tamagotchi
{
    class Program
    {
        static  void Main(string[] args)
        {
            TamagotchiService service = new TamagotchiService();
            service.Initialize();
            /*Dog dog = new Dog("asd", service);
            Thread t1 = new Thread(new ThreadStart(dog.Caress));
            Thread t2 = new Thread(new ThreadStart(dog.Live));
            Thread t3 = new Thread(new ThreadStart(dog.Fetch));
            t1.Start();
            t2.Start();
            t3.Start();*/
            Console.ReadKey();

        }
       
    }
}
