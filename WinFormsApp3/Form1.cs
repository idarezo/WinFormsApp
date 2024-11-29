using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        private List<string> parametri= new List<string>();
        private List<int> vneseniUtezi = new List<int>();
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        Dictionary<string, List<int>> dictionaryALternativ = new Dictionary<string, List<int>>();
        Dictionary<string, double> dictionarIzracun = new Dictionary<string,double>();




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text=="")
            {
                MessageBox.Show("Vnesite vrednost za parameter. ");
            }
            else
            {
                parametri.Add(textBox1.Text);
                MessageBox.Show("Sledeci parameter je bil dodan : " + parametri[^1]);
               
            }
        }
           
           
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int vnesenaUtež))
            {
                if (textBox1.Text == null || textBox1.Text == "")
                {
                    MessageBox.Show("Prva vnesite parameter.");
                }
                else if (vnesenaUtež>10)
                {
                    MessageBox.Show("Vnesite stevilo manjse od 10.");
                }
                else
                {
                    vneseniUtezi.Add(vnesenaUtež);
                    dictionary.Add(parametri[^1], vnesenaUtež);
                    KeyValuePair<string, int> zadnjiPar = dictionary.Last();
                    textBox3.Text += zadnjiPar.Key + ": " + zadnjiPar.Value.ToString() + "\n";
                    textBox1.Text = "";
                    textBox2.Text = "";

                }
            }
            else
            {
                
                MessageBox.Show("Vnesite veljavno stevilo.");
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             // Število stolpcev
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, int> parameterVtez in dictionary)
            {

                textBox3.Text += parameterVtez.Key + ": " + parameterVtez.Value.ToString() + "\n";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
           
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            if (textBox4.Text == null || textBox4.Text == "")
            {
                MessageBox.Show("Vnesite vrednost za parameter. ");
            }
            else
            {
                if (dictionaryALternativ.ContainsKey(textBox4.Text)) {

                    if (dictionaryALternativ[textBox4.Text].Count() < parametri.Count())
                    {
                        int utezTest;
                        if (int.TryParse(textBox5.Text, out utezTest))
                        {
                            dictionaryALternativ[textBox4.Text].Add(utezTest);
                        }
                        else
                        {
                            textBox4.Text = "";
                            MessageBox.Show("Vnesite veljavno vrednost za dodajanje v seznam.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vnesli ste vse parametre.");
                    }
                   
                }
                else
                {
                    dictionaryALternativ[textBox4.Text] = new List<int>();
                    int utez;
                    if (int.TryParse(textBox5.Text, out utez))
                    {
                        dictionaryALternativ[textBox4.Text].Add(utez);
                    }
                    else
                    {
                        MessageBox.Show("Vnesite veljavno vrednost za dodajanje v seznam.");
                    }

                }


            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            double maks = 0.0;
            for (int i = 0; i < dictionaryALternativ.Count; i++)
            {
                KeyValuePair<string, List<int>> trenutniPar = dictionaryALternativ.ElementAt(i);
                string trenutniKljuc = trenutniPar.Key;
                List<int> vrednosti = trenutniPar.Value;
                double rezultat = 0.0;

                for (int j = 0; j < vrednosti.Count; j++)
                {
                    rezultat += vrednosti[j] * vneseniUtezi[j];

                   
                    
                }
                dictionarIzracun.Add(trenutniKljuc, rezultat);
            }
            foreach (KeyValuePair<string, double> parameterVtez in dictionarIzracun)
            {

                textBox6.Text += parameterVtez.Key + ": " + parameterVtez.Value.ToString() + Environment.NewLine; 
            }

            string maksKljuc = null;
            double maksVrednost = double.MinValue;
            foreach (var kvp in dictionarIzracun)
            {
                if (kvp.Value > maksVrednost)
                {
                    maksKljuc = kvp.Key;
                    maksVrednost = kvp.Value;
                }
            }
            bool vecOptimalnihResitev = dictionarIzracun.Count(kv => kv.Value == maksVrednost) > 1;

            if (vecOptimalnihResitev)
            {
                textBox6.Text += "Vec najbolj optimalnih opcij z isto vrednostjo: " + maksVrednost + Environment.NewLine;
            }
            else
            {
                textBox6.Text += "Najbolj optimalna opcija je " + maksKljuc + " z vrednostjo: " + maksVrednost + Environment.NewLine;
            }
            

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {
            chart1.Series["Alternative"].Points.Clear();

           
            chart1.Series["Alternative"].IsXValueIndexed = true;

            var keys = dictionarIzracun.Keys.ToList();
            for (int i = 0; i < keys.Count; i++)
            {
                var key = keys[i];
                double value = dictionarIzracun[key]; 

             
                chart1.Series["Alternative"].Points.AddXY(key, (int)value);
            }
            /*
            // Add new data points
            chart1.Series["Alternative"].Points.AddXY("Alternativa 1", 10);
            chart1.Series["Alternative"].Points.AddXY("Alternativa 2", 20);
            chart1.Series["Alternative"].Points.AddXY("Alternativa 3", 15);*/

        }

        private void chart2_Click(object sender, EventArgs e)
        {
            chart2.Series["Utezi"].Points.Clear();
            chart2.Series["Utezi"].IsXValueIndexed = true;

            var keys = dictionary.Keys.ToList();
            for (int i = 0; i < keys.Count; i++)
            {
                var key = keys[i];
                double value = dictionary[key];


                chart2.Series["Utezi"].Points.AddXY(key, (int)value);
            }

           /* chart2.Series["Utezi"].Points.AddXY("2014", 10);
            chart2.Series["Utezi"].Points.AddXY("2015", 22);
            chart2.Series["Utezi"].Points.AddXY("2016", 70);
            chart2.Series["Utezi"].Points.AddXY("2017", 45);*/

        }
    }
}