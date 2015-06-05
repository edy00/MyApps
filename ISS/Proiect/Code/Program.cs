using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    /*
     * in memory classes of the objects
     * */
    [Serializable()]
    public class Play : IDObject
    {
        public Play(int id, String nameP, String date, int locuri, int oc)
            : base(id)
        {
            Name = nameP;
            Date = date;
            L = locuri;
            Ocpd = oc;
        }

        public String Name { get; set; }

        public String Date { get; set; }
        public int L { get; set; }

        public int Ocpd { get; set; }

        public override string ToString()
        {
            return "Name: " + Name + " -Date: " + Date + " -Places: " + Ocpd+"/"+L;
        }
    }

    [Serializable()]
    public class Res : IDObject
    {
        public Res(int id, String name, String nameP, int places)
            : base(id)
        {
            Name = name;
            PlayN = nameP;
            Places = places;
        }

        public String Name { get; set; }
        public String PlayN { get; set; }
        public int Places { get; set; }

        public override string ToString()
        {
            return "Name: " + Name + " -Play: " + PlayN + " -Place:" + Places.ToString();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}

