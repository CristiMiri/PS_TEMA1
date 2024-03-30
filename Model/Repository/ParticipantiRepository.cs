using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_TEMA1.Model.Repository
{
    internal class ParticipantiRepository
    {
        private Repository repository;
        private UtilizatorRepository utilizatorRepository;
        private PrezentareRepository prezentareRepository;
        // Link Table Prezentare-Utilizator (participanti)

        public ParticipantiRepository()
        {
            repository = new Repository();
            utilizatorRepository = new UtilizatorRepository();
            prezentareRepository = new PrezentareRepository();
        }

        public DataTable Participanti()
        {
            string query = "SELECT * FROM prezentari_utilizatori";
            DataTable participantiTable = repository.ExecuteQuery(query);

            return participantiTable;
        }

        public List<Utilizator> GetUtilizatoribyPrezentare(Prezentare prezentare)
        {
            DataTable participantiTable = Participanti();
            if (participantiTable != null)
            {
                List<Utilizator> utilizatori = new List<Utilizator>();
                foreach (DataRow row in participantiTable.Rows)
                {
                    if ((int)row["prezentare_id"] == prezentare.Id)
                    {
                        utilizatori.Add(utilizatorRepository.GetUtilizatorById((int)row["utilizator_id"]));
                    }
                }
                return utilizatori;
            }
            return null;
        }

        public List<Utilizator> getParticipanti()
        {
            DataTable participantiTable = Participanti();
            if (participantiTable != null || participantiTable.Rows.Count > 0)
            {

                List<Utilizator> utilizatori = new List<Utilizator>();
                foreach (DataRow row in participantiTable.Rows)
                {
                    utilizatori.Add(utilizatorRepository.GetUtilizatorById((int)row["utilizator_id"]));
                }
                Console.WriteLine(participantiTable.Rows.Count);
                return utilizatori;
            }
            return null;
        }

        public bool addParticipanti(Prezentare prezentare, Utilizator utilizator)
        {
            string nonQuery = "INSERT INTO prezentari_utilizatori VALUES (" +
                prezentare.Id + ", " +
                utilizator.Id + ")";
            return repository.ExecuteNonQuery(nonQuery);
        }

        public bool deleteParticipanti(Prezentare prezentare, Utilizator utilizator)
        {
            string nonQuery = "DELETE FROM prezentari_utilizatori WHERE id_conferinta = " +
                prezentare.Id + " AND id_utilizator = " +
                utilizator.Id;
            return repository.ExecuteNonQuery(nonQuery);
        }

        public bool deleteParticipanti(Prezentare prezentare)
        {
            string nonQuery = "DELETE FROM prezentari_utilizatori WHERE id_prezentare = " +
                prezentare.Id;
            return repository.ExecuteNonQuery(nonQuery);
        }

        public bool deleteParticipanti(Utilizator utilizator)
        {
            string nonQuery = "DELETE FROM prezentari_utilizatori WHERE id_utilizator = " +
                utilizator.Id;
            return repository.ExecuteNonQuery(nonQuery);
        }

        public List<Utilizator> GetUtilizatorsbySectiune(Sectiune sectiune)
        {
            List<Prezentare> prezentari = prezentareRepository.GetPrezentarebySectiune(sectiune);
            List<Utilizator> utilizatori = new List<Utilizator>();
            foreach (Prezentare prezentare in prezentari)
            {
                utilizatori.AddRange(GetUtilizatoribyPrezentare(prezentare));
            }
            return utilizatori;
        }
    }
}
