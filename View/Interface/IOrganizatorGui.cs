using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PS_TEMA1.View.Interface
{
    internal interface IOrganizatorGui : IGUI
    {
        DataGrid GetTabelPrezentari();
        DataGrid GetTabelParticipanti();
    }
}
