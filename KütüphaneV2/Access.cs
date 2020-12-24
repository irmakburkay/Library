using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace KütüphaneV2
{
    public abstract class Access : Veritabanı
    {
        public readonly static OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=KütüphaneV2.mdb");
        public readonly static OleDbCommand komut = new OleDbCommand();
        public static OleDbDataAdapter adaptor;

        public Access()                         //komut nesnesinin veritabanı ile bağlantısını yapar
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
    }
}
