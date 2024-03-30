using PS_TEMA1.Model.Repository;
using PS_TEMA1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS_TEMA1.View.Interfaces;

namespace PS_TEMA1.Presenter
{
    internal class HomePresenter
    {
        private IHomeGui _homeGui;
        private ConferintaRepository _conferintaRepository;
        private PrezentareRepository _prezentareRepository;
        private ParticipantiRepository _participantiRepository;

        public HomePresenter(IHomeGui homeGui)
        {
            _homeGui = homeGui;
            _conferintaRepository = new ConferintaRepository();
            _participantiRepository = new ParticipantiRepository();
            _prezentareRepository = new PrezentareRepository();
            List<String> list = new List<String>();
            List<Prezentare> prezentari = _prezentareRepository.GetPrezentari();
            foreach (Prezentare prezentare in prezentari)
            {
                list.Add(prezentare.Titlu);
            }
            _homeGui.setPrezentariSelection(list);
        }

        internal void inscriereConferinta()
        {
            String nume = _homeGui.getNume();
            String email = _homeGui.getEmail();
            String telefon = _homeGui.getTelefon();
            String prezentare = _homeGui.getPrezentareSelectata();
            //Utilizator utilizator =

            //_participantiRepository.addParticipanti();
        }



        /*Inscriere la conferinta*/
        //TODO: Implementare
        //Modal
    }
}
