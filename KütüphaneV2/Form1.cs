using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace KütüphaneV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Insan gorevli = new Gorevli("00000000000");
            Insan kullanici = new Kullanici("11111111111");
            //DateTime kiraTarihi = new DateTime(2020, 12, 7);
            //DateTime iadeTarihi = new DateTime(2020, 12, 20);
            //kullanici.raporGuncelle(kullanici.kitapBilgiAl("Satranç", "Stefan Zweig", "2020"), kiraTarihi, iadeTarihi, 17.135);
            dataGridView1.DataSource = gorevli.raporSorgula();
            //double d=3.14;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
