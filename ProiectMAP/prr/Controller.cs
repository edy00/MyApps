using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prr
{
    public class Controller
    {
        private Repository<Order> repOrder = new BinaryRepository<Order>(@"D:\projectMap\orders.txt");
        private Repository<Prod> repProd = new BinaryRepository<Prod>(@"D:\projectMap\prod.txt");
        private Repository<Order> repEfOrder = new BinaryRepository<Order>(@"D:\projectMap\eff.txt");


        public Controller()
        {

        }

        public void AddProd(Prod p){
            this.repProd.AddObject(p);
        }

        public bool RemoveProd(int id)
        {
            return this.repProd.Remove(id);
        }

        public Prod FindProd(int id)
        {
            return this.repProd.Find(id);
        }

        public Prod[] GetAllProd()
        {
            return this.repProd.GetAll();
        }

        public void AddOrder(Order o)
        {
            this.repOrder.AddObject(o);
        }

        public bool RemoveOrder(int id)
        {
            return this.repOrder.Remove(id);
        }

        public Order FindOrder(int id)
        {
            return this.repOrder.Find(id);
        }

        public Order[] GetAllOrder()
        {
            return this.repOrder.GetAll();
        }

        public void AddEfOrder(Order o)
        {
            this.repEfOrder.AddObject(o);
        }

        public bool RemoveEfOrder(int id)
        {
            return this.repEfOrder.Remove(id);
        }

        public Order FindEfOrder(int id)
        {
            return this.repEfOrder.Find(id);
        }

        public Order[] GetAllEfOrder()
        {
            return this.repEfOrder.GetAll();
        }

        public IDisposable SubscribeOrder(IObserver<Order> observer)
        {
            return this.repOrder.Subscribe(observer);
        }

        public IDisposable SubscribeProd(IObserver<Prod> observer)
        {
            return this.repProd.Subscribe(observer);
        }

        public void Close()
        {
            this.repOrder.Close();
            this.repProd.Close();
            this.repEfOrder.Close();
        }


    }
}
