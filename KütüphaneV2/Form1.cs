//yorum satırı
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütüphaneV2
{
    public partial class KIS : Form
    {
        public Insan insan = new Insan();

        List<Panel> panel_Liste = new List<Panel>();
        List<Panel> anaPanel_Liste = new List<Panel>();
        List<Panel> kullaniciPanel_Liste = new List<Panel>();
        List<Panel> gorevliPanel_Liste = new List<Panel>();
        
        public void panelCagir(Panel panel, List<Panel> liste)                                                      //parametre olarak gönderilen panel ve panelin olduğu listede, paneli ön plana çıkarır
        {

            foreach (Panel paenl0 in liste)
            {
                if (paenl0.Name == panel.Name)
                    paenl0.Visible = true;
                else
                    paenl0.Visible = false;
            }

        }

        public KIS()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("icon.ico");
            this.Text = "Kütüphane İşletim Sistemi";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            panel_Liste.Add(ana_Panel);
            panel_Liste.Add(kullanici_Panel);
            panel_Liste.Add(gorevli_Panel);
            panelCagir(ana_Panel, panel_Liste);

            /*-------------------------------ana_Panel------------------------*/
            /*------------------------GİRİŞ---------------------------*/
            anaPanel_Liste.Add(ana_Giris_Panel);
            ana_PictureBox.ImageLocation = "icon.png";
            ana_KisLabel1.Text = "Kütüphane İşletim Sistemi";
            ana_Giris_Panel.BorderStyle = BorderStyle.FixedSingle;
            ana_Giris_Panel.BackColor = Color.White;
            ana_girisTc_Label.Text = "T.C.K.N.";
            ana_girisSifre_Label.Text = "Şifre";
            ana_girisSifre_textBox.PasswordChar = '*';
            ana_girisSifremiunuttum_Label.Text = "Şifremi Unuttum";
            ana_girisSifremiunuttum_Label.Cursor = Cursors.Hand;
            ana_girisYeniKayit_Label.Text = "Yeni Kayıt";
            ana_girisYeniKayit_Label.Cursor = Cursors.Hand;
            ana_girisGiris_Button.Text = "Giriş";
            ana_girisGiris_Button.Cursor = Cursors.Hand;
            /*------------------------GİRİŞ---------------------------*/
            /*------------------------ŞifremiUnuttum------------------*/
            anaPanel_Liste.Add(ana_SifremiUnuttum_Panel);
            ana_SifremiUnuttum_Panel.BorderStyle = BorderStyle.FixedSingle;
            ana_SifremiUnuttum_Panel.BackColor = Color.White;
            ana_suGuvenlikKelimesi_Label.Text = "Güvenlik Kelimesi";
            ana_suTc_Label.Text = "T.C.K.N.";
            ana_suKapat_Button.Text = "X";
            ana_suKapat_Button.Cursor = Cursors.Hand;
            ana_suSifreAl_Button.Text = "Şifre Al";
            ana_suSifreAl_Button.Cursor = Cursors.Hand;
            /*------------------------ŞifremiUnuttum------------------*/
            /*------------------------YeniKayıt-----------------------*/
            anaPanel_Liste.Add(ana_YeniKayıt_Panel);
            ana_YeniKayıt_Panel.BorderStyle = BorderStyle.FixedSingle;
            ana_YeniKayıt_Panel.BackColor = Color.White;
            ana_ykTc_Label.Text = "T.C.K.N.";
            ana_ykAd_Label.Text = "Ad";
            ana_ykSoyad_Label.Text = "Soyad";
            ana_ykSifre_Label.Text = "Şifre";
            ana_ykGuvenlikKelimesi_Label.Text = "Güvenlik Kelimesi";
            ana_ykKapat_Button.Text = "X";
            ana_ykKapat_Button.Cursor = Cursors.Hand;
            ana_ykYeniKayit_Button.Text = "Yeni Kayıt";
            ana_ykYeniKayit_Button.Cursor = Cursors.Hand;
            /*------------------------YeniKayıt-----------------------*/
            /*-------------------------------ana_Panel------------------------*/

            /*-------------------------------kullanıcı_Panel------------------*/
            //kodları buraya yazın
            /*-------------------------------kullanıcı_Panel------------------*/

            /*-------------------------------görevli_Panel--------------------*/
            //kodları buraya yazın
            /*-------------------------------görevli_Panel--------------------*/
        }

        /*-------------------------------ana_Panel------------------------*/
        /*------------------------GİRİŞ---------------------------*/

        private void ana_girisSifremiunuttum_Label_MouseEnter(object sender, EventArgs e)                               //mouse label üstündeyken yazının altını çizer
        {
            ana_girisSifremiunuttum_Label.Font = new Font(ana_girisSifremiunuttum_Label.Font,FontStyle.Underline);
        }

        private void ana_girisSifremiunuttum_Label_MouseLeave(object sender, EventArgs e)                               //mouse label üstünde değilken yazının alt çizgisini kaldırır
        {
            ana_girisSifremiunuttum_Label.Font = new Font(ana_girisSifremiunuttum_Label.Font, FontStyle.Regular);
        }
        
        private void ana_girisYeniKayit_Label_MouseEnter(object sender, EventArgs e)                                    //mouse label üstündeyken yazının altını çizer
        {
            ana_girisYeniKayit_Label.Font = new Font(ana_girisYeniKayit_Label.Font, FontStyle.Underline);
        }
        
        private void ana_girisYeniKayit_Label_MouseLeave(object sender, EventArgs e)                                    //mouse label üstünde değilken yazının alt çizgisini kaldırır
        {
            ana_girisYeniKayit_Label.Font = new Font(ana_girisYeniKayit_Label.Font, FontStyle.Regular);
        }
        
        private void ana_girisSifremiunuttum_Label_Click(object sender, EventArgs e)                                    //giriş panelindeki textbox içlerini boşaltır ve şifremi unuttum paneli ekrana getirir
        {
            panelCagir(ana_SifremiUnuttum_Panel, anaPanel_Liste);
            ana_girisTc_textBox.Text = "";
            ana_girisSifre_textBox.Text = "";
        }
        
        private void ana_girisYeniKayit_Label_Click(object sender, EventArgs e)                                         //giriş panelindeki textbox içlerini boşaltır ve yeni kayıt paneli ekrana getirir
        {
            panelCagir(ana_YeniKayıt_Panel, anaPanel_Liste);
            ana_girisTc_textBox.Text = "";
            ana_girisSifre_textBox.Text = "";
        }

        private void ana_girisSifre_checkBox_MouseClick(object sender, MouseEventArgs e)                                //tik atıldığında şifreyi gösterir, tik * olarak gösterir
        {
            {
                if (ana_girisSifre_checkBox.Checked)
                    ana_girisSifre_textBox.PasswordChar = '\0';
                else
                    ana_girisSifre_textBox.PasswordChar = '*';
            }
        }

        private void ana_girisTc_textBox_KeyPress(object sender, KeyPressEventArgs e)                                   //tc textbox içine sadece sayı girilmesinii sağlar
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ana_girisGiris_Button_Click(object sender, EventArgs e)                                            //giriş panelindeki textbox içlerini kontrol eder ve insanDurumuna göre kullanıcı ya da görevli kurucu metodunu çağırır
        {                                                                                                               //giriş textbox içlerini boşaltır ve insan nesnesinin insanDurumuna göre gerekli paneli çağırır
            if (ana_girisTc_textBox.Text.Length == 11)
            {
                if (insan.sqlString("SELECT count(*) FROM Insan WHERE tc='" + ana_girisTc_textBox.Text + "'") != "0")
                {
                    insan.bilgiAl(ana_girisTc_textBox.Text);
                    if (ana_girisSifre_textBox.Text.Length != 0)
                    {
                        if (insan.sifre == ana_girisSifre_textBox.Text)
                        {
                            switch (insan.insanDurumu())
                            {
                                case "Kullanıcı":
                                    insan = new Kullanici(insan.tc);
                                    MessageBox.Show("Kullanıcı Girişi Başarılı!");
                                    break;
                                case "Görevli":
                                    insan = new Gorevli(insan.tc);
                                    MessageBox.Show("Görevli Girişi Başarılı!");
                                    break;
                                default:
                                    MessageBox.Show("Bir Sorun Oluştu!");
                                    break;
                            }
                            ana_girisTc_textBox.Text = "";
                            ana_girisSifre_textBox.Text = "";
                            ana_girisSifre_checkBox.Checked = false;
                            if (insan is Kullanici)
                                panelCagir(kullanici_Panel, panel_Liste);
                            else if (insan is Gorevli)
                                panelCagir(gorevli_Panel, panel_Liste);
                        }
                        else
                            MessageBox.Show("Şifre yanlış girildi!");
                    }
                    else
                        MessageBox.Show("Lütfen şifreyi giriniz!");
                }
                else
                    MessageBox.Show(ana_girisTc_textBox.Text + " numaralı kullanıcı bulunmamaktadır!");
            }
            else
                MessageBox.Show("Tc numarası geçersizdir!");
        }

        /*------------------------GİRİŞ---------------------------*/
        /*------------------------ŞifremiUnuttum------------------*/

        private void ana_suKapat_Button_Click(object sender, EventArgs e)                                                   //şifremi unuttum panelindeki textbox içlerini boşaltır ve giriş paneli ekrana getirir
        {
            panelCagir(ana_Giris_Panel,anaPanel_Liste);
            ana_suTc_textBox.Text = "";
            ana_suGuvenlikKelimesi_textBox.Text = "";
        }

        private void ana_suTc_textBox_KeyPress(object sender, KeyPressEventArgs e)                                          //tc textbox içine sadece sayı girilmesini sağlar
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ana_suSifreAl_Button_Click(object sender, EventArgs e)                                                 //textbox içlerini kontrol eder ve şifreyi mesaj olarak verir,şifremi unuttum panelindeki textbox içlerini boşaltır ve giriş paneli ekrana getirir
        {
            if (ana_suTc_textBox.Text.Length == 11)
            {
                if (insan.sqlString("SELECT count(*) FROM Insan WHERE tc='" + ana_suTc_textBox.Text + "'") != "0")
                {
                    if (ana_suGuvenlikKelimesi_textBox.Text.Length != 0)
                    {
                        insan.bilgiAl(ana_suTc_textBox.Text);
                        if (insan.guvenlikKelimesi == ana_suGuvenlikKelimesi_textBox.Text)
                        {
                            MessageBox.Show("Şifreniz : " + insan.sifre);
                            panelCagir(ana_Giris_Panel, anaPanel_Liste);
                            ana_suTc_textBox.Text = "";
                            ana_suGuvenlikKelimesi_textBox.Text = "";
                        }
                        else
                            MessageBox.Show("Güvenlik kelimesi yanlış girildi!");
                    }
                    else
                        MessageBox.Show("Lütfen güvenlik kelimesini giriniz!");
                }
                else
                    MessageBox.Show(ana_suTc_textBox.Text + " numaralı kullanıcı bulunmamaktadır!");
            }
            else
                MessageBox.Show("Tc numarası geçersizdir!");
        }

        /*------------------------ŞifremiUnuttum------------------*/
        /*------------------------YeniKayıt-----------------------*/

        private void ana_ykKapat_Button_Click(object sender, EventArgs e)                   //yeni kullanıcı panelindeki textbox içlerini boşaltır ve giriş panelini ekrana getirir                                    
        {
            panelCagir(ana_Giris_Panel, anaPanel_Liste);
            ana_ykTc_textBox.Text = "";
            ana_ykSifre_textBox.Text = "";
            ana_ykAd_textBox.Text = "";
            ana_ykSoyad_textBox.Text = "";
            ana_ykGuvenlikKelimesi_textBox.Text = "";
        }

        private void ana_ykTc_textBox_KeyPress(object sender, KeyPressEventArgs e)          //yeni kullanıcı panelindeki tc textbox içine sadece sayı girilmesini sağlar
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)  )
            {
                e.Handled = true;
            }
        }

        private void ana_ykYeniKayit_Button_Click(object sender, EventArgs e)               //textbox içlerini kontrol eder ve yeni kullanıcı oluşturur, yeni kullanıcı panelindeki textbox içlerini boşaltır ve giriş panelini getirir
        {
            if (ana_ykTc_textBox.Text.Length == 11)
            {
                if (ana_ykSifre_textBox.Text.Length != 0 && ana_ykAd_textBox.Text.Length != 0 && ana_ykSoyad_textBox.Text.Length != 0 && ana_ykGuvenlikKelimesi_textBox.Text.Length != 0)
                {
                    if (insan.sqlString("SELECT count(*) FROM Insan WHERE tc='" + ana_ykTc_textBox.Text + "'") == "0")
                    {
                        insan = new Kullanici(ana_ykTc_textBox.Text, ana_ykSifre_textBox.Text, ana_ykAd_textBox.Text, ana_ykSoyad_textBox.Text, ana_ykGuvenlikKelimesi_textBox.Text);
                        MessageBox.Show("Yeni Kullanıcı Oluşturuldu");
                        panelCagir(ana_Giris_Panel, anaPanel_Liste);
                        ana_ykTc_textBox.Text = "";
                        ana_ykSifre_textBox.Text = "";
                        ana_ykAd_textBox.Text = "";
                        ana_ykSoyad_textBox.Text = "";
                        ana_ykGuvenlikKelimesi_textBox.Text = "";
                    }
                    else
                        MessageBox.Show("Halihazırda " + ana_ykTc_textBox.Text + " tc numaralı kayıt bulunmaktadır!");
                }
                else
                    MessageBox.Show("Kutuları boş bırakmayın!");
            }
            else
                MessageBox.Show("Tc numarası geçersizdir!");
        }

        /*------------------------YeniKayıt-----------------------*/
        /*-------------------------------ana_Panel------------------------*/
        /*-------------------------------kullanıcı_Panel------------------*/

        private void kullanici_MenuCikis_Click(object sender, EventArgs e)      //çıkış yapar ,giriş panelini getirir, insan nesnesini insan kurucu metoduyla yeniden oluşturur(içi boş olur)
        {
            MessageBox.Show("Çıkış Yapıldı!");
            panelCagir(ana_Panel, panel_Liste);
            insan = new Insan();
        }

        /*-------------------------------kullanıcı_Panel------------------*/
        /*-------------------------------görevli_Panel--------------------*/

        private void gorevli_MenuCikis_Click(object sender, EventArgs e)      //çıkış yapar ,giriş panelini getirir, insan nesnesini insan kurucu metoduyla yeniden oluşturur(içi boş olur)
        {
            MessageBox.Show("Çıkış Yapıldı!");
            panelCagir(ana_Panel, panel_Liste);
            insan = new Insan();
        }

        /*-------------------------------görevli_Panel--------------------*/
    }
}