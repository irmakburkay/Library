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
        List<Panel> anaPanel = new List<Panel>();
        List<Panel> kullaniciPanel = new List<Panel>();
        List<Panel> gorevliPanel = new List<Panel>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Insan insan = new Insan();
            anaPanel.Add(ana_Panel);
            anaPanel.Add(kullanici_Panel);
            anaPanel.Add(gorevli_Panel);
        }

        public void panelCagir(Panel panel, List<Panel> liste)                                                      //parametre olarak gönderilen panel ve panelin olduğu listede, paneli ön plana çıkarır
        {
            if (panel.Name == "ana_Panel" || panel.Name == "gorevli_Panel" || panel.Name == "kullanici_Panel")
            {
                foreach (Panel panel1 in liste)
                {
                    if (panel1.Name == panel.Name)
                        panel1.Visible = true;
                    else
                        panel1.Visible = false;
                }
            }
            else
            {
                foreach (Panel panel1 in liste)
                {
                    if (panel1.Name == panel.Name)
                        panel1.BringToFront();
                    else
                        panel1.SendToBack();
                }
            }
        }

    }
}
