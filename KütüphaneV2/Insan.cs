using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace KütüphaneV2
{
    public class Insan:Veritabanı
    {
        public readonly static OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=KütüphaneV2.mdb");
        public readonly static OleDbCommand komut = new OleDbCommand();
        public static OleDbDataAdapter adaptor;

        public long insan_id;
        public String tc, sifre, isim, soyisim, guvenlikKelimesi;

        public Insan()                                                                                                      //komut nesnesini veritabanına bağlar
        {
            komut.Connection = baglanti;
        }

        public void bilgiAl(String tc)                                                                                      //tc numarası verilen kullanıcının bilgilerini class değişkenlerine atar
        {
            baglanti.Open();
            komut.CommandText = "SELECT count(*) FROM Insan WHERE tc='" + tc + "'";
            if (komut.ExecuteScalar().ToString() != "0")
            {
                komut.CommandText = "SELECT insan_id FROM Insan WHERE tc='" + tc + "'";
                insan_id = int.Parse(komut.ExecuteScalar().ToString());
                komut.CommandText = "SELECT tc FROM Insan WHERE tc='" + tc + "'";
                this.tc = komut.ExecuteScalar().ToString();
                komut.CommandText = "SELECT şifre FROM Insan WHERE tc='" + tc + "'";
                sifre = komut.ExecuteScalar().ToString();
                komut.CommandText = "SELECT isim FROM Insan WHERE tc='" + tc + "'";
                isim = komut.ExecuteScalar().ToString();
                komut.CommandText = "SELECT soyisim FROM Insan WHERE tc='" + tc + "'";
                soyisim = komut.ExecuteScalar().ToString();
                komut.CommandText = "SELECT güvenlikKelimesi FROM Insan WHERE tc='" + tc + "'";
                guvenlikKelimesi = komut.ExecuteScalar().ToString();
            }
            else
                MessageBox.Show(tc + " numaralı kullanıcı bulunmamaktadır");
            baglanti.Close();
        }

        public void bilgiGuncelle(Insan insan, String sifre, String isim, String soyisim, String guvenlikKelimesi)          //kullanıcının parametre olarak girilen tüm bilgilerini günceller
        {
            baglanti.Open();
            komut.CommandText = "UPDATE Insan SET şifre='" + sifre + "',isim='" + isim + "',soyisim='" + soyisim + "',güvenlikKelimesi='" + guvenlikKelimesi + "' WHERE insan_id=" + insan.insan_id;
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public String sifremiUnuttum(String tc, String guvenlikKelimesi)                                                    //tc numarası ve güvenlikSorusu verilen kullanıcının şifresini çevirir
        {
            String sifre;
            baglanti.Open();
            komut.CommandText = "SELECT şifre FROM Insan WHERE tc='" + tc + "' AND güvenlikKelimesi='" + guvenlikKelimesi + "'";
            sifre = komut.ExecuteScalar().ToString();
            baglanti.Close();
            return sifre;
        }

        public long kitapBilgiAl(String isim, String yazar, String basımYili)           //ismi yazarı basım yılı verilen kitabın kitap_id numarasını çevirir
        {
            long kitap_id;
            baglanti.Open();
            komut.CommandText = "SELECT kitap_id FROM Kitap WHERE isim='" + isim + "' AND yazar='" + yazar + "' AND basımYılı='" + basımYili + "'";
            kitap_id = int.Parse(komut.ExecuteScalar().ToString());
            baglanti.Close();
            return kitap_id;
        }


        public virtual void insanEkle(String tc, String sifre, String isim, String soyisim, String guvenlikKelimesi) { }
        public virtual void insanSil(Insan insan) { }
        public virtual DataTable kitapSorgula() { return null; }
        public virtual DataTable raporSorgula() { return null; }
        public virtual DataTable insanSorgula() { return null; }
        public virtual void gorevliAta(Insan insan) { }
        public virtual void gorevliAta(String tc) { }
        public virtual void kullaniciAta(Insan insan) { }
        public virtual void kullaniciAta(String tc) { }
        public virtual void kitapEkle(String isim, String yazar, String basımYili) { }
        public virtual void kitapSil(long kitap_id) { }
        public virtual void raporEkle(Insan insan, long kitap_id, DateTime kiraTarihi) { }
        public virtual void raporGuncelle(long kitap_id, DateTime kiraTarihi, DateTime iadeTarihi, double cezaTutari) { }
    }
}
