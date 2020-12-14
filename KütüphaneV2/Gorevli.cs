using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace KütüphaneV2
{
    public class Gorevli:Insan
    {
        public Gorevli(String tc):base()                                                        //kayıtlı görevli girişi
        {
            bilgiAl(tc);                                                                        //tc bilgisiyle görevli bilgilerini class değişkenlerine atar
        }

        public override void insanSil(Insan insan)                                                                      //insan parametresiyle hem kullanıcı hem görevli silme
        {
            baglanti.Open();
            komut.CommandText = "UPDATE Insan SET insanDurumu='Silinmiş' WHERE insan_id=" + insan.insan_id;
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public override void insanEkle(String tc, String sifre, String isim, String soyisim, String guvenlikKelimesi)   //parametrelerle veritabanında yeni kullanıcı oluşturur
        {

            baglanti.Open();
            komut.CommandText = "INSERT INTO Insan (tc,şifre,isim,soyisim,güvenlikKelimesi,insanDurumu) " +
                "VALUES ('" + tc + "','" + sifre + "','" + isim + "','" + soyisim + "','" + guvenlikKelimesi + "','Görevli')";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public override DataTable raporSorgula()            //tüm kitap kira/iade raporlarını görüntüler
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            komut.CommandText = "SELECT Rapor.rapor_id as [ID], Insan.tc AS [TCKN], Insan.isim AS [Ad], Insan.soyisim AS [Soyad], Insan.insanDurumu AS [Durum], " +
                "Kitap.isim AS [İsim], Kitap.yazar AS [Yazar], Kitap.basımYılı AS [Basım Yılı], " +
                "Rapor.kiraTarihi AS [Kira Tarihi], Rapor.iadeTarihi AS [İade Tarihi], Rapor.cezaTutarı AS [Geciktirme Cezası]" +
                "FROM Insan, Kitap, Rapor " +
                "WHERE Rapor.insan_id=Insan.insan_id and Rapor.kitap_id=Kitap.kitap_id";
            adaptor = new OleDbDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;
        }

        public override void gorevliAta(Insan insan)         //kullanıcı nesnesi parametresiyle görevli atama
        {
            baglanti.Open();
            komut.CommandText = "UPDATE Insan SET insanDurumu='Görevli' WHERE insan_id=" + insan.insan_id;
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public override void gorevliAta(String tc)                   //tc no ile görevli atama
        {
            baglanti.Open();
            komut.CommandText = "UPDATE Insan SET insanDurumu='Görevli' WHERE tc='" + tc + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public override void kullaniciAta(Insan insan)       //kullanıcı nesnesi parametresiyle kullanıcı atama
        {
            baglanti.Open();
            komut.CommandText = "UPDATE Insan SET insanDurumu='Kullanıcı' WHERE insan_id=" + insan.insan_id;
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public override void kullaniciAta(String tc)                 //tc no ile kullanıcı atama
        {
            baglanti.Open();
            komut.CommandText = "UPDATE Insan SET insanDurumu='Kullanıcı' WHERE tc='" + tc + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public override DataTable insanSorgula()                     //tüm insanları görüntüler (tc/şifre/güvenlik kelimesi hariç)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            komut.CommandText = "SELECT insan_id as [ID], isim as [İsim], soyisim as [Soyisim], insanDurumu as [Durum] FROM Insan"; 
            adaptor = new OleDbDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;
        }

        public override DataTable kitapSorgula()            //tüm kitapları sorgular DataTable olarak çevirir (dataGridView.DataSource=DataTable)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            komut.CommandText = "SELECT kitap_id as [ID], isim as [Kitap İsmi],yazar as [Yazar],basımYılı as [Basım Yılı],kitapDurumu as [Kitap Durumu] FROM Kitap";
            adaptor = new OleDbDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;
        }

        public override void kitapEkle(String isim,String yazar,String basımYili)    //yeni kitap ekler     
        {
            baglanti.Open();
            komut.CommandText = "INSERT INTO Kitap (isim,yazar,basımYılı,kitapDurumu) VALUES ('" + isim + "','" + yazar + "','" + basımYili + "','Kütüphane')";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public override void kitapSil(long kitap_id)                 //kitap_id numarası ile kitap durumunu atılmış olarak değiştirir
        {
            baglanti.Open();
            komut.CommandText = "UPDATE Kitap SET kitapDurumu='Atılmış' WHERE kitap_id=" + kitap_id;
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public override void raporEkle(Insan insan,long kitap_id,DateTime kiraTarihi)        //insan nesnesi kitap_id ve kira tarihi olarak parametre alır ve Rapor tablosuna yeni kayıt ekler
        {
            baglanti.Open();
            komut.CommandText = "INSERT INTO Rapor (kitap_id,insan_id,kiraTarihi) " +
                "VALUES (" + kitap_id + "," + insan.insan_id + ",#" + kiraTarihi.Month.ToString() + "/" + kiraTarihi.Day.ToString() + "/" + kiraTarihi.Year.ToString() + "#)";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
