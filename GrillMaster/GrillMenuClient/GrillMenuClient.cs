using ConnectionManager;
using GrillClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace GrillMenu
{
    public class GrillMenuClient
    {
        private string apiUrl = "http://isol-grillassessment.azurewebsites.net/";
        private string grillMenu = "api/GrillMenu";
        public static int grillLength = 20;
        public static int grillWidth = 30;
        public void PrintMenu(Menu m)
        {
            foreach (var item in m.items)
            {
                Console.Write(item.Name + ": " + item.Quantity);
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        public List<Menu> GetAll()
        {
            try
            {
                //Get the menu from the Api
                ApiConnection con = new ApiConnection(apiUrl);
                HttpWebResponse result = con.Get(grillMenu);
                //Parse the response from Json to Items
                Stream newStream = result.GetResponseStream();
                StreamReader sr = new StreamReader(newStream);
                String response = sr.ReadToEnd();
                List<Menu> menus = JsonConvert.DeserializeObject<List<Menu>>(response);
                return menus;
            }
            catch (Exception e)
            {

                return null;
            }


        }

        public int CookMenu(Menu m)
        {

            List<Grill> grillList = new List<Grill>();
            List<Item> SortedList = m.items.OrderBy(o => (-o.Length * o.Width)).ToList();
            //We cook all the items
            while (SortedList.Count != 0)
            {
                //A new grill is needed
                Grill g = new Grill(grillWidth, grillLength);
                for (int i = 0; i < grillLength; i++)
                {
                    for (int j = 0; j < grillWidth; j++)
                    {
                        if (g.grill[j, i].Equals(g.empty))
                        {
                            bool put = PutItem(ref g, ref SortedList, i, j);
                        }
                    }
                }
                grillList.Add(g);
                g.PrintGrill(g);
                Console.Write(Environment.NewLine + Environment.NewLine);
                Console.Write(Environment.NewLine + Environment.NewLine);
                //Delay of 1 sec for being cooked
                System.Threading.Thread.Sleep(1000);
            };
            Console.Write(Environment.NewLine + Environment.NewLine);
            //Number of grills needed
            return grillList.Count;
        }

        private bool PutItem(ref Grill grill, ref List<Item> meat, int l0, int w0)
        {
            Grill aux = grill;
            foreach (Item i in meat)
            {
                //Try to put the mneal horizontally
                bool succeded = ToGrill(ref aux, i, l0, w0, true);
                //if is not posible try to put it vertically
                if (!succeded)
                {
                    succeded = ToGrill(ref aux, i, l0, w0, false);
                    if (!succeded)
                    {
                        continue;
                    }
                }
                //If the meal is put it into the grill deduct 1 to que quantity in to the menu
                grill = aux;
                i.Quantity--;
                if (i.Quantity == 0)
                {
                    meat.Remove(i);
                }
                return true;
            }
            return false;
        }

        private bool ToGrill(ref Grill aux, Item i, int l0, int w0, bool horizontal)
        {
            
            int xAxis;
            int yAxis;
            //Put the meal horizontally
            if (horizontal)
            {
                xAxis = i.Length;
                yAxis = i.Width;
            }
            //Put the meal vertically
            else
            {
                xAxis = i.Width;
                yAxis = i.Length;
            }
            //Put the value of the meal into the grill 
            for (int l = l0; l < l0 + yAxis; l++)
            {
                for (int w = w0; w < w0 + xAxis; w++)
                {
                    if (l0 + yAxis <= grillLength && w0 + xAxis <= grillWidth && aux.grill[w, l].Equals(aux.empty))
                    {
                        aux.grill[w, l] = i.Name.Substring(0, 2) + i.Quantity.ToString("D2");

                    }
                    else
                    {
                        //Is not posible to put this meal into the grill return
                        return false;
                    }
                }


            }
            return true;
        }


    }
}
