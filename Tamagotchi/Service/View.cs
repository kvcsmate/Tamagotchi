using System;
using System.Collections.Generic;
using System.Text;

namespace Tamagotchi.Service
{
    
    public class View
    {

        int view_length=20;
        int type = 0;
        List<string> view = new List<string>();
        public View()
        {
          
            for (int i = 0; i < view_length; ++i)
            {
                view.Add("");
            }
            
            


        }
        public void Create_Menu(List<string> menuitems)
        {
            string options = "";
            for (int i=0;i<menuitems.Count;++i)
            {
                options+= $"|{i}-{menuitems[i]}";
            }
            view.Add(options);
        }
        public void msg(string sender, string msg)
        {
            Console.Clear();
            for(int i=0;i<view_length-1;i++)
            {
                view[i] = view[i + 1];
                
            }
            view[view_length - 1] = $"{sender}:{msg}";
            Refresh();

        }
        public void Refresh()
        {
            Console.Clear();
            for(int i=0;i<view_length+1;i++)
            {
                Console.WriteLine(view[i]);
            }
        }
        public int input(int min, int max)
        {
            try
            {
                string strchoice = Console.ReadKey().KeyChar.ToString();
                int choice = int.Parse(strchoice);

                if (choice > max || choice < min)
                {
                    throw new Exception();
                }
                return choice;
            }
            catch
            {
                return (-1);

            }

        }
    }
}
