﻿using System;
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
        List<Panel> kullaniciPanelListe = new List<Panel>();
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

        private void dgwFiltrele(RadioButton radioButton, DataGridView dataGridView, string sutunAdi, string deger)     //parametre olarak radiobutton.checked durumunu ilgili datagridview içinde sütunAdı ve deger ile kontrol ederek filtreler
        {
            switch (radioButton.Checked)
            {
                case true:
                    foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
                    {
                        if (dataGridViewRow.Cells[sutunAdi].Value.ToString()==deger)
                            dataGridViewRow.Visible = true;
                        else
                        {
                            dataGridViewRow.DataGridView.CurrentCell = null;
                            dataGridViewRow.Visible = false;
                        }
                    }
                    break;
                case false:
                    foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
                    {
                        if (dataGridViewRow.Cells[sutunAdi].Value.ToString()==deger)
                        {
                            dataGridViewRow.DataGridView.CurrentCell = null;
                            dataGridViewRow.Visible = false;
                        }
                        else
                            dataGridViewRow.Visible = true;
                        }
                    break;
            }
        }

        private void dgwFiltrele(DataGridView dataGridView, string sutunAdi, string deger) //sütünadı, deger metnini içeriyorsa,datagridview deki satırları filtreler
        {
            foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
            {
                if (dataGridViewRow.Cells[sutunAdi].Value.ToString().ToLower().Contains(deger) == true ||
                    dataGridViewRow.Cells[sutunAdi].Value.ToString().ToUpper().Contains(deger) == true ||
                    dataGridViewRow.Cells[sutunAdi].Value.ToString().Contains(deger) == true)
                {
                    dataGridViewRow.Visible = true;
                }
                else
                {
                    dataGridViewRow.DataGridView.CurrentCell = null;
                    dataGridViewRow.Visible = false;
                }
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
            kullanici_Panel.BackColor=Color.White;;
            panel_Liste.Add(gorevli_Panel);
            gorevli_Panel.BackColor = Color.White; ;
            panelCagir(ana_Panel, panel_Liste);

            /*-------------------------------ana_Panel------------------------*/
            /*------------------------Giriş---------------------------*/
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
            /*------------------------Giriş---------------------------*/
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
            anaPanel_Liste.Add(ana_YeniKayit_Panel);
            ana_YeniKayit_Panel.BorderStyle = BorderStyle.FixedSingle;
            ana_YeniKayit_Panel.BackColor = Color.White;
            ana_ykTc_Label.Text = "T.C.K.N.";
            ana_ykAd_Label.Text = "Ad";
            ana_ykSoyad_Label.Text = "Soyad";
            ana_ykSifre_Label.Text = "Şifre";
            ana_ykGuvenlikKelimesi_Label.Text = "Güvenlik Kelimesi";
            ana_ykKapat_Button.Text = "X";
            ana_ykKapat_Button.Cursor = Cursors.Hand;
            ana_ykYeniKayit_Button.Text = "Yeni Kayıt";
            ana_ykYeniKayit_Button.Cursor = Cursors.Hand;
            ana_yk_Gorevli_radioButton.Text = "Görevli";
            ana_yk_Gorevli_radioButton.Checked = false;
            ana_yk_Kullanici_radioButton.Text = "Kullanıcı";
            ana_yk_Kullanici_radioButton.Checked = true;
            /*------------------------YeniKayıt-----------------------*/
            /*-------------------------------ana_Panel------------------------*/

            /*-------------------------------kullanıcı_Panel------------------*/
            /*------------------------YeniKitap-----------------------*/
            kullaniciPanelListe.Add(kullanici_YeniKitap_Panel);
            kullanici_YeniKitap_Panel.BorderStyle = BorderStyle.FixedSingle;
            kullanici_YeniKitap_Panel.BackColor = Color.White;
            /*------------------------YeniKitap-----------------------*/
            /*------------------------Talepler------------------------*/
            kullaniciPanelListe.Add(kullanici_Talepler_Panel);
            kullanici_Talepler_Panel.BorderStyle = BorderStyle.FixedSingle;
            kullanici_Talepler_Panel.BackColor = Color.White;
            kullanici_Talepler_Hepsi_radioButton.Text = "Hepsi";
            kullanici_Talepler_Yeni_radioButton.Text = "Yeni Kitap";
            kullanici_Talepler_Kira_radioButton.Text = "Kiralama";
            kullanici_Talepler_Onaylandi_radioButton.Text = "Onaylandı";
            kullanici_Talepler_Onaylanmadi_radioButton.Text = "Onaylanmadı";
            kullanici_Talepler_Reddedildi_radioButton.Text = "Reddedildi";
            /*------------------------Talepler------------------------*/
            /*------------------------hakkımızda----------------------*/
            kullaniciPanelListe.Add(kullanici_hakkimizda_panel);
            kullanici_hakkimizda_panel.BorderStyle = BorderStyle.FixedSingle;
            kullanici_hakkimizda_panel.BackColor = Color.White;
            /*------------------------hakkımızda----------------------*/
            /*------------------------bilgilerim----------------------*/
            kullaniciPanelListe.Add(kullanici_bilgilerim_panel);
            kullanici_bilgilerim_panel.BorderStyle = BorderStyle.FixedSingle;
            kullanici_bilgilerim_panel.BackColor = Color.White;
            /*------------------------bilgilerim----------------------*/
            /*------------------------Raporlar------------------------*/
            kullaniciPanelListe.Add(kullanici_Rapor_Panel);
            kullanici_Rapor_Panel.BorderStyle = BorderStyle.FixedSingle;
            kullanici_Rapor_Panel.BackColor = Color.White;
            kullanici_Rapor_ad_label.Text = "Kitap Adı";
            kullanici_Rapor_yazar_label.Text = "Yazar";
            kullanici_Rapor_basimYili_label.Text = "Basım Yılı";
            kullanici_Rapor_iade_button.Text = "İade Et";
            /*------------------------Raporlar------------------------*/
            /*------------------------kitaplar------------------------*/
            kullaniciPanelListe.Add(kullanici_kitaplar_panel);
            kullanici_kitaplar_panel.BorderStyle = BorderStyle.FixedSingle;
            kullanici_kitaplar_panel.BackColor = Color.White;
            /*------------------------kitaplar------------------------*/
            /*-------------------------------kullanıcı_Panel------------------*/

            /*-------------------------------görevli_Panel--------------------*/
            /*------------------------YeniKitap-----------------------*/
            gorevliPanel_Liste.Add(gorevli_YeniKitap_Panel);
            gorevli_YeniKitap_Panel.BorderStyle = BorderStyle.FixedSingle;
            gorevli_YeniKitap_Panel.BackColor = Color.White;
            /*------------------------YeniKitap-----------------------*/
            /*------------------------Talepler------------------------*/
            gorevliPanel_Liste.Add(gorevli_Talepler_Panel);
            gorevli_Talepler_Panel.BorderStyle = BorderStyle.FixedSingle;
            gorevli_Talepler_Panel.BackColor = Color.White;
            gorevli_Talepler_Hepsi_radioButton.Text = "Hepsi";
            gorevli_Talepler_Yeni_radioButton.Text = "Yeni Kitap";
            gorevli_Talepler_Kira_radioButton.Text = "Kiralama";
            gorevli_Talepler_Onaylandi_radioButton.Text = "Onaylandı";
            gorevli_Talepler_Onaylanmadi_radioButton.Text = "Onaylanmadı";
            gorevli_Talepler_Reddedildi_radioButton.Text = "Reddedildi";
            gorevli_Talepler_Onayla_Button.Text = "Onayla";
            gorevli_Talepler_Reddet_button.Text = "Reddet";
            /*------------------------Talepler------------------------*/
            /*------------------------bilgilerim----------------------*/
            gorevliPanel_Liste.Add(gorevli_bilgilerim_panel);
            gorevli_bilgilerim_panel.BorderStyle = BorderStyle.FixedSingle;
            gorevli_bilgilerim_panel.BackColor = Color.White;
            /*------------------------bilgilerim----------------------*/
            /*------------------------Raporlar------------------------*/
            gorevliPanel_Liste.Add(gorevli_Rapor_Panel);
            gorevli_Rapor_Panel.BorderStyle = BorderStyle.FixedSingle;
            gorevli_Rapor_Panel.BackColor=Color.White;
            gorevli_Rapor_ad_label.Text = "Kitap Adı";
            gorevli_Rapor_yazar_label.Text = "Yazar";
            gorevli_Rapor_basimYili_label.Text = "Basım Yılı";
            /*------------------------Raporlar------------------------*/
            /*------------------------kitaplar------------------------*/
            gorevliPanel_Liste.Add(gorevli_kitaplar_panel);
            gorevli_kitaplar_panel.BorderStyle = BorderStyle.FixedSingle;
            gorevli_kitaplar_panel.BackColor = Color.White;
            /*------------------------kitaplar------------------------*/
            /*------------------------insanlar------------------------*/
            //gorevliPanel_Liste.Add(ana_YeniKayit_Panel);
            gorevliPanel_Liste.Add(gorevli_insanlar_panel);
            gorevli_insanlar_panel.BorderStyle = BorderStyle.FixedSingle;
            gorevli_insanlar_panel.BackColor=Color.White;
            gorevli_insanlar_insanEkle_button.Text = "İnsan Ekle";
            gorevli_insanlar_kAta_button.Text = "Kullanıcı Ata";
            gorevli_insanlar_gAta_button.Text = "Görevli Ata";
            gorevli_insanlar_isim_label.Text = "İsim";
            gorevli_insanlar_soyisim_label.Text = "Soyisim";
            /*------------------------insanlar------------------------*/
            /*-------------------------------görevli_Panel--------------------*/
        }

        /*-------------------------------ana_Panel------------------------*/
        /*------------------------Giriş---------------------------*/

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
            ana_suTc_textBox.Text = "";
            ana_suGuvenlikKelimesi_textBox.Text = "";
        }
        
        private void ana_girisYeniKayit_Label_Click(object sender, EventArgs e)                                         //giriş panelindeki textbox içlerini boşaltır ve yeni kayıt paneli ekrana getirir
        {
            if (insan is Gorevli)
            {
                ana_yk_Gorevli_radioButton.Visible = true;
                ana_yk_Kullanici_radioButton.Visible = true;
                panelCagir(ana_Panel,panel_Liste);
                panelCagir(ana_YeniKayit_Panel,anaPanel_Liste);
            }
            else
            {
                ana_ykTc_textBox.Text = "";
                ana_ykSifre_textBox.Text = "";
                ana_ykAd_textBox.Text = "";
                ana_ykSoyad_textBox.Text = "";
                ana_ykGuvenlikKelimesi_textBox.Text = "";
                ana_yk_Gorevli_radioButton.Visible = false;
                ana_yk_Kullanici_radioButton.Visible = false;
                panelCagir(ana_YeniKayit_Panel, anaPanel_Liste);
            }
        }

        private void ana_girisSifre_checkBox_MouseClick(object sender, MouseEventArgs e)                                //tik atıldığında şifreyi gösterir, tik * olarak gösterir
        {
            switch (ana_girisSifre_checkBox.Checked)
            {
                case true:
                    ana_girisSifre_textBox.PasswordChar = '\0';
                    break;
                case false:
                    ana_girisSifre_textBox.PasswordChar = '*';
                    break;
            }
        }

        private void ana_girisTc_textBox_KeyPress(object sender, KeyPressEventArgs e) //tc textbox içine sadece sayı girilmesinii sağlar
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
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
                            {
                                kullanici_bilgilerimToolStripMenuItem.Text = insan.isim + " " + insan.soyisim;
                                panelCagir(kullanici_Panel, panel_Liste);
                            }
                            else if (insan is Gorevli)
                            {
                                gorevli_bilgilerimToolStripMenuItem.Text = insan.isim + " " + insan.soyisim;
                                bilgilerimToolStripMenuItem_Click(sender,e);
                                panelCagir(gorevli_Panel, panel_Liste);
                            }
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

        /*------------------------Giriş---------------------------*/
        /*------------------------ŞifremiUnuttum------------------*/

        private void ana_suKapat_Button_Click(object sender, EventArgs e)                                                   //şifremi unuttum panelindeki textbox içlerini boşaltır ve giriş paneli ekrana getirir
        {
            panelCagir(ana_Giris_Panel,anaPanel_Liste);
            ana_girisTc_textBox.Text = "";
            ana_girisSifre_textBox.Text = "";
        }

        private void ana_suTc_textBox_KeyPress(object sender, KeyPressEventArgs e)                                          //tc textbox içine sadece sayı girilmesini sağlar
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
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
            if (insan is Gorevli)
                gorevli_insanlarToolStripMenuItem_Click(sender, e);
            else
            {
                ana_girisTc_textBox.Text = "";
                ana_girisSifre_textBox.Text = "";
                panelCagir(ana_Giris_Panel, anaPanel_Liste);
            }
        }

        private void ana_ykTc_textBox_KeyPress(object sender, KeyPressEventArgs e)          //yeni kullanıcı panelindeki tc textbox içine sadece sayı girilmesini sağlar
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)  )
                e.Handled = true;
        }

        private void ana_ykYeniKayit_Button_Click(object sender, EventArgs e)               //textbox içlerini kontrol eder ve yeni kullanıcı oluşturur, yeni kullanıcı panelindeki textbox içlerini boşaltır ve giriş panelini getirir
        {
            if (ana_ykTc_textBox.Text.Length == 11)
            {
                if (ana_ykSifre_textBox.Text.Length != 0 && ana_ykAd_textBox.Text.Length != 0 && ana_ykSoyad_textBox.Text.Length != 0 && ana_ykGuvenlikKelimesi_textBox.Text.Length != 0)
                {
                    if (insan.sqlString("SELECT count(*) FROM Insan WHERE tc='" + ana_ykTc_textBox.Text + "'") == "0")
                    {
                        if (insan is Gorevli)
                        {
                            if (ana_yk_Gorevli_radioButton.Checked)
                            {
                                insan.insanEkle(ana_ykTc_textBox.Text, ana_ykSifre_textBox.Text, ana_ykAd_textBox.Text,
                                    ana_ykSoyad_textBox.Text, ana_ykGuvenlikKelimesi_textBox.Text,
                                    ana_yk_Gorevli_radioButton.Text);
                                MessageBox.Show("Yeni " + ana_yk_Gorevli_radioButton.Text + " Oluşturuldu!");
                                gorevli_insanlarToolStripMenuItem_Click(sender,e);
                            }
                            else if (ana_yk_Kullanici_radioButton.Checked)
                            {
                                insan.insanEkle(ana_ykTc_textBox.Text, ana_ykSifre_textBox.Text, ana_ykAd_textBox.Text,
                                    ana_ykSoyad_textBox.Text, ana_ykGuvenlikKelimesi_textBox.Text,
                                    ana_yk_Kullanici_radioButton.Text);
                                MessageBox.Show("Yeni " + ana_yk_Kullanici_radioButton.Text + " Oluşturuldu!");
                                gorevli_insanlarToolStripMenuItem_Click(sender, e);
                            }
                            else
                                MessageBox.Show("Lütfen Kayıt Seçeneği Seçin!");
                        }
                        else
                        {
                            insan = new Kullanici(ana_ykTc_textBox.Text, ana_ykSifre_textBox.Text, ana_ykAd_textBox.Text, ana_ykSoyad_textBox.Text, ana_ykGuvenlikKelimesi_textBox.Text);
                            MessageBox.Show("Yeni Kullanıcı Oluşturuldu");
                            ana_girisYeniKayit_Label_Click(sender, e);
                        }
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
            panelCagir(ana_Giris_Panel,anaPanel_Liste);
            insan = new Insan();
        }

        /*------------------------YeniKitap-----------------------*/

        private void kullanici_yeniKitapToolStripMenuItem_Click(object sender, EventArgs e) //kullanıcı için yeni kitap panelini ekrana getirir ve içindeki textboxları boşaltıp datagridviewi yeni kitap talepleri için filtreler
        {
            kullanici_YeniKitap_kitapadi_textBox.Text = "";
            kullanici_YeniKitap_yazar_textBox.Text = "";
            kullanici_YeniKitap_basimyili_maskedTextBox.Text = "";
            kullanici_YeniKitap_dataGridView.DataSource = insan.talepSorgula();
            dgwFiltrele(kullanici_YeniKitap_dataGridView,"İşlem","Yeni");
            panelCagir(kullanici_YeniKitap_Panel, kullaniciPanelListe);
        }

        private void kullanici_YeniKitap_button_Click(object sender, EventArgs e)   //yeni kitap talebi oluşturur
        {
            insan.kitapEkle(kullanici_YeniKitap_kitapadi_textBox.Text, kullanici_YeniKitap_yazar_textBox.Text, kullanici_YeniKitap_basimyili_maskedTextBox.Text);
            kullanici_yeniKitapToolStripMenuItem_Click(sender,e);
        }

        /*------------------------YeniKitap-----------------------*/
        /*------------------------Talepler------------------------*/

        private void kullanici_taleplerToolStripMenuItem_Click(object sender, EventArgs e)      //talepler panelini açan menü tuşu, radiobutton ve datagridviewi günceller
        {
            panelCagir(kullanici_Talepler_Panel,kullaniciPanelListe);
            kullanici_Talepler_Hepsi_radioButton.Checked = true;
            kullanici_Talepler_dataGridView.DataSource = insan.talepSorgula();
        }

        private void kullanici_Talepler_Hepsi_radioButton_CheckedChanged(object sender, EventArgs e)    //radiobutton seçilirse datagridviewi filtresiz günceller
        {
            foreach (DataGridViewRow dataGridViewRow in kullanici_Talepler_dataGridView.Rows)
                dataGridViewRow.Visible = true;
        }

        private void kullanici_Talepler_Yeni_radioButton_CheckedChanged(object sender, EventArgs e)     //seçilen radiobuttona göre datagridview günceller
        {
            dgwFiltrele(kullanici_Talepler_Yeni_radioButton,kullanici_Talepler_dataGridView,"İşlem","Yeni");
        }

        private void kullanici_Talepler_Kira_radioButton_CheckedChanged(object sender, EventArgs e)     //seçilen radiobuttona göre datagridview günceller
        {
            dgwFiltrele(kullanici_Talepler_Kira_radioButton, kullanici_Talepler_dataGridView, "İşlem", "Kira");
        }

        private void kullanici_Talepler_Onaylandi_radioButton_CheckedChanged(object sender, EventArgs e)    //seçilen radiobuttona göre datagridview günceller
        {
            dgwFiltrele(kullanici_Talepler_Onaylandi_radioButton, kullanici_Talepler_dataGridView, "Durum", "Onaylandı");
        }

        private void kullanici_Talepler_Onaylanmadi_radioButton_CheckedChanged(object sender, EventArgs e)      //seçilen radiobuttona göre datagridview günceller
        {
            dgwFiltrele(kullanici_Talepler_Onaylanmadi_radioButton, kullanici_Talepler_dataGridView, "Durum", "Onaylanmadı");
        }
        private void kullanici_Talepler_Reddedildi_radioButton_CheckedChanged(object sender, EventArgs e)    //seçilen radiobuttona göre datagridview günceller
        {
            dgwFiltrele(kullanici_Talepler_Reddedildi_radioButton, kullanici_Talepler_dataGridView, "Durum", "Reddedildi");
        }
        /*------------------------Talepler------------------------*/
        /*------------------------hakkımızda----------------------*/
        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)      //hakkımızda panelini ekrana getirir
        {
            panelCagir(kullanici_hakkimizda_panel, kullaniciPanelListe);
        }
        /*------------------------hakkımızda----------------------*/
        /*------------------------bilgilerim----------------------*/

        private void bilgilerimToolStripMenuItem1_Click(object sender, EventArgs e) //bilgilerim panelini ekrana getirir ve textbox içlerini classdaki değerlerle doldurur
        {
            kullanici_bilgilerim_ad_textbox.Text = insan.isim;
            kullanici_bilgilerim_soyad_textbox.Text = insan.soyisim;
            kullanici_bilgilerim_tcno_textbox.Text = insan.tc;
            kullanici_bilgilerim_sifre_textbox.Text = insan.sifre;
            kullanici_bilgilerim_guvenlikkelimesi_textbox.Text = insan.guvenlikKelimesi;
            panelCagir(kullanici_bilgilerim_panel, kullaniciPanelListe);
        }

        private void kullanici_bilgilerimiguncelle_button_Click(object sender, EventArgs e)     //kullanıcı bilgilerini günceller ve bilgi al ile classdaki verileri eşitler
        {
            insan.bilgiGuncelle(kullanici_bilgilerim_sifre_textbox.Text, kullanici_bilgilerim_ad_textbox.Text, kullanici_bilgilerim_soyad_textbox.Text, kullanici_bilgilerim_guvenlikkelimesi_textbox.Text);
            MessageBox.Show("Bilgileriniz Guncellendi");
            insan.bilgiAl(insan.tc);
            kullanici_bilgilerimToolStripMenuItem.Text = insan.isim + " " + insan.soyisim;
            bilgilerimToolStripMenuItem1_Click(sender,e);
        }
        /*------------------------bilgilerim----------------------*/
        /*------------------------Raporlar------------------------*/

        private void raporlarToolStripMenuItem_Click(object sender, EventArgs e)        //panel içindeki textboxları boşaltır datagridviewi veritabanındaki tabloyla doldurur ve paneli çağırır
        {
            kullanici_Rapor_ad_textBox.Text = "";
            kullanici_Rapor_yazar_textBox.Text = "";
            kullanici_Rapor_basimYili_textBox.Text = "";
            kullanici_Rapor_dataGridView.DataSource = insan.raporSorgula();
            panelCagir(kullanici_Rapor_Panel,kullaniciPanelListe);
        }

        private void kullanici_Rapor_basimYili_textBox_KeyPress(object sender, KeyPressEventArgs e)     //basım yılı textbox içine sadece sayı girilmesini sağlar
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void kullanici_Rapor_ad_textBox_TextChanged(object sender, EventArgs e)                 //textbox içine yazıldıkça datagridviewi filtreler
        {
            dgwFiltrele(kullanici_Rapor_dataGridView,"İsim",kullanici_Rapor_ad_textBox.Text);
        }

        private void kullanici_Rapor_yazar_textBox_TextChanged(object sender, EventArgs e)                 //textbox içine yazıldıkça datagridviewi filtreler
        {
            dgwFiltrele(kullanici_Rapor_dataGridView, "Yazar", kullanici_Rapor_yazar_textBox.Text);
        }

        private void kullanici_Rapor_basimYili_textBox_TextChanged(object sender, EventArgs e)                 //textbox içine yazıldıkça datagridviewi filtreler
        {
            dgwFiltrele(kullanici_Rapor_dataGridView, "Basım Yılı", kullanici_Rapor_basimYili_textBox.Text);
        }

        private void kullanici_Rapor_iade_button_Click(object sender, EventArgs e)      //seçilen satırdaki kitabı iade eder
        {
            foreach (DataGridViewRow dataGridViewRow in kullanici_Rapor_dataGridView.SelectedRows)
            {
                if (dataGridViewRow.Cells["İade Tarihi"].Value.ToString().Equals(""))
                {
                    DateTime kiraTarihi = Convert.ToDateTime(dataGridViewRow.Cells["Kira Tarihi"].Value.ToString());
                    double cezaTutari = 0;
                    if(int.Parse((DateTime.Today - kiraTarihi).Days.ToString()) > 14)
                        cezaTutari= ((DateTime.Today - kiraTarihi).Days -14) *0.5;
                    insan.kitapIade(int.Parse(dataGridViewRow.Cells["ID"].Value.ToString()),cezaTutari);
                    MessageBox.Show("Seçilen Kitap İade Edildi!"+"\nCeza Tutarınız : "+cezaTutari);
                    raporlarToolStripMenuItem_Click(sender, e);
                }
                else
                    MessageBox.Show("Seçilen Kitap İade Edilemez!");
            }
        }
        /*------------------------Raporlar------------------------*/
        /*------------------------kitaplar------------------------*/
        private void kitaplarToolStripMenuItem1_Click(object sender, EventArgs e)       //kitaplar panelini ekrana getirir
        {
            kullanici_kitaplar_kitapAdi_textBox.Text = "";
            kullanici_kitaplar_yazar_textBox.Text = "";
            kullanici_kitaplar_basimyili_textBox.Text = "";
            kullanici_kitaplar_dataGridView.DataSource = insan.kitapSorgula();
            panelCagir(kullanici_kitaplar_panel, kullaniciPanelListe);
        }

        private void kullanici_kirala_button_Click(object sender, EventArgs e)      //seçilen kitap kütüphanede ise kiralama işlemi yapar
        {
            {
                foreach (DataGridViewRow datagridviewrow in kullanici_kitaplar_dataGridView.SelectedRows)
                {
                    if (datagridviewrow.Cells["Kitap Durumu"].Value.ToString().Equals("Kütüphane"))
                    {
                        insan.kitapKirala(int.Parse(datagridviewrow.Cells["ID"].Value.ToString()));
                        MessageBox.Show("Kitap Kiralama Talebi Oluşturuldu!");
                        kitaplarToolStripMenuItem1_Click(sender, e);
                    }
                    else
                        MessageBox.Show("Seçilen Kitap Kiralanamaz!");
                }
            }
        }       

        private void kullanici_kitap_adi_textBox_TextChanged(object sender, EventArgs e)        //textbox içine göre datagridviewi filtreler
        {
            dgwFiltrele(kullanici_kitaplar_dataGridView, "Kitap İsmi", kullanici_kitaplar_kitapAdi_textBox.Text);
        }

        private void kullanici_yazar_textBox_TextChanged(object sender, EventArgs e)        //textbox içine göre datagridviewi filtreler
        {
            dgwFiltrele(kullanici_kitaplar_dataGridView, "Yazar", kullanici_kitaplar_yazar_textBox.Text);
        }

        private void kullanici_basimyili_textBox_TextChanged(object sender, EventArgs e)        //textbox içine göre datagridviewi filtreler
        {
            dgwFiltrele(kullanici_kitaplar_dataGridView, "Basım yılı", kullanici_kitaplar_basimyili_textBox.Text);
        }
        /*------------------------kitaplar------------------------*/

        /*-------------------------------kullanıcı_Panel------------------*/
        /*-------------------------------görevli_Panel--------------------*/

        private void gorevli_MenuCikis_Click(object sender, EventArgs e)      //çıkış yapar ,giriş panelini getirir, insan nesnesini insan kurucu metoduyla yeniden oluşturur(içi boş olur)
        {
            MessageBox.Show("Çıkış Yapıldı!");
            panelCagir(ana_Panel, panel_Liste);
            panelCagir(ana_Giris_Panel,anaPanel_Liste);
            insan = new Insan();
        }

        /*------------------------YeniKitap-----------------------*/

        private void gorevli_yeniKitapToolStripMenuItem_Click(object sender, EventArgs e)   //yeni kitap panelini ekrana getirir
        {
            gorevli_YeniKitap_kitapadi_textBox.Text = "";
            gorevli_YeniKitap_yazar_textBox.Text = "";
            gorevli_YeniKitap_basimyili_maskedTextBox.Text = "";
            gorevli_YeniKitap_dataGridView.DataSource = insan.kitapSorgula();
            panelCagir(gorevli_YeniKitap_Panel, gorevliPanel_Liste);
        }

        private void gorevli_YeniKitap_Button_Click(object sender, EventArgs e)     //yeni kitap ekler
        {
            insan.kitapEkle(gorevli_YeniKitap_kitapadi_textBox.Text, gorevli_YeniKitap_yazar_textBox.Text, gorevli_YeniKitap_basimyili_maskedTextBox.Text);
            gorevli_yeniKitapToolStripMenuItem_Click(sender,e);
        }

        /*------------------------YeniKitap-----------------------*/
        /*------------------------Talepler------------------------*/

        private void gorevli_taleplerToolStripMenuItem_Click(object sender, EventArgs e)        //talepler panelini açan menü tuşu, radiobutton ve datagridviewi günceller
        {
            panelCagir(gorevli_Talepler_Panel, gorevliPanel_Liste);
            gorevli_Talepler_Hepsi_radioButton.Checked = true;
            gorevli_Talepler_dataGridView.DataSource = insan.talepSorgula();
        }

        private void gorevli_Talepler_Hepsi_radioButton_CheckedChanged(object sender, EventArgs e)      //radiobutton seçilirse datagridviewi filtresiz günceller
        {
            foreach (DataGridViewRow dataGridViewRow in gorevli_Talepler_dataGridView.Rows)
                dataGridViewRow.Visible = true;
        }

        private void gorevli_Talepler_Yeni_radioButton_CheckedChanged(object sender, EventArgs e)       //seçilen radiobuttona göre datagridview günceller
        {
            dgwFiltrele(gorevli_Talepler_Yeni_radioButton, gorevli_Talepler_dataGridView, "İşlem", "Yeni");
        }

        private void gorevli_Talepler_Kira_radioButton_CheckedChanged(object sender, EventArgs e)       //seçilen radiobuttona göre datagridview günceller
        {
            dgwFiltrele(gorevli_Talepler_Kira_radioButton, gorevli_Talepler_dataGridView, "İşlem", "Kira");
        }

        private void gorevli_Talepler_Onaylandi_radioButton_CheckedChanged(object sender, EventArgs e)      //seçilen radiobuttona göre datagridview günceller
        {
            dgwFiltrele(gorevli_Talepler_Onaylandi_radioButton, gorevli_Talepler_dataGridView, "Durum", "Onaylandı");
        }

        private void gorevli_Talepler_Onaylanmadi_radioButton_CheckedChanged(object sender, EventArgs e)        //seçilen radiobuttona göre datagridview günceller
        {
            dgwFiltrele(gorevli_Talepler_Onaylanmadi_radioButton, gorevli_Talepler_dataGridView, "Durum", "Onaylanmadı");
        }
        private void gorevli_Talepler_Reddedildi_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            dgwFiltrele(gorevli_Talepler_Reddedildi_radioButton, gorevli_Talepler_dataGridView, "Durum", "Reddedildi");
        }

        private void gorevli_Talepler_Button_Click(object sender, EventArgs e)      //datagridview de seçilen hücreye göre onaylama işlemi yapar
        {
            foreach (DataGridViewRow dataGridViewRow in gorevli_Talepler_dataGridView.SelectedRows)
            {
                if (dataGridViewRow.Cells["Durum"].Value.ToString().Equals("Onaylanmadı"))
                {
                    switch (dataGridViewRow.Cells["İşlem"].Value.ToString())
                    {
                        case "Yeni":
                            insan.kitapEkle(int.Parse(dataGridViewRow.Cells["ID"].Value.ToString()));
                            MessageBox.Show("Yeni Kitap Ekleme Talebi Onyalandı!");
                            break;
                        case "Kira":
                            insan.kitapKirala(int.Parse(dataGridViewRow.Cells["ID"].Value.ToString()));
                            MessageBox.Show("Kiralama Talebi Onyalandı!");
                            break;
                    }

                    gorevli_taleplerToolStripMenuItem_Click(sender, e);
                }
                else
                    MessageBox.Show("Seçilen Talep Onaylanamaz!");
            }
        }

        private void gorevli_Talepler_Reddet_button_Click(object sender, EventArgs e)       //seçilen talebi reddeder
        {
            foreach (DataGridViewRow dataGridViewRow in gorevli_Talepler_dataGridView.SelectedRows)
            {
                if (dataGridViewRow.Cells["Durum"].Value.ToString().Equals("Onaylanmadı"))
                {
                    insan.sqlIslem("UPDATE Talep SET talepDurumu='Reddedildi' WHERE talep_id=" + int.Parse(dataGridViewRow.Cells["ID"].Value.ToString()));
                    MessageBox.Show("Seçilen Talep Reddedildi!");
                    gorevli_taleplerToolStripMenuItem_Click(sender, e);
                }
                else
                    MessageBox.Show("Seçilen Talep Reddedilemez!");
            }
        }
        /*------------------------Talepler------------------------*/
        /*------------------------bilgilerim----------------------*/
        private void bilgilerimToolStripMenuItem_Click(object sender, EventArgs e)      //bilgiler panelini ekrana getirir ve textbox textlerini classlardaki değişkenler ile doldurur
        {
            gorevli_bilgilerim_ad_textbox.Text = insan.isim;
            gorevli_bilgilerim_soyad_textbox.Text = insan.soyisim;
            gorevli_bilgilerim_tcno_textbox.Text = insan.tc;
            gorevli_bilgilerim_sifre_textbox.Text = insan.sifre;
            gorevli_bilgilerim_guvenlikelimesi_textbox.Text = insan.guvenlikKelimesi;
            panelCagir(gorevli_bilgilerim_panel, gorevliPanel_Liste);
        }
        private void gorevli_bilgilerimguncelle_button_Click(object sender, EventArgs e)        //textboxlardaki textler ile bilgileri günceller
        {
            insan.bilgiGuncelle(gorevli_bilgilerim_sifre_textbox.Text, gorevli_bilgilerim_ad_textbox.Text, gorevli_bilgilerim_soyad_textbox.Text, gorevli_bilgilerim_guvenlikelimesi_textbox.Text);
            MessageBox.Show("Bilgileriniz Guncellendi");
            insan.bilgiAl(insan.tc);
            gorevli_bilgilerimToolStripMenuItem.Text = insan.isim + " " + insan.soyisim;
            bilgilerimToolStripMenuItem_Click(sender, e);
        }
        /*------------------------bilgilerim----------------------*/
        /*------------------------Raporlar------------------------*/
        private void gorevli_Rapor_basımYili_textBox_KeyPress(object sender, KeyPressEventArgs e)    //basım yılı textbox içine sadece sayı girilmesini sağlar
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void raporlarToolStripMenuItem_Click_1(object sender, EventArgs e)        //panel içindeki textboxları boşaltır datagridviewi veritabanındaki tabloyla doldurur ve paneli çağırır
        {
            gorevli_Rapor_ad_textBox.Text = "";
            gorevli_Rapor_yazar_textBox.Text = "";
            gorevli_Rapor_basimYili_textBox.Text = "";
            gorevli_Rapor_dataGridView.DataSource = insan.raporSorgula();
            panelCagir(gorevli_Rapor_Panel,gorevliPanel_Liste);
        }

        private void gorevli_Rapor_ad_textBox_TextChanged(object sender, EventArgs e)                 //textbox içine yazıldıkça datagridviewi filtreler
        {
            dgwFiltrele(gorevli_Rapor_dataGridView,"İsim",gorevli_Rapor_ad_textBox.Text);
        }

        private void gorevli_Rapor_yazar_textBox_TextChanged(object sender, EventArgs e)                 //textbox içine yazıldıkça datagridviewi filtreler
        {
            dgwFiltrele(gorevli_Rapor_dataGridView, "Yazar", gorevli_Rapor_yazar_textBox.Text);
        }

        private void gorevli_Rapor_basimYili_textBox_TextChanged(object sender, EventArgs e)                 //textbox içine yazıldıkça datagridviewi filtreler
        {
            dgwFiltrele(gorevli_Rapor_dataGridView, "Basım Yılı", gorevli_Rapor_basimYili_textBox.Text);
        }


        /*------------------------Raporlar------------------------*/
        /*------------------------kitaplar------------------------*/
        private void gorevli_kitapsil_button_Click(object sender, EventArgs e)  //seçilen kitap kütüphanede ise silme işlemi yapar
        {
            foreach (DataGridViewRow datagridviewrow in gorevli_kitaplar_dataGridView.SelectedRows)
            {
                if (datagridviewrow.Cells["Kitap Durumu"].Value.ToString().Equals("Kütüphane"))
                {
                    insan.kitapSil(int.Parse(datagridviewrow.Cells["ID"].Value.ToString()));
                    MessageBox.Show("Kitap Silindi!");
                    kitaplarToolStripMenuItem_Click(sender, e);
                }
                else
                    MessageBox.Show("Seçilen Kitap Silinemez!");
            }
        }

        private void kitaplarToolStripMenuItem_Click(object sender, EventArgs e)        //kitaplar panelini ekrana getirir
        {
            gorevli_kitaplar_kitapAdi_textBox.Text = "";
            gorevli_kitaplar_yazar_textBox.Text = "";
            gorevli_kitaplar_basimyili_textBox.Text = "";
            gorevli_kitaplar_dataGridView.DataSource = insan.kitapSorgula();
            panelCagir(gorevli_kitaplar_panel, gorevliPanel_Liste);
        }

        private void gorevli_kitap_adi_textBox_TextChanged(object sender, EventArgs e)      //textbox içine göre datagridviewi filtreler
        {
            dgwFiltrele(gorevli_kitaplar_dataGridView, "Kitap İsmi", gorevli_kitaplar_kitapAdi_textBox.Text);
        }

        private void gorevli_yazar_textBox_TextChanged(object sender, EventArgs e)          //textbox içine göre datagridviewi filtreler
        {
            dgwFiltrele(gorevli_kitaplar_dataGridView, "Yazar", gorevli_kitaplar_yazar_textBox.Text);
        }

        private void gorevli_basim_yili_textBox_TextChanged(object sender, EventArgs e)     //textbox içine göre datagridviewi filtreler
        {
            dgwFiltrele(gorevli_kitaplar_dataGridView, "Basım Yılı", gorevli_kitaplar_basimyili_textBox.Text);
        }
        /*------------------------kitaplar------------------------*/
        /*------------------------insanlar------------------------*/
        private void gorevli_insanlarToolStripMenuItem_Click(object sender, EventArgs e)        //insanlar panelini ekrana getirir
        {
            gorevli_insanlar_isim_textBox.Text = "";
            gorevli_insanlar_soyisim_textBox.Text = "";
            gorevli_insanlar_dataGridView.DataSource = insan.insanSorgula();
            panelCagir(gorevli_Panel, panel_Liste);
            panelCagir(gorevli_insanlar_panel,gorevliPanel_Liste);
        }

        private void gorevli_insanlar_insanEkle_button_Click(object sender, EventArgs e)        //insan ekleme butonuna basıldığında yeni kayıt panelini ekrana getirir
        {
            ana_girisYeniKayit_Label_Click(sender,e);
        }

        private void gorevli_insanlar_isim_textBox_TextChanged(object sender, EventArgs e)      //textbox textindeki değer ile datagridviewi fitreler
        {
            dgwFiltrele(gorevli_insanlar_dataGridView,"İsim",gorevli_insanlar_isim_textBox.Text);
        }

        private void gorevli_insanlar_soyisim_textBox_TextChanged(object sender, EventArgs e)      //textbox textindeki değer ile datagridviewi fitreler
        {
            dgwFiltrele(gorevli_insanlar_dataGridView, "Soyisim", gorevli_insanlar_soyisim_textBox.Text);
        }

        private void gorevli_insanlar_kAta_button_Click(object sender, EventArgs e)             //seçilen kayıdı kullanıcı olarak atar
        {
            foreach (DataGridViewRow dataGridViewRow in gorevli_insanlar_dataGridView.SelectedRows)
            {
                if (!dataGridViewRow.Cells["ID"].Value.ToString().Equals(insan.insan_id.ToString()))
                {
                    if (dataGridViewRow.Cells["Durum"].Value.ToString().Equals("Görevli"))
                    {
                        insan.kullaniciAta(int.Parse(dataGridViewRow.Cells["ID"].Value.ToString()));
                        MessageBox.Show("Seçilen Kayıt Kullanıcı Olarak Atandı!");
                        gorevli_insanlarToolStripMenuItem_Click(sender, e);
                    }
                    else
                        MessageBox.Show("Seçilen Kayıt Kullanıcı Olarak Atanamıyor!");
                }
                else
                    MessageBox.Show("Kendi Durumunuzu Değiştiremezsiniz!");
            }
        }

        private void gorevli_insanlar_gAta_button_Click(object sender, EventArgs e)             //seçilen kayıdı görevli olarak atar
        {
            foreach (DataGridViewRow dataGridViewRow in gorevli_insanlar_dataGridView.SelectedRows)
            {
                if (!dataGridViewRow.Cells["ID"].Value.ToString().Equals(insan.insan_id.ToString()))
                {
                    if (dataGridViewRow.Cells["Durum"].Value.ToString().Equals("Kullanıcı"))
                    {
                        insan.gorevliAta(int.Parse(dataGridViewRow.Cells["ID"].Value.ToString()));
                        MessageBox.Show("Seçilen Kayıt Görevli Olarak Atandı!");
                        gorevli_insanlarToolStripMenuItem_Click(sender, e);
                    }
                    else
                        MessageBox.Show("Seçilen Kayıt Görevli Olarak Atanamıyor!");
                }
                else
                    MessageBox.Show("Kendi Durumunuzu Değiştiremezsiniz!");
            }
        }
        /*------------------------insanlar------------------------*/
        /*-------------------------------görevli_Panel--------------------*/
    }
}