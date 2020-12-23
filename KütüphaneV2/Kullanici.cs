using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace KütüphaneV2
{
    public class Kullanici:Insan
    {
        public Kullanici(String tc, String sifre, String isim, String soyisim, String guvenlikKelimesi):base()      //yeni kayıt yapan kullanıcı
        {
            insanEkle(tc, sifre, isim, soyisim, guvenlikKelimesi);                                                  //yeni kaydı veritabanına kaydeder
            bilgiAl(tc);                                                                                            //tc numarasına göre kullanıcı bilgilerini class değişkenlerine atar
        }   

        public Kullanici(String tc):base()                                                                          //kayıtlı kullanıcı girişi
        {                                                                                                           //tc numarasına göre kullanıcı bilgilerini class değişkenlerine atar;
            bilgiAl(tc);
        }

        public override void insanEkle(String tc, String sifre, String isim, String soyisim, String guvenlikKelimesi)  //parametrelerle veritabanında yeni kullanıcı oluşturur
        {
            String sql = "INSERT INTO Insan (tc,şifre,isim,soyisim,güvenlikKelimesi,insanDurumu) " +
                "VALUES ('" + tc + "','" + sifre + "','" + isim + "','" + soyisim + "','" + guvenlikKelimesi + "','Kullanıcı')";
            sqlIslem(sql);
        }

        public override DataTable kitapSorgula()                //kütüphanede veya kullanıcıda olan kitapları sorgular DataTable olarak çevirir (dataGridView.DataSource=DataTable)
        {
            String sql = "SELECT kitap_id as [ID], isim as [Kitap İsmi], yazar as [Yazar], basımYılı as [Basım Yılı], kitapDurumu as [Kitap Durumu] " +
                "FROM Kitap WHERE kitapDurumu='Kütüphane' OR kitapDurumu='Kullanıcı'";
            return sqlTablo(sql);
        }

        public override DataTable raporSorgula()                //kullanıcı insan_id numarası ile sadece kendi kira/iade raporlarını görüntüler
        {
            String sql = "SELECT Rapor.rapor_id as [ID], " +
                "Kitap.isim AS [İsim], Kitap.yazar AS [Yazar], Kitap.basımYılı AS [Basım Yılı], " +
                "Rapor.kiraTarihi AS [Kira Tarihi], Rapor.iadeTarihi AS [İade Tarihi], Rapor.cezaTutarı AS [Geciktirme Cezası]" +
                "FROM Insan, Kitap, Rapor " +
                "WHERE Insan.insan_id=" + this.insan_id + " AND Rapor.insan_id=Insan.insan_id AND Rapor.kitap_id=Kitap.kitap_id";
            return sqlTablo(sql);
        }

        public override DataTable talepSorgula()                                //kullanıcı için kendi oluşturduğu yeni kitap talepleri, kiralama talepleri, iade talepleri tablosunu DataTable olarak çevirir
        {
            String sql = "SELECT talep_id as [ID],işlem as [İşlem], talepTarihi as [Tarih], " +
                "Insan.isim as [Ad], Insan.soyisim as [Soyisim], " +
                "kitap_isim as [İsim], kitap_yazar as [Yazar], kitap_basımYılı as [Basım Yılı], " +
                "talepDurumu as [Durum] FROM (Talep LEFT JOIN Kitap ON Talep.kitap_id=Kitap.kitap_id) " +
                "LEFT JOIN Insan ON (Talep.insan_id=Insan.insan_id AND Talep.insan_id=" + this.insan_id + ")";
            return sqlTablo(sql);
        }

        public override void raporGuncelle(long rapor_id, DateTime iadeTarihi, double cezaTutari)               //kullanıcı tarafından çağırılır kitap_id parametresi alır (kitap_id bilinmiyorsa Insan.kitapBilgiAl fonksiyonuyla bulunabilir) kiralama tarihini datetime olarak alır girilen iade tarihi ve ceza tutarı ile raporu günceller
        {
            String sql = "UPDATE Rapor SET iadeTarihi=#" + iadeTarihi.Month.ToString() + "/" + iadeTarihi.Day.ToString() + "/" + iadeTarihi.Year.ToString() + "#, cezaTutarı='" + cezaTutari + "' WHERE rapor_id=" + rapor_id;
            sqlIslem(sql);
        }

        public override void kitapEkle(String isim, String yazar, String basımYili)     //parametrelerle yeni kitap Talep kayıdı oluşturur
        {
            talepEkle(isim, yazar, basımYili);
        }

        public override void kitapKirala(long kitap_id)                                       //verilen kitap_id parametresi ile kitap kiralama talebi oluşturur
        {
            String kitap_isim = sqlString("SELECT isim FROM Kitap WHERE kitap_id=" + kitap_id);
            String kitap_yazar = sqlString("SELECT yazar FROM Kitap WHERE kitap_id=" + kitap_id);
            String kitap_basimYili = sqlString("SELECT basımYılı FROM Kitap WHERE kitap_id=" + kitap_id);
            talepEkle("Kira", kitap_id, kitap_isim, kitap_yazar, kitap_basimYili);
        }

        public override void kitapIade(long rapor_id,double cezaTutari)
        {
            raporGuncelle(rapor_id, DateTime.Today, cezaTutari);
            sqlIslem("UPDATE Kitap,Rapor SET Kitap.kitapDurumu='Kütüphane' WHERE Rapor.rapor_id=" + rapor_id + " AND Rapor.kitap_id=Kitap.kiatp_id");
        }
    }
}