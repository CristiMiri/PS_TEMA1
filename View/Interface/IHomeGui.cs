using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_TEMA1.View.Interface
{
    internal interface IHomeGui : IGUI
    {
        String getNume();
        void setNume(String nume);
        String getEmail();
        void setEmail(String email);
        String getTelefon();
        void setTelefon(String telefon);
        String getPrezentareSelectata();
        void setPrezentareSelectata(String prezentare);

        void setPrezentariSelection(List<String> prezentari);
    }
}
