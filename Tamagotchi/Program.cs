using System;
using System.Threading;
using System.Threading.Tasks;
using Tamagotchi.Model;
using Tamagotchi.Service;

namespace Tamagotchi
{
    class Program
    {
        static  void Main(string[] args)
        {
            TamagotchiService service = new TamagotchiService();
            service.Initialize();
        }
       
    }
}
