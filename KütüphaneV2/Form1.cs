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
        List<Panel> panel_Liste = new List<Panel>();
        List<Panel> anaPanel_Liste = new List<Panel>();
        List<Panel> kullaniciPanel_Liste = new List<Panel>();
        List<Panel> gorevliPanel_Liste = new List<Panel>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Insan insan = new Insan();
            panel_Liste.Add(ana_Panel);
            panel_Liste.Add(kullanici_Panel);
            panel_Liste.Add(gorevli_Panel);
        }

        public void panelCagir(Panel panel, List<Panel> liste)                                                      //parametre olarak gönderilen panel ve panelin olduğu listede, paneli ön plana çıkarır
        {
            if (panel.Name == "ana_Panel" || panel.Name == "gorevli_Panel" || panel.Name == "kullanici_Panel")
            {
                foreach (Panel paenl0 in liste)
                {
                    if (paenl0.Name == panel.Name)
                        paenl0.Visible = true;
                    else
                        paenl0.Visible = false;
                }
            }
            else
            {
                foreach (Panel panel0 in liste)
                {
                    if (panel0.Name == panel.Name)
                        panel0.BringToFront();
                    else
                        panel0.SendToBack();
                }
            }
        }

    }
}
