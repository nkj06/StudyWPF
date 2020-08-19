using Caliburn.Micro;
using MySql.Data.MySqlClient;
using SecondCaliburn.Helpers;
using SecondCaliburn.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondCaliburn.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHaveDisplayName // Conductor를 쓰는거 추천
    {
        public override string DisplayName { get; set; }

        string firstName;

        public string FirstName {
            get => firstName;
            set
            {
                firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => CanClearName);
            }
        }

        string lastName;

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => CanClearName);
            }
        }

        public string FullName
        {
            get => $"{FirstName} {LastName}"; //string.Format("{0} {1}", FirstName, LastName);
        }

        public ShellViewModel() // 이름
        {
            DisplayName = "Second Caliburn App";
            FirstName = "KJ";

            InitCombobox();
            // People = new BindableCollection<PersonModel>();
            // People.Add(new PersonModel { LastName = "Gaes", FirstName = "Bill" });
            // People.Add(new PersonModel { LastName = "Jobs", FirstName = "Steve" });
            // People.Add(new PersonModel { LastName = "Musk", FirstName = "Ellen" });
        }

        private void InitCombobox()
        {
            People = new BindableCollection<PersonModel>();
            People.Add(new PersonModel { LastName = "", FirstName = "-- 선택 --" });
            using (MySqlConnection conn = new MySqlConnection(Commons.STRCONNSTRING))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Commons.SELECTPEOPLEQUERY, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    var temp = new PersonModel
                    {
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["lastname"].ToString()
                    };
                    People.Add(temp);
                }
            }
            SelectedPerson = People.Where(v => v.FirstName.Contains("선택")).First();
        }

        // 콤보박스 사람 리스트
        public BindableCollection<PersonModel> People { get; set; }

        PersonModel selectedPerson;

        public PersonModel SelectedPerson
        {
            get => selectedPerson;
            set
            {
                selectedPerson = value;
                LastName = selectedPerson.LastName;
                FirstName = selectedPerson.FirstName;
                NotifyOfPropertyChange(() => SelectedPerson);
                NotifyOfPropertyChange(() => CanClearName);
            }
        }

        public bool CanClearName
        {
            get => !(string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName));
        }
        public void ClearName()
        {
            FirstName = LastName = string.Empty;
        }

        public void LoadPageOne() // UserControl FirstChildView
        {
            ActivateItem(new FirstChildViewModel());
        }
        public void LoadPageTwo() // UserControl SecondChildView
        {
            ActivateItem(new SecondChildViewModel());
        }

    }
}
