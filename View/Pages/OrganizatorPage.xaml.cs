using PS_TEMA1.Presenter;
using PS_TEMA1.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PS_TEMA1.View.Pages
{
    /// <summary>
    /// Interaction logic for OrganizatorPage.xaml
    /// </summary>
    public partial class OrganizatorPage : Page, IOrganizatorGui
    {
        private OrganizatorPresenter _organizatorPresenter;
        public OrganizatorPage()
        {
            InitializeComponent();
            _organizatorPresenter = new OrganizatorPresenter(this);
        }

        public DataGrid GetTabelPrezentari()
        {
            return TabelPrezentari;
        }

        public DataGrid GetTabelParticipanti()
        {
            return TabelParticipanti;
        }

        public void showMessage(string title, string message)
        {
            MessageBox.Show(message, title);
        }
    }
}
