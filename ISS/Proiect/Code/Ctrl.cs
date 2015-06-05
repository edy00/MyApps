using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    public class Controller
    {
        private Repository<Play> repPlay = new BinaryRepository<Play>(@"C:\Users\Edi\Documents\Visual Studio 2013\Projects\ISS\Proiect\plays.txt");
        private Repository<Res> repRes = new BinaryRepository<Res>(@"C:\Users\Edi\Documents\Visual Studio 2013\Projects\ISS\Proiect\ress.txt");

        public Controller()
        {

        }

        public void AddRes(Res r)
        {
            this.repRes.AddObject(r);
        }

        public bool RemoveRes(int id)
        {
            return this.repRes.Remove(id);
        }

        public Res FindRes(int id)
        {
            return this.repRes.Find(id);
        }

        public Res[] GetAllRes()
        {
            return this.repRes.GetAll();
        }

        public void AddPlay(Play p)
        {
            this.repPlay.AddObject(p);
        }

        public bool RemovePlay(int id)
        {
            return this.repPlay.Remove(id);

        }

        public Play FindPlay(int id)
        {
            return this.repPlay.Find(id);
        }
        public Play[] GetAllPlay()
        {
            return this.repPlay.GetAll();
        }

        public IDisposable SubscribeRes(IObserver<Res> observer)
        {
            return this.repRes.Subscribe(observer);
        }

        public IDisposable SubscribePlay(IObserver<Play> observer)
        {
            return this.repPlay.Subscribe(observer);
        }

        public void Close()
        {
            this.repRes.Close();
            this.repPlay.Close();
        }
    }
}
