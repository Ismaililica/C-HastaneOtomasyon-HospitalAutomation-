using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HastaneOtomasyonProjesi;



namespace HastaneOtomasyonProjesi
{
    internal class sqlBaglantisi
    {
        public SqlConnection baglanti(){
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-66045LM;Initial Catalog=HastaneProje;Integrated Security=True");
        baglan.Open();
        return baglan;
    }
    }
}
