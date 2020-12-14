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
        public Kullanici(String tc, String sifre, String isim, String soyisim, String guvenlikKelimesi) : base()    //yeni kayıt yapan kullanıcı
        {
            insanEkle(tc, sifre, isim, soyisim, guvenlikKelimesi);                                                  //yeni kaydı veritabanına kaydeder
            bilgiAl(tc);                                                                                            //tc numarasına göre kullanıcı bilgilerini class değişkenlerine atar
        }   

        public Kullanici(String tc) : base()                                                                        //kayıtlı kullanıcı girişi
        {                                                                                                           //tc numarasına göre kullanıcı bilgilerini class değişkenlerine atar;
            bilgiAl(tc);
        }

        public Kullanici(Insan insan, String sifre, String isim, String soyisim, String guvenlikKelimesi) : this(insan.tc)          //daha önceden silinmiş kayıt ile yeni kullanıcı oluşturur
        {
            baglanti.Open();
            komut.CommandText = "UPDATE Insan SET insanDurumu='Kullanıcı' WHERE insan_id=" + insan.insan_id;
            komut.ExecuteNonQuery();
            baglanti.Close();
            bilgiGuncelle(insan, sifre, isim, soyisim, guvenlikKelimesi);
            bilgiAl(insan.tc);
        }

        public override void insanSil(Insan insan)                                                                      //sadece kullanıcı nesnelerini silebilir
        {
            if (insan is Kullanici)
            {
                baglanti.Open();
                komut.CommandText = "UPDATE Insan SET insanDurumu='Silinmiş' WHERE insan_id=" + insan.insan_id;
                komut.ExecuteNonQuery();
                baglanti.Close(); 
            }
        }

        public override void insanEkle(String tc, String sifre, String isim, String soyisim, String guvenlikKelimesi)  //parametrelerle veritabanında yeni kullanıcı oluşturur
        {
            baglanti.Open();
            komut.CommandText = "INSERT INTO Insan (tc,şifre,isim,soyisim,güvenlikKelimesi,insanDurumu) " +
                "VALUES ('" + tc + "','" + sifre + "','" + isim + "','" + soyisim + "','" + guvenlikKelimesi + "','Kullanıcı')";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public override DataTable kitapSorgula()                //kütüphanede veya kullanıcıda olan kitapları sorgular DataTable olarak çevirir (dataGridView.DataSource=DataTable)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            komut.CommandText = "SELECT kitap_id as [ID], isim as [Kitap İsmi], yazar as [Yazar], basımYılı as [Basım Yılı], kitapDurumu as [Kitap Durumu] " +
                "FROM Kitap WHERE kitapDurumu='Kütüphane' OR kitapDurumu='Kullanıcı'";
            adaptor = new OleDbDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;
        }

        public override DataTable raporSorgula()                //kullanıcı insan_id numarası ile sadece kendi kira/iade raporlarını görüntüler
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            komut.CommandText = "SELECT Rapor.rapor_id as [ID], Insan.tc AS [TCKN], Insan.isim AS [Ad], Insan.soyisim AS [Soyad], Insan.insanDurumu AS [Durum], " +
                "Kitap.isim AS [İsim], Kitap.yazar AS [Yazar], Kitap.basımYılı AS [Basım Yılı], " +
                "Rapor.kiraTarihi AS [Kira Tarihi], Rapor.iadeTarihi AS [İade Tarihi], Rapor.cezaTutarı AS [Geciktirme Cezası]" +
                "FROM Insan, Kitap, Rapor " +
                "WHERE Insan.insan_id="+this.insan_id+" AND Rapor.insan_id=Insan.insan_id and Rapor.kitap_id=Kitap.kitap_id";
            adaptor = new OleDbDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;
        }

        public override void raporGuncelle(long kitap_id, DateTime kiraTarihi, DateTime iadeTarihi, double cezaTutari)               //kullanıcı tarafından çağırılır kitap_id parametresi alır (kitap_id bilinmiyorsa Insan.kitapBilgiAl fonksiyonuyla bulunabilir) kiralama tarihini datetime olarak alır girilen iade tarihi ve ceza tutarı ile raporu günceller
        {
            baglanti.Open();
            komut.CommandText = "UPDATE Rapor SET iadeTarihi=#" + iadeTarihi.Month.ToString() + "/" + iadeTarihi.Day.ToString() + "/" + iadeTarihi.Year.ToString() + "#, cezaTutarı='" + cezaTutari + "' WHERE insan_id = " + this.insan_id + " AND kitap_id = " + kitap_id + " AND kiraTarihi =#" + kiraTarihi.Month.ToString() + "/" + kiraTarihi.Day.ToString() + "/" + kiraTarihi.Year.ToString() + "#";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

    }
}