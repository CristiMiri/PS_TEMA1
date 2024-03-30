using PS_TEMA1.Model.Repository;
using PS_TEMA1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_TEMA1.Presenter
{
    internal class AdminPresenter
    {
        private IAdminGui _adminGui;
        private UtilizatorRepository utilizatorRepository;

        public AdminPresenter(IAdminGui adminGui)
        {
            _adminGui = adminGui;
            utilizatorRepository = new UtilizatorRepository();
            List<Utilizator> utilizators = utilizatorRepository.GetUtilizatori();
            DataGrid dataGrid = _adminGui.GetDataGrid();
            dataGrid.ItemsSource = utilizators;
        }

        internal void CreateUser()
        {
            try
            {
                Utilizator utilizator = validData();
                if (utilizator != null)
                {

                    if (utilizatorRepository.addUtilizator(utilizator) == true)
                    {
                        _adminGui.showShowMessage("Succes", "Utilizatorul a fost adaugat cu succes!");
                        List<Utilizator> utilizators = utilizatorRepository.GetUtilizatori();
                        _adminGui.SetDataGridItemsSource(utilizators);
                    }
                    else
                    {
                        _adminGui.showShowMessage("Error", "Utilizatorul exista deja in baza de date!");
                    }
                }
            }
            catch (Exception e)
            {
                _adminGui.showShowMessage("Error", "Nu s-a putut adauga utilizatorul!");
            }
        }

        public void DeleteUser()
        {

            if (_adminGui.GetDataGrid().SelectedItem != null)
            {
                Utilizator selectedUtilizator = _adminGui.GetDataGrid().SelectedItem as Utilizator;
                if (selectedUtilizator != null)
                {
                    utilizatorRepository.deleteUtilizator(selectedUtilizator.Id);
                    utilizatorRepository.GetUtilizatori();
                    _adminGui.SetDataGridItemsSource(utilizatorRepository.GetUtilizatori());
                    _adminGui.showShowMessage(_adminGui.getUtilizatorNume(), "Utilizatorul a fost sters cu succes!");
                }
            }
        }

        private Utilizator validData()
        {
            String name = _adminGui.getUtilizatorNume();
            String email = _adminGui.getUtilizatorEmail();
            String parola = _adminGui.getUtilizatorParola();
            String telefon = _adminGui.getUtilizatorTelefon();
            UserType user_Type = _adminGui.getUtilizatorType();
            int id = _adminGui.getUtilizatorId();
            if (id < 0)
            {
                _adminGui.showShowMessage("Error", "Id-ul nu poate fi negativ!");
                return null;
            }
            if (String.IsNullOrEmpty(name))
            {
                _adminGui.showShowMessage("Error", "Numele este obligatoriu!");
                return null;
            }
            if (String.IsNullOrEmpty(email))
            {
                _adminGui.showShowMessage("Error", "Email-ul este obligatoriu!");
                return null;
            }
            if (String.IsNullOrEmpty(parola))
            {
                _adminGui.showShowMessage("Error", "Parola este obligatorie!");
                return null;
            }
            if (String.IsNullOrEmpty(telefon))
            {
                _adminGui.showShowMessage("Error", "Telefonul este obligatoriu!");
                return null;
            }
            if (user_Type == null)
            {
                _adminGui.showShowMessage("Error", "Tipul utilizatorului este obligatoriu!");
                return null;
            }
            return new Utilizator(id, name, email, parola, user_Type, telefon);

        }

        public void UpdateUser()
        {
            Utilizator utilizator = validData();

            if (utilizator != null)
            {
                if (utilizatorRepository.updateUtilizator(utilizator) == true)
                {
                    _adminGui.showShowMessage("Succes", "Utilizatorul a fost actualizat cu succes!");
                    List<Utilizator> utilizators = utilizatorRepository.GetUtilizatori();
                    _adminGui.SetDataGridItemsSource(utilizators);
                }
                else
                {
                    _adminGui.showShowMessage("Error", "Nu s-a putut actualiza utilizatorul!");
                }
            }
        }

        internal void SetFormFields()
        {
            if (_adminGui.GetDataGrid().SelectedItem != null)
            {
                Utilizator selectedUtilizator = _adminGui.GetDataGrid().SelectedItem as Utilizator;
                _adminGui.setUtilizatorId(selectedUtilizator.Id);
                _adminGui.setUtilizatorEmail(selectedUtilizator.Email);
                _adminGui.setUtilizatorNume(selectedUtilizator.Nume);
                _adminGui.setUtilizatorParola(selectedUtilizator.Parola);
                _adminGui.setUtilizatorTelefon(selectedUtilizator.Telefon);
                _adminGui.setUtilizatorType(selectedUtilizator.UserType);


            }
        }
        /*
private IAdminGui _adminGui;


//Operații CRUD pentru informațiile legate de utilizatorii aplicației care necesită autentificare;
//ToDO Implementare//
//Modal
public void AddUtilizator()
{
Utilizator utilizator = this.validUtilizatorData();
if (utilizator != null)
{
bool result = utilizatorRepository.addUtilizator(utilizator);
if (result)
{
  this._adminGui.showShowMessage("Succes", "Utilizatorul a fost adaugat cu succes!");
  this._adminGui.UtilizatorList(utilizatorRepository.GetUtilizatori());

}
else
{ 
  this._adminGui.showShowMessage("Error", "Nu s-a putut adauga utilizatorul!");
}
}
}

public void DeleteUtilizator()
{
Utilizator utilizator = validInformation();
if (utilizator != null)
{
utilizatorRepository.DeleteUtilizator(utilizator);
_adminGui.UtilizatorList(utilizatorRepository.GetAllUtilizatori());
resetUtilizatorControls();
}
}

public void UpdateUtilizator()
{
Utilizator utilizator = validInformation();
if (utilizator != null)
{
utilizatorRepository.UpdateUtilizator(utilizator);
_adminGui.UtilizatorList(utilizatorRepository.GetAllUtilizatori());
resetUtilizatorControls();
}
}

public void SearchUtilizatorByIDOrName()
{
Utilizator utilizator = validInformation();
if (utilizator != null)
{
List<Utilizator> utilizatori = utilizatorRepository.SearchUtilizatorByIDOrName(utilizator);
_adminGui.UtilizatorList(utilizatori);
}
}
//Vizualizarea listei tuturor utilizatorilor care necesită autentificare
public void allUtilizatori()
{
_adminGui.UtilizatorList(utilizatorRepository.GetAllUtilizatori());
}

private Utilizator validUtilizatorData()
{
      if (_adminGui.UtilizatorName == "")
{
_adminGui.UtilizatorNameError = "Name is required!";
}
else
{
_adminGui.UtilizatorNameError = "";
}

if (_adminGui.UtilizatorPassword == "")
{
_adminGui.UtilizatorPasswordError = "Password is required!";
}
else
{
_adminGui.UtilizatorPasswordError = "";
}
}


*/
    }
}
