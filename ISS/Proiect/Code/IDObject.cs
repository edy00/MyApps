using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    /*
     * (this class is used with the memory storage)
     * used for identifying the plays
     * */
    [Serializable()]
    public class IDObject
    {
        private int id = 0;

        public IDObject(int id)
        {
            this.id = id;
        }

        public int ID { get { return this.id; } }
    }
}
