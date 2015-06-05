using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace prr
{
   
        public delegate String StringEncoder<T>(T o) where T : IDObject;

        public interface Repository<T> : IObservable<T> where T : IDObject
        {
            void AddObject(T o);
            bool Remove(int id);
            T Find(int id);
            T[] GetAll();
            String ToString(StringEncoder<T> sr);
            void Close();

        }

        /// <summary>
        /// This class provides an in-memory repository for IDObject instances
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// 

        public class MemoryRepository<T> : Repository<T> where T : IDObject 
        {
            protected List<T> data;
            protected List<Prod> dataAd;
            protected List<T> eff;

            private List<IObserver<T>> observers = new List<IObserver<T>>();
            private List<IObserver<Prod>> obsProd = new List<IObserver<Prod>>();

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

            private class UnsubscriberProd : IDisposable
            {
                private List<IObserver<Prod>> _obsProd;
                private IObserver<Prod> _obProd;

                public UnsubscriberProd(List<IObserver<Prod>> obsProd, IObserver<Prod> obProd)
                {
                    this._obsProd = obsProd;
                    this._obProd = obProd;
                }
                public void Dispose()
                {
                    if (_obProd != null && _obsProd.Contains(_obProd))
                        _obsProd.Remove(_obProd);
                }
            }

            public MemoryRepository()
            {
                data = new List<T>();
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

            public void AddObject(T o)
            {
                data.Add(o);
                this.Notify(o);
            }

            public bool Remove(int id)
            {

                foreach (T o in data)
                {
                    if (o.ID == id)
                    {
                        data.Remove(o);
                        this.Notify(o);
                        return true;
                    }
                }
                return false;
            }
            public T Find(int id)
            {
                foreach (T o in data)
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
                return data.ToArray();
            }

            public String ToString(StringEncoder<T> sr)
            {
                StringBuilder sb = new StringBuilder("Memory Repo\n");
                foreach (T o in data)
                {
                    sb.Append(sr(o) + "\n");
                }
                return sb.ToString();
            }

            public virtual void Close() { }
        }

        public delegate T StringDecoder<T>(String s) where T : IDObject;

        /// <summary>
        /// Text File representation of repository
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class TextFileRepository<T> : MemoryRepository<T> where T : IDObject
        {
            private StringEncoder<T> encoder;

            private StringDecoder<T> decoder;

            private String fileName;

            public TextFileRepository(String fileName, StringEncoder<T> encoder, StringDecoder<T> decoder)
            {
                this.fileName = fileName;
                this.encoder = encoder;
                this.decoder = decoder;
                readTextFile();
            }

            public new void Close()
            {
                writeTextFile();
            }

            private void readTextFile()
            {
                string[] lines = System.IO.File.ReadAllLines(fileName);
                foreach (String line in lines)
                {
                    AddObject(decoder(line));
                }
            }

            private void writeTextFile()
            {
                StringBuilder lines = new StringBuilder();

                foreach (T o in GetAll())
                {
                    lines.Append(encoder(o) + "\n");
                }
                System.IO.File.WriteAllText(fileName, lines.ToString());
            }
        }

        /// <summary>
        /// This repository works with binary serialization
        /// </summary>
        /// <typeparam name="T"></typeparam>
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

                formatter.Serialize(stream, data);
                stream.Close();
                
            }

            private void deserialize()
            {
                Stream stream = File.Open(fileName, FileMode.OpenOrCreate);
                BinaryFormatter formatter = new BinaryFormatter();

                try
                {
                    this.data = (List<T>)formatter.Deserialize(stream);
                }
                catch (Exception)
                {
                }
                stream.Close();
            }
        }

        public class XMLRepository<T> : MemoryRepository<T> where T : IDObject
        {
            private String fileName;

            public XMLRepository(String fileName)
            {
                this.fileName = fileName;
                unmarshall();
            }

            public override void Close()
            {
                marshall();
            }

            private void marshall()
            {
                XmlSerializer ser = new XmlSerializer(this.data.GetType());
                TextWriter writer = new StreamWriter(fileName);
                ser.Serialize(writer, this.data);
                writer.Close();
            }

            private void unmarshall()
            {
                XmlSerializer ser = new XmlSerializer(this.data.GetType());
                TextReader reader = new StreamReader(fileName);
                this.data = (List<T>)ser.Deserialize(reader);
                reader.Close();
            }
        }

    
}
