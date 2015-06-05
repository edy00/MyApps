using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Code;

namespace Proiect
{
    /**
     * main window of the program
     * the user can select from here if he is a admin or a client
     * automatically a new window will be shown, for the selection made
     * */
    public partial class Control : Form
    {
        
        private Controller ctrl;
        public Control(Controller ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
        }

        /*
         * if the admin button is clicked
         * a new window will open where you will log in
         * */
        private void button1_Click(object sender, EventArgs e)
        {
            
            FormControl cl = new FormControl("admin",ctrl,this);
            cl.Show();
        }

        /*
         * if the client button is clicked
         * a new window will open where you will log in
         * */
        private void button2_Click(object sender, EventArgs e)
        {
            FormControl ad = new FormControl("client",ctrl,this);
            ad.Show();
        }
        /*
         * here is the list of observers who subscribe
         * after each update of the database
         * every subscriber will be notified with the new changes
         */
        private List<IObserver<play>> observers = new List<IObserver<play>>();
        private List<IObserver<Re>> obsRe = new List<IObserver<Re>>();

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<play>> _observers;
            private IObserver<play> _observer;

            public Unsubscriber(List<IObserver<play>> observers, IObserver<play> observer)
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

        private class UnsubscriberRe : IDisposable
        {
            private List<IObserver<Re>> _obsRe;
            private IObserver<Re> _obRe;

            public UnsubscriberRe(List<IObserver<Re>> obsRe, IObserver<Re> obRe)
            {
                this._obsRe = obsRe;
                this._obRe = obRe;
            }
            public void Dispose()
            {
                if (_obRe != null && _obsRe.Contains(_obRe))
                    _obsRe.Remove(_obRe);
            }
        }

        public IDisposable Subscribe(IObserver<play> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        public void Notify(play next)
        {
            foreach (IObserver<play> obs in this.observers)
            {
                obs.OnNext(next);
            }

        }
    }
}
