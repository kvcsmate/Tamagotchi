using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tamagotchi.Service;
using System.Linq;

namespace Tamagotchi.Persistence
{
    public class Pet
    {
        public List<Tuple<string, Action>> methods = new List<Tuple<string, Action>>();
        Object[] mylocks = new Object[5];
        public View _view;
        private bool isalive;
        public bool Isalive
        {
            get
            {
                lock(mylocks[0])
                {
                    return isalive;
                }
            }
            set
            {
                lock(mylocks[0])
                {
                    isalive = value;
                }
            }
        }
        private string name;
        public string Name
        {
            get
            {
                lock (mylocks[2])
                {
                    return name;
                }
            }
            set
            {
                lock (mylocks[2])
                {
                    name = value;
                }
            }

        }
        private int health;
        public int Health
        {
            get
            {
                lock (mylocks[3])
                {
                    return health;
                }
            }
            set
            {
                lock(mylocks[3])
                {
                    health = Math.Min(value, 100);
                }
            }
        
        }
        private int hunger;
        public int Hunger
        {
            get
            {
                lock (mylocks[4])
                {
                    return hunger;
                }
            }
            set
            {
                lock (mylocks[4])
                {
                    hunger = Math.Max(value, 0);
                }
            }

        }
        public  Pet(string name,View view)
        {
            for (int i = 0; i < mylocks.Length; i++)
            {
                mylocks[i] = new Object();
            }
            Name = name;
            _view = view;
            Hunger = 100;
            Health = 100;
            Isalive = true;
            //methods.Add(new Tuple<string, Action>("Élet", () => Live()));
            methods.Add(new Tuple<string,Action>("Élet és jóllakottság", () => Check_On()));
            methods.Add(new Tuple<string, Action>("Etetés", () => Feed()));
            methods.Add(new Tuple<string, Action>("Simogatás", () => Caress()));

        }
        public void Check_On()
        {
            _view.msg(Name, $"Élet: {Health}, Jóllakottság:{Hunger}");
        }
        public void Live()
        {
            int tick_counter = 0;
            _view.msg(Name, "Üdvözöllek,gazdi");
            while(Health>0)
            {
                tick_counter++;
                Thread.Sleep(500);
                Hunger--;
                if(Hunger<50)
                {
                    
                    Health--;
                    if(Hunger%10==0)
                    {
                        _view.msg(Name, "Éhes vagyok, etess meg!");
                    }
                }
                if(tick_counter==5)
                {
                    Health--;
                    tick_counter = 0;
                }
            }
            _view.msg(Name, $"{Name}   otthagyott, mert nem vigyáztál rá eléggé!");
            Isalive = false;

        }
        public void Feed()
        {
            Thread.Sleep(1000);
            
            Hunger += 30;
            Health = Math.Min(Health+10,100);
            string msg = "megettem az ételt";
            if (Hunger<=100)
            {
                _view.msg(Name, $"{msg}!");
            }
            else
            {
                Health = Health - (Hunger - 100);
                Hunger = 100;
                _view.msg(Name, $"{msg}, de túl sok volt és most fáj a hasam..");
            }
        }
        public void Caress()
        {
            Thread.Sleep(1000);
            Health += 10;
            _view.msg(Name,"meg lettem simogatva!");
        }
        public virtual void Init()
        {
            Start();
        }
        public void Start()
        {

            _view.Create_Menu(methods.Select(m => m.Item1).ToList());
            Task.Run(Live);
            while (Isalive)
            {
                int inputchoice = _view.input(0, methods.Count);
                if (inputchoice != -1)
                {
                    Task.Run(methods[inputchoice].Item2);
                    Thread.Sleep(100);
                }
                else
                {
                    _view.msg("Játék:", "Helytelen érték!");
                }

            }
        }
    }
}
