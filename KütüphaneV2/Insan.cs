using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void sqlIslem(String sql)        //void sql komut çalıştıran fonksiyon
        {
            komut.CommandText = sql;
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public DataTable sqlTablo(String sql)       //DataTable sql komut çalıştıran fonksiyon
        {
            DataTable tablo = new DataTable();
            komut.CommandText = sql;
            baglanti.Open();
            adaptor = new OleDbDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;
        }

        public String sqlString(String sql)     //String sql komut çalıştıran fonksiyon
        {
            komut.CommandText = sql;
            baglanti.Open();
            String str = komut.ExecuteScalar().ToString();
            baglanti.Close();
            return str;
        }

        public void bilgiAl(String tc)                                                                                      //tc numarası varsa, verilen kullanıcının bilgilerini class değişkenlerine atar
        {                                                                                                                   
            if (sqlString("SELECT count(*) FROM Insan WHERE tc='" + tc + "'") != "0")
            {
                insan_id = int.Parse(sqlString("SELECT insan_id FROM Insan WHERE tc='" + tc + "'"));
                this.tc = sqlString("SELECT tc FROM Insan WHERE tc='" + tc + "'");
                sifre = sqlString("SELECT şifre FROM Insan WHERE tc='" + tc + "'");
                isim = sqlString("SELECT isim FROM Insan WHERE tc='" + tc + "'");
                soyisim = sqlString("SELECT soyisim FROM Insan WHERE tc='" + tc + "'");
                guvenlikKelimesi = sqlString("SELECT güvenlikKelimesi FROM Insan WHERE tc='" + tc + "'");
            }
        }

        public void bilgiGuncelle(String sifre, String isim, String soyisim, String guvenlikKelimesi)          //kullanıcının parametre olarak girilen tüm bilgilerini günceller
        {
            sqlIslem("UPDATE Insan SET şifre='" + sifre + "',isim='" + isim + "',soyisim='" + soyisim + "',güvenlikKelimesi='" + guvenlikKelimesi + "' WHERE insan_id=" + insan_id);
        }

        public String insanDurumu()                                                                                        //insan_id numarası ile kaydın kullanıcı mı görevli mi olduğunu string olarak çevirir
        {
            return sqlString("SELECT insanDurumu FROM Insan WHERE insan_id=" + insan_id);
        }

        public long kitapIdAl(String isim, String yazar, String basımYili)           //ismi yazarı basım yılı verilen kitabın kitap_id numarasını çevirir
        {
            return int.Parse(sqlString("SELECT kitap_id FROM Kitap WHERE isim='" + isim + "' AND yazar='" + yazar + "' AND basımYılı='" + basımYili + "'"));
        }

        public void talepEkle(String isim, String yazar, String basımYili)     //parametrelerle yeni kitap Talep kayıdı oluşturur
        {
            String sql = "INSERT INTO Talep (talepTarihi,işlem,insan_id,kitap_isim,kitap_yazar,kitap_basımYılı,talepDurumu) " +
                "VALUES (#" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString() + "#," +
                "'Yeni'," + this.insan_id + ",'" + isim + "','" + yazar + "','" + basımYili + "','Onaylanmadı')";
            sqlIslem(sql);
        }

        public void talepEkle(String islem, long kitap_id, String isim, String yazar, String basımYili)     //parametrelerle kira/iade Talep kayıdı oluşturur
        {
            String sql = "INSERT INTO Talep (talepTarihi,işlem,insan_id,kitap_id,kitap_isim,kitap_yazar,kitap_basımYılı,talepDurumu) " +
                "VALUES (#" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString() + "#," +
                "'" + islem + "'," + this.insan_id + "," + kitap_id + ",'" + isim + "','" + yazar + "','" + basımYili + "','Onaylanmadı')";
            sqlIslem(sql);
        }

        public virtual void insanEkle(String tc, String sifre, String isim, String soyisim, String guvenlikKelimesi) { }
        public virtual void gorevliAta(long insan_id) { }
        public virtual void kullaniciAta(long insan_id) { }
        public virtual DataTable kitapSorgula() { return null; }
        public virtual DataTable raporSorgula() { return null; }
        public virtual DataTable insanSorgula() { return null; }
        public virtual DataTable talepSorgula() { return null; }
        public virtual void kitapEkle(String isim, String yazar, String basımYili) { }
        public virtual void kitapSil(long kitap_id) { }
        public virtual void kitapEkle(long talep_id) { }
        public virtual void kitapKirala(long id) { }
        public virtual void kitapIade(long rapor_id, double cezaTutarı) { }
        public virtual void raporEkle(long insan_id, long kitap_id, DateTime kiraTarihi) { }
        public virtual void raporGuncelle(long rapor_id, DateTime iadeTarihi, double cezaTutari) { }
    }
}
