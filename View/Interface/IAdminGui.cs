using PS_TEMA1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PS_TEMA1.View.Interface
{
    internal interface IAdminGui : IGUI
    {
        DataGrid GetDataGrid();
        void SetDataGridItemsSource(List<Utilizator> utilizators);
        int GetUtilizatorId();
        void SetUtilizatorId(int id);
        string GetUtilizatorNume();
        void SetUtilizatorNume(string nume);
        string GetUtilizatorEmail();
        void SetUtilizatorEmail(string email);
        string GetUtilizatorParola();
        void SetUtilizatorParola(string parola);
        UserType GetUtilizatorType();
        void SetUtilizatorType(UserType userType);
        string GetUtilizatorTelefon();
        void SetUtilizatorTelefon(string telefon);
        void ClearFields();
    }
}
