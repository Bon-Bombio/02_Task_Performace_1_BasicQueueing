using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Queuing
{
    public partial class CashierWindowQueue : Form
    {
        ServingForm serving;
        private EventHandler timer1_tick;

        public CashierWindowQueue()
        {
            serving = new ServingForm();
            InitializeComponent();           
            
        }

        public void DisplayCashierQueue(IEnumerable CashierList)
        {
            listCashierView.Items.Clear();
            foreach (Object obj in CashierList)
            {
                listCashierView.Items.Add(obj.ToString());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            Timer timer = new Timer();
            timer.Interval = (1 * 1000);
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (CashierClass.CashierQueue.Count == 0)
                {
                    throw new Exception();
                }
                else
                {
                    serving.lblServing.Text = CashierClass.CashierQueue.Dequeue();
                    DisplayCashierQueue(CashierClass.CashierQueue.Peek());
                    DisplayCashierQueue(CashierClass.CashierQueue);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("No more costumers in Queue");
            }
        }

        private void CashierWindowQueue_Load(object sender, EventArgs e)
        {            
            serving.Show();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }
    }
}
