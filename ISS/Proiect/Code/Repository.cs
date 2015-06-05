using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Code
{


    public delegate String StringEncoder<T>(T o) where T : IDObject;
    public interface Repository<T> : IObservable<T> where T : IDObject
    {

        void AddObject(T o);
        bool Remove(int id);
        T Find(int id);
        T[] GetAll();

        T[] GetAll2();
        String ToString(StringEncoder<T> sr);
        void Close();

    }

    public class MemoryRepository<T> : Repository<T> where T : IDObject
    {
        protected List<T> list;
        protected List<T> list2;
        protected List<Res> Rlist;

        private List<IObserver<T>> observers = new List<IObserver<T>>();
        private List<IObserver<Res>> obsRes = new List<IObserver<Res>>();

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<T>> _observers;
            private IObserver<T> _observer;

            public Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        private class UnsubscriberRes : IDisposable
        {
            private List<IObserver<Res>> _obsRes;
            private IObserver<Res> _obRes;

            public UnsubscriberRes(List<IObserver<Res>> obsRes, IObserver<Res> obRes)
            {
                this._obsRes = obsRes;
                this._obRes = obRes;
            }
            public void Dispose()
            {
                if (_obRes != null && _obsRes.Contains(_obRes))
                    _obsRes.Remove(_obRes);
            }
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private void Notify(T next)
        {
            foreach (IObserver<T> obs in this.observers)
            {
                obs.OnNext(next);
            }

        }

        public MemoryRepository()
        {
            list = new List<T>();
        }

        public void AddObject(T o)
        {
            list.Add(o);
            this.Notify(o);
        }

        public bool Remove(int id)
        {

            foreach (T o in list)
            {
                if (o.ID == id)
                {
                    list.Remove(o);
                    this.Notify(o);
                    return true;
                }
            }
            return false;
        }
        public T Find(int id)
        {
            foreach (T o in list)
            {
                if (o.ID == id)
                {
                    return o;
                }
            }
            return null;
        }

        public T[] GetAll()
        {
            return list.ToArray();
        }

        public T[] GetAll2()
        {
            return list2.ToArray();
        }

        public String ToString(StringEncoder<T> sr)
        {
            StringBuilder sb = new StringBuilder("Memory Repo\n");
            foreach (T o in list)
            {
                sb.Append(sr(o) + "\n");
            }
            return sb.ToString();
        }

        public virtual void Close() { }
    }

    public class BinaryRepository<T> : MemoryRepository<T> where T : IDObject
    {
        private String fileName;
        public BinaryRepository(String fileName)
        {
            this.fileName = fileName;
            deserialize();
            
        }

        public override void Close()
        {
            serialize();

        }

        private void serialize()
        {
            Stream stream = File.Open(fileName, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, list);
            stream.Close();

        }

        private void deserialize()
        {
            
            Stream stream = File.Open(fileName, FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                this.list = (List<T>)formatter.Deserialize(stream);
            }
            catch (Exception)
            {
            }
            stream.Close();
        }
    }
}
