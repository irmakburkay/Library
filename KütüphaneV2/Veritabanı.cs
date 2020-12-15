using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KütüphaneV2
{
    public interface Veritabanı
    {

        void sqlIslem(String komut);

        DataTable sqlTablo(String komut);

        String sqlString(String komut);
    
    }
}
