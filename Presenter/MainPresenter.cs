using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_TEMA1.Presenter
{
    internal class MainPresenter
    {
        private IMainGui _mainGui;
        //private LoginPresenter _loginPresenter;
        //private HomePresenter _homePresenter;

        public MainPresenter(IMainGui mainGui)
        {
            this._mainGui = mainGui;
        }


        public void ChangePage(string page)
        {
            switch (page)
            {
                case "login":
                    ShowLoginPage();
                    break;
                case "home":
                    ShowHomePage();
                    break;
                case "admin":
                    ShowAdminPage();
                    break;
                case "organizator":
                    ShowOrganizatorPage();
                    break;
                case "participant":
                    ShowParticipantPage();
                    break;
            }
        }

        public void ShowLoginPage()
        {
            LoginPage loginPage = new LoginPage(ChangePage);
            this._mainGui.SetFrameContent(loginPage);
            this._mainGui.HideHeader();
        }

        public void ShowHomePage()
        {
            HomePage homePage = new HomePage();
            this._mainGui.SetFrameContent(homePage);
            this._mainGui.ShowHeader();
        }

        public void ShowAdminPage()
        {
            AdminPage adminPage = new AdminPage(ChangePage);
            this._mainGui.SetFrameContent(adminPage);
            this._mainGui.HideHeader();
        }

        public void ShowOrganizatorPage()
        {
            OrganizatorPage homePage = new OrganizatorPage();
            this._mainGui.SetFrameContent(homePage);
            this._mainGui.ShowHeader();
        }

        public void ShowParticipantPage()
        {
            UtilizatorPage homePage = new UtilizatorPage();
            this._mainGui.SetFrameContent(homePage);
            this._mainGui.ShowHeader();
        }
    }
}
