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
    public interface Veritabanı
    {
        void bilgiAl(String tc);
        void bilgiGuncelle(Insan insan, String sifre, String isim, String soyisim, String guvenlikKelimesi);
        String sifremiUnuttum(String tc, String guvenlikKelimesi);
        long kitapBilgiAl(String isim, String yazar, String basımYili);
        void insanEkle(String tc, String sifre, String isim, String soyisim, String guvenlikKelimesi);
        void insanSil(Insan insan);
        DataTable kitapSorgula();
        DataTable raporSorgula();
        DataTable insanSorgula();
        void gorevliAta(Insan insan);
        void gorevliAta(String tc);
        void kullaniciAta(Insan insan);
        void kullaniciAta(String tc);
        void kitapEkle(String isim, String yazar, String basımYili);
        void kitapSil(long kitap_id);
        void raporEkle(Insan insan, long kitap_id, DateTime kiraTarihi);
        void raporGuncelle(long kitap_id, DateTime kiraTarihi, DateTime iadeTarihi, double cezaTutari);

    }
}
