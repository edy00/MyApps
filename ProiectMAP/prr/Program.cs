using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prr
{
    [Serializable()]
    public class Client
    {
        public Client() { }

        public Client(String name)
        {
            Name = name;
        }

        public String Name { get; set; }


        public Order Order { get; set; }
    }

    [Serializable()]
    public class Prod : IDObject
    {

        public Prod(int id, String name)
            : base(id)
        {
            Name = name;
        }

        public String Name { get; set; }

        public override String ToString()
        {
            return "Name: " + Name;
        }
    }
    
    
    [Serializable()]
    public class Order : IDObject
    {
        //public Client client;

       /* public Order()
            : base(100)
        {
        }*/

        public Order(int id, int room, String name)
            : base(id)
        {
            Name = name;
            Room = room;
        }


        /*public Order(int id, int room, String name, Client c)
            : base(id)
        {
            Name = name;
            Room = room;
            this.client = c;
        }*/

        public String Name { get; set; }

        public int Room { get; set; }

        /*public Client getClient()
        {
            return this.client;
        }*/

        public override String ToString()
        {
            return ID + " - Room:  " + Room + " - Product: " + Name;
        }
    }
    
    
    
    
    
    class Program
    {
        static String OrderToString1(Order o)
        {
            return o.ID + " - " + o.Room + " - " + o.Name;
        }

        static String ProdToString(Prod p)
        {
            return p.Name;
        }

        static String ProdToString2(Prod p)
        {
            return "Name: " + p.Name;
        }

        static String OrderToString2(Order o)
        {
            return "ID=" + o.ID + " Room=" + o.Room + " Product=" + o.Name;
        }

        static Order StringToOrder(String s)
        {
            String[] tokens = s.Split(new String[] { " - " }, 3, StringSplitOptions.RemoveEmptyEntries);
            return new Order(Int32.Parse(tokens[0]), Int32.Parse(tokens[1]), tokens[2]);
        }

        static void Main(string[] args)
        {
        }
    }
}
