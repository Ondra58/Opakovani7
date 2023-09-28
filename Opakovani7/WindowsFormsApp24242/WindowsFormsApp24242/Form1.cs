using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp24242
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader ctenar = null;
            try
            {
                int n = int.Parse(textBox1.Text);
                ctenar = new StreamReader("cisla.txt");
                int poradi = 1;
                int[] pole = new int[100];
                double mocnina = 0;
                int podil_celociselny = 0;
                double podil_realny = 0;
                while (!ctenar.EndOfStream)
                {
                    int cislo = int.Parse(ctenar.ReadLine());
                    pole[poradi - 1] = cislo;
                    if (poradi == 5)
                    {
                        mocnina = cislo;
                        podil_realny = ((double)cislo / (double)n);
                        podil_celociselny = (cislo / n);
                        if (n == 0)
                        {
                            mocnina = 1;
                        }
                        else
                        {
                            if (n > 0)
                            {
                                for (int i = 1; i < n; i++)
                                {
                                    mocnina *= cislo;
                                }
                            }
                            if (n < 0)
                            {
                                n = Math.Abs(n);
                                for (int i = 1; i < n; i++)
                                {
                                    mocnina *= cislo;
                                }
                                mocnina = 1 / mocnina;
                            }
                        }
                    }
                    poradi++;
                }
                int soucet = 0;
                foreach (int cislo in pole)
                {
                    soucet += cislo;
                }
                MessageBox.Show(pole[4] + " na " + n + ". = " + mocnina.ToString() + "\nCeločíselný podíl čísel " + pole[4] + " a " + n + ": " + podil_celociselny.ToString() + "\nReálný podíl čísel " + pole[4] + " a " + n + ": " + podil_realny.ToString() + "\nSoučet: " + soucet.ToString());
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (ctenar != null)
                {
                    ctenar.Close();

                }
            }
        }
    }
}