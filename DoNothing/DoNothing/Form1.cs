using System;
using System.Threading;
using System.Windows.Forms;

namespace DoNothing
{
    public partial class Form1 : Form
    {
        private Thread nullWorker = new Thread(() => { while (true) { } });

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!nullWorker.IsAlive) nullWorker.Start();
        } 

        private void button2_Click(object sender, EventArgs e) => nullWorker.Abort();
    }
}
