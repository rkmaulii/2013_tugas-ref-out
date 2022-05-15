using System.Data;
using Npgsql;

namespace topiksembilan
{
    class pertama
    {
        private static NpgsqlConnection terhubung()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=maulida26;database=karyawan;");
        }

        public bool ExecuteQuery(out bool data)
        {
            data = true;
            try
            {
                NpgsqlConnection abc = terhubung();
                abc.Open();
                string pga = "select * from pegawai";
                NpgsqlCommand perintah = new NpgsqlCommand(pga, abc);
                NpgsqlDataAdapter nda= new NpgsqlDataAdapter(perintah);
                DataTable dle = new DataTable();
                nda.Fill(dle);
                return data;
            }
            catch (Exception)
            {
                data = false;
                return false;
            }
        }
    }

    class kedua
    {
        private static NpgsqlConnection terhubung()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=maulida26;database=karyawan;");
        }
        
        public bool insert (ref bool data)
        {
            try
            {
                NpgsqlConnection abc = terhubung();
                abc.Open();
                string pga = "select * from pegawai";
                NpgsqlCommand perintah = new NpgsqlCommand("insert into pegawai(alamat,no_hp,username,password,nama) values('surabaya', '087612356781', 'ekaliaa', 'eka123', 'ekalia sasmita')", abc);
                perintah.ExecuteNonQuery();
                perintah.Dispose();
                data = true;
                return data;
            }
            catch (Exception)
            {
                return data;
            }
        }
        public bool update(ref bool data)
        {
            try
            {
                NpgsqlConnection abc = terhubung();
                abc.Open();
                NpgsqlCommand perintah = new NpgsqlCommand("update pegawai set alamat=jember, no_hp=087612356781, username=ekaliaa, password= eka123, nama= ekalia sasmita where id_pegawai = 4", abc);
                perintah.ExecuteNonQuery();
                perintah.Dispose();
                abc.Close();
                data = true;
                return data;
            }
            catch (Exception)
            {
                return data;
            }
        }

        public bool delete(ref bool data)
        {
            try
            {
                NpgsqlConnection abc = terhubung();
                abc.Open();
                NpgsqlCommand perintah = new NpgsqlCommand("delete from pegawai where id_pegawai = 5", abc);
                perintah.ExecuteNonQuery();
                perintah.Dispose();
                abc.Close();
                data = true;
                return data;
            }
            catch (Exception)
            {
                return data;
            }
        }
    }

    class pusat
    {
        static void Main(string[] args)
        {
            bool data;
            bool datanya = false;
            pertama first = new pertama();
            kedua jln = new kedua();


            if(first.ExecuteQuery(out data)==true)
            {
                Console.WriteLine("Data berhasil didapatkan");
            }
            else if(first.ExecuteQuery(out data)== false)
            {
                Console.WriteLine("Data gagal didapatkan");
            }


            if (jln.insert(ref datanya)==true)
            {
                Console.WriteLine("Insert berhasil ditambahkan");
            }
            else if(jln.insert(ref datanya)==false)
            {
                Console.WriteLine("Insert gagal ditambahkan");
            }


            if (jln.update(ref datanya) == true)
            {
                Console.WriteLine("Berhasil melakukan Pembaruan");
            }
            else if (jln.insert(ref datanya) == false)
            {
                Console.WriteLine("Gagal melakukan Pembaruan");
            }


            if(jln.delete(ref datanya) == true)
            {
                Console.WriteLine("Berhasil melakukan delete");
            }
            else if (jln.delete (ref datanya) == false)
            {
                Console.WriteLine("Gagal melakukan delete");
            }
        }
    }
}
