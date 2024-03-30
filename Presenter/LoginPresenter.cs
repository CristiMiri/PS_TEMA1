using PS_TEMA1.Model.Repository;
using PS_TEMA1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_TEMA1.Presenter
{
    internal class LoginPresenter
    {
        /*
        private ILoginGui _loginGui;
        private UtilizatorRepository _utilizatorRepository;

        public LoginPresenter(ILoginGui loginGui)
        {
            _loginGui = loginGui;
            _utilizatorRepository = new UtilizatorRepository();
            this.main = main;
        }

        public void Login()
        {
            var utilizator = _utilizatorRepository.GetUtilizatorbyEmailandParola(_loginGui.getEmail(), _loginGui.getPassword());
            if (utilizator != null)
            {
                _loginGui.showShowMessage("Login successful", "Welcome " + utilizator.Nume + " ");
            }
            else
            {
                _loginGui.showShowMessage("Login failed", "Invalid username or password");
            }
        }

        public void validData()
        {
            if (_loginGui.getEmail().Length < 3 && !_loginGui.getEmail().Contains("@") && _loginGui.getEmail().Length >30)
            {
                _loginGui.showShowMessage("Invalid email", "Invalid email");
            }
            else if (_loginGui.getPassword().Length < 3)
            {
                _loginGui.showShowMessage("Password too short", "Password too short");
            }
            else
            {
                Login();
            }
        }

        public void goBack()
        {
            this.main.Content = null;
            this.main.Content = new HomePage(); 
        }

        internal void removeForm()
        {
            this.main.Content = null;            
        }
        */
        private LoginPage _loginPage;
        private UtilizatorRepository _utilizatorRepository = new UtilizatorRepository();
        private String loginType;
        public LoginPresenter(LoginPage loginPage)
        {
            this._loginPage = loginPage;
            this._utilizatorRepository = new UtilizatorRepository();
        }

        private Utilizator validData()
        {
            string email = this._loginPage.getEmail();
            string password = this._loginPage.getPassword();
            if (email.Length < 3 && !email.Contains("@") && email.Length > 30)
            {
                this._loginPage.showShowMessage("Invalid email", "Invalid email");
                return null;
            }
            else if (password.Length < 3)
            {
                this._loginPage.showShowMessage("Password too short", "Password too short");
                return null;
            }
            return new Utilizator(email, password);
        }

        public void login()
        {
            Utilizator utilizator = validData();
            Utilizator utilizatorLogat = this._utilizatorRepository.
                GetUtilizatorbyEmailandParola(this._loginPage.getEmail(), this._loginPage.getPassword());

            Console.WriteLine(utilizatorLogat);

            if (utilizator != null)
            {
                switch (utilizatorLogat.UserType)
                {
                    case UserType.ADMINISTRATOR:
                        this.loginType = "admin";
                        break;
                    case UserType.PARTICIPANT:
                        this.loginType = "participant";
                        break;
                    case UserType.ORGANIZATOR:
                        this.loginType = "organizator";
                        break;
                }
            }
            else
            {
                this._loginPage.showShowMessage("Login failed", "Invalid username or password");
            }
        }

        internal string getUserType()
        {
            return this.loginType;
        }
    }
}
