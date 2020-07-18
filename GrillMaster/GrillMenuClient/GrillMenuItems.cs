using Newtonsoft.Json;
using System.Collections.Generic;

namespace GrillMenu
{

    public class Menu
    {
        public string id { get; set; }
        
        public string Id { get; set; }
        public string menu { get; set; }
        public List<Item> items { get; set; }
    }

    public class Item
    {
        
        public string id { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public string Duration { get; set; }
        public int Quantity { get; set; }

    }

}






