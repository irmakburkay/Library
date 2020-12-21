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
        public Gorevli(String tc)                                                               //kayıtlı görevli girişi
        {
            bilgiAl(tc);                                                                        //tc bilgisiyle görevli bilgilerini class değişkenlerine atar
        }

        public override void insanEkle(String tc, String sifre, String isim, String soyisim, String guvenlikKelimesi)   //parametrelerle veritabanında yeni görevli oluşturur
        {

            String sql = "INSERT INTO Insan (tc,şifre,isim,soyisim,güvenlikKelimesi,insanDurumu) " +
                "VALUES ('" + tc + "','" + sifre + "','" + isim + "','" + soyisim + "','" + guvenlikKelimesi + "','Görevli')";
            sqlIslem(sql);
        }

        public override DataTable insanSorgula()                     //tüm insanları görüntüler (tc/şifre/güvenlik kelimesi hariç)
        {
            String sql = "SELECT insan_id as [ID], isim as [İsim], soyisim as [Soyisim], insanDurumu as [Durum] FROM Insan";
            return sqlTablo(sql);
        }

        public override DataTable kitapSorgula()            //tüm kitapları sorgular DataTable olarak çevirir (dataGridView.DataSource=DataTable)
        {
            String sql = "SELECT kitap_id as [ID], isim as [Kitap İsmi],yazar as [Yazar],basımYılı as [Basım Yılı],kitapDurumu as [Kitap Durumu] FROM Kitap";
            return sqlTablo(sql);
        }
        public override DataTable raporSorgula()            //tüm kitap kira/iade raporlarını görüntüler
        {
            String sql = "SELECT Rapor.rapor_id as [ID], Insan.tc AS [TCKN], Insan.isim AS [Ad], Insan.soyisim AS [Soyad], Insan.insanDurumu AS [Durum], " +
                "Kitap.isim AS [İsim], Kitap.yazar AS [Yazar], Kitap.basımYılı AS [Basım Yılı], " +
                "Rapor.kiraTarihi AS [Kira Tarihi], Rapor.iadeTarihi AS [İade Tarihi], Rapor.cezaTutarı AS [Geciktirme Cezası]" +
                "FROM Insan, Kitap, Rapor " +
                "WHERE Rapor.insan_id=Insan.insan_id and Rapor.kitap_id=Kitap.kitap_id";
            return sqlTablo(sql);
        }

        public override DataTable talepSorgula()                                //görevli için yeni kitap talepleri, kiralama talepleri, iade talepleri tablosunu DataTable olarak çevirir
        {
            String sql = "SELECT talep_id as [ID],işlem as [İşlem], talepTarihi as [Tarih], " +
                "Insan.isim as [Ad], Insan.soyisim as [Soyisim], " +
                "kitap_isim as [İsim], kitap_yazar as [Yazar], kitap_basımYılı as [Basım Yılı], " +
                "talepDurumu as [Durum] FROM (Talep LEFT JOIN Kitap ON Talep.kitap_id=Kitap.kitap_id) " +
                "LEFT JOIN Insan ON Talep.insan_id=Insan.insan_id";
            return sqlTablo(sql);
        }

        public override void kitapEkle(String isim,String yazar,String basımYili)    //yeni kitap ekler     
        {
            sqlIslem("INSERT INTO Kitap (isim,yazar,basımYılı,kitapDurumu) VALUES ('" + isim + "','" + yazar + "','" + basımYili + "','Kütüphane')");
        }

        public override void kitapSil(long kitap_id)                 //kitap_id numarası ile kitap durumunu atılmış olarak değiştirir
        {
            sqlIslem("UPDATE Kitap SET kitapDurumu='Atılmış' WHERE kitap_id=" + kitap_id);
        }

        public override void kitapEkle(long talep_id)                               //talep_id parametresi gönderilen yeni kitabı Kitap tablosuna ekler, Kitap tablosundaki kitap_id numarasını Talep tablosuna ekler ve durumu "Onaylandı" olarak düzenler
        {
            String kitap_isim = sqlString("SELECT kitap_isim FROM Talep WHERE talep_id=" + talep_id);
            String kitap_yazar = sqlString("SELECT kitap_yazar FROM Talep WHERE talep_id=" + talep_id);
            String kitap_basimYili = sqlString("SELECT kitap_basımYılı FROM Talep WHERE talep_id=" + talep_id);
            kitapEkle(kitap_isim, kitap_yazar, kitap_basimYili);
            sqlIslem("UPDATE Talep SET kitap_id=" + kitapBilgiAl(kitap_isim, kitap_yazar, kitap_basimYili) + ",talepDurumu='Onaylandı' WHERE talep_id=" + talep_id);
        }

        public override void kitapKirala(long talep_id)             //talep_id ile Talep tablosundan kitap_id ve insan_id alır, kiralama işlemini rapora ekler, kitap durumunu "Kullanıcı" olarak değiştirir ve talep durumunu "Onaylandı" olarak düzenler
        {
            long kitap_id = int.Parse(sqlString("SELECT kitap_id FROM Talep WHERE talep.id=" + talep_id));
            long insan_id = int.Parse(sqlString("SELECT insan_id FROM Talep WHERE talep.id=" + talep_id));
            raporEkle(insan_id, kitap_id, DateTime.Today);
            sqlIslem("UPDATE Kitap SET kitapDurumu='Kullanıcı' WHERE kitap_id=" + kitap_id);
            sqlIslem("UPDATE Talep SET talepDurumu='Onaylandı' WHERE talep_id=" + talep_id);
        }

        public override void raporEkle(long insan_id,long kitap_id,DateTime kiraTarihi)        //insan nesnesi kitap_id ve kira tarihi olarak parametre alır ve Rapor tablosuna yeni kayıt ekler
        {
            String sql = "INSERT INTO Rapor (kitap_id,insan_id,kiraTarihi) " +
                "VALUES (" + kitap_id + "," + insan_id + ",#" + kiraTarihi.Month.ToString() + "/" + kiraTarihi.Day.ToString() + "/" + kiraTarihi.Year.ToString() + "#)";
            sqlIslem(sql);
        }

        public override void gorevliAta(long insan_id)         //insan_id parametresiyle görevli atama
        {
            sqlIslem("UPDATE Insan SET insanDurumu='Görevli' WHERE insan_id=" + insan_id);
        }

        public override void kullaniciAta(long insan_id)       //insan_id parametresiyle kullanıcı atama
        {
            sqlIslem("UPDATE Insan SET insanDurumu='Kullanıcı' WHERE insan_id=" + insan_id);
        }
    }
}
