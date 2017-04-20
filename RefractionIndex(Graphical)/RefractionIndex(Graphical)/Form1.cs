using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RefractionIndex_Graphical_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool didTheThing = false;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!didTheThing)
            {
                didTheThing = true;
                const double A = 10;
                const double NR_POINTS = 1000;

                const double OMEGA_INITIAL = 0;
                const double OMEGA_FINAL = 12;
                const double OMEGA_STEP = (OMEGA_FINAL - OMEGA_INITIAL) / NR_POINTS;

                double[] n = new double[(int)Math.Round(NR_POINTS)];

                double[] omegaChar = { 1, 2.5, 3.1, 4, 5.3, 6, 6.9, 8, 9, 10 };
                double[] freqChar = { 0.1, 0.3, 0.1, 0.08, 0.1, 0.1, 0.1, 0.2, 0.1, 0.1 };

                double omega;
                double sum;

                Console.WriteLine("Starting...");

                for (int i = 0; i < NR_POINTS; i++)
                {
                    omega = OMEGA_INITIAL + OMEGA_STEP * i;

                    double[] p = new double[omegaChar.Length];

                    for (int k = 0; k < p.Length; k++)
                    {
                        p[k] = Math.Abs(omegaChar[k] - omega);
                    }

                    double minP = p.Min();
                    //Console.WriteLine("minP = {0}", minP);
                    sum = 0;
                    double nI;

                    if (minP >= (OMEGA_STEP / 2))
                    {
                        sum = 0;

                        for (int j = 0; j < omegaChar.Length; j++)
                        {
                            sum = sum + freqChar[j] / (omegaChar[j] * omegaChar[j] - omega * omega);
                            /*                      if (i > 83)
                                                    {
                                                        Console.WriteLine("i = {0}, j = {1}, freqChar[{1}] = {2}, omegaChar[{1}] = {3}, omega = {4}, sum = {5}",
                                                                                i,       j,          freqChar[j],         omegaChar[j],      omega,        sum);
                                                    }
                            */
                        }

                    }
                    
                    n[i] = Math.Sqrt(Math.Abs(1 + (A * sum)));
                                       
                    //              Console.WriteLine("i = {0}, omega = {1}, n[{0}] = {2}", i, omega, n[i]);
                }

                double maxN = n.Max();
                double minN = n.Min();

                /*           foreach (double q in n)
                          {
                               Console.Write(q + ",\n");                
                               //Console.ReadKey(true);
                           }
                */
                Console.WriteLine("Max N: {0}, Min N: {1}", maxN, minN);

                for (int x = 1; x < n.Length; x++)
                {
                    System.Threading.Thread.Sleep(10);
                    e.Graphics.DrawLine(Pens.Black, x - 1, (float)((450 - n[x - 1] * 602 / maxN)), x, (float)((450 - n[x] * 602 / maxN)));
                }
            }
        }
    }
}
