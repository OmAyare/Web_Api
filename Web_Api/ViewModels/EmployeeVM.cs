using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Web_Api.Models; // Assuming Employee is in the Models folder.

namespace Web_Api.ViewModels
{
    public class EmployeeVM : INotifyPropertyChanged
    {
        private List<Employee> _employees;
        public List<Employee> Employees
        {
            get { return _employees; }
            set
            {
                if (_employees != value)
                {
                    _employees = value;
                    OnPropertyChanged(nameof(Employees)); // Notify the view of the property change
                }
            }
        }

        // Event to notify changes
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static readonly HttpClient client1 = new HttpClient();

        // Method to fetch employees from the API
        public async Task LoadEmployeesAsync()
        {
            try
            {
                var uri = new Uri("https://jsonplaceholder.typicode.com/comments"); // API URL
                var response = await client1.GetStringAsync(uri);

                // Deserialize the JSON response into the list of employees
                Employees = JsonConvert.DeserializeObject<List<Employee>>(response);
            }
            catch (Exception ex)
            {
                // Handle error
                System.Windows.MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
