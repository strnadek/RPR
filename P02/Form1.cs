using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace P02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static private int[] random(int n, int c1=1, int c2=99)
        {
            int[] pole = new int[n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                pole[i] = rnd.Next(c1, c2+1);
            }
            return pole;
        }
            
        static private void zobrazit(int[] pole, ListBox kam)
        {
            kam.Items.Clear();
            for(int i = 0; i < pole.Length; i++)
            {
                kam.Text = pole[i].ToString();
            }
        }

        static private void sudalicha(int[] pole, out int s_soucet, out int l_pocet)
        {
            s_soucet = 0;
            l_pocet = 0;
            for (int i = 0; i < pole.Length; i++)
            {
                if (pole[i] % 2 == 0)
                {
                    s_soucet += pole[i];
                }
                else
                {
                    l_pocet++;
                }
            }
        }

        
        static private bool rostouci(int[] pole)
        {
      
            for(int i = 1; i < pole.Length; i++)
            {
                if (pole[i] <= pole[i-1])
                {
                    return false;
                }
            }
            return true;
            
        }

        static private int[] vymena(int[] pole)
        {
            int max = int.MinValue;
            int pozice = 0;
            int posledni = 0;
            int posledni_pozice = 0;
            for(int i = 0; i < pole.Length; i++)
            {
                if (pole[i] > max)
                {
                    max = pole[i];
                    pozice = i;
                }
                if (pole.Length - 1 == i)
                {
                    posledni = pole[i];
                    posledni_pozice = i;
                }
            }
            pole.SetValue(posledni, pozice);
            pole.SetValue(max, posledni_pozice);
            return pole;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox1.Text);
            int c1 = Convert.ToInt32(textBox2.Text);
            int c2 = Convert.ToInt32(textBox3.Text);
            int[] pole = new int[n];
            if (textBox2.Text.Length == 0 && textBox3.Text.Length == 0)
            {
                pole = random(n);
            }
            else if (textBox2.Text.Length > 0 && textBox3.Text.Length > 0)
            {
                pole = random(n, c1, c2);
            }
            else if(textBox2.Text.Length > 0 && textBox3.Text.Length == 0)
            {
                pole = random(n, c1);
            }
            else if (textBox2.Text.Length == 0 && textBox3.Text.Length > 0)
            {
                pole = random(n,c2:c2);
            }

            zobrazit(pole, listBox1);

            int s_soucet; int l_pocet;
            sudalicha(pole, out s_soucet, out l_pocet);

            MessageBox.Show("Součet sudých čísel je " + s_soucet);
            MessageBox.Show("Počet lichých čísel je " + l_pocet);

            MessageBox.Show(rostouci(pole).ToString());

            
            vymena(pole);
        }
    }
}
