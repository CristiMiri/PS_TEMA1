using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_TEMA1.Model.Repository
{
    internal class ConferintaRepository
    {
        private Repository repository;
        /*Conferinta =  private int id;
                        private String titlu;
                        private String locatie;
                        private String data;
                        private List<Utilizator> participanti;
                        private List<Prezentare> prezentari;
                        */

        public ConferintaRepository()
        {
            repository = new Repository();
        }

        public DataTable ConferintaTable()
        {
            string query = "SELECT * FROM conferinte";
            DataTable conferinteTable = repository.ExecuteQuery(query);
            if (conferinteTable != null || conferinteTable.Rows.Count != 0)
            {
                return conferinteTable;
            }
            return null;
        }

        public Conferinta rowToConferinta(DataRow row)
        {

            Conferinta conferinta = new Conferinta
            {
                Id = int.Parse(row["id"].ToString()),
                Titlu = row["titlu"].ToString(),
                Locatie = row["locatie"].ToString(),
                Data = row["data"].ToString()
            };
            return conferinta;
        }

        //CRUD
        public void AddConferinta(Conferinta conferinta)
        {
            string query = "INSERT INTO conferinte( titlu, locatie, data) VALUES ('" +
                conferinta.Titlu + "', '" +
                conferinta.Locatie + "', '" +
                conferinta.Data + "')";
            repository.ExecuteNonQuery(query);
        }

        public List<Conferinta> GetConferinte()
        {
            DataTable conferinteTable = ConferintaTable();
            if (conferinteTable == null)
            {
                return null;
            }
            List<Conferinta> conferinte = new List<Conferinta>();
            foreach (DataRow row in conferinteTable.Rows)
            {
                Conferinta conferinta = rowToConferinta(row);
                conferinte.Add(conferinta);
            }
            return conferinte;
        }

        public Conferinta GetConferintabyID(int id)
        {
            DataTable conferinteTable = ConferintaTable();
            if (conferinteTable == null)
            {
                return null;
            }
            foreach (DataRow row in conferinteTable.Rows)
            {
                Conferinta conferinta = rowToConferinta(row);
                if (conferinta.Id == id)
                {
                    return conferinta;
                }
            }
            return null;
        }

        public void UpdateConferinta(Conferinta conferinta)
        {
            string query = "UPDATE conferinte SET titlu = '" +
                conferinta.Titlu + "', locatie = '" +
                conferinta.Locatie + "', data = '" +
                conferinta.Data + "', sectiune = '" +
                conferinta.Id;
            repository.ExecuteNonQuery(query);
        }

        public void DeleteConferinta(int id)
        {
            string query = "DELETE FROM conferinte WHERE id = " + id;
            repository.ExecuteNonQuery(query);
        }

        //Filters


    }
}
