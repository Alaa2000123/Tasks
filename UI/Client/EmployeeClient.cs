using API.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace UI.Client
{
    public class EmployeeClient : IClientEmployee
    {
        private readonly HttpClient _httpClient;
        public EmployeeClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7162/api/Employees/GetAll");
            if (response.IsSuccessStatusCode)
            {
                string strobj = await response.Content.ReadAsStringAsync();
                IEnumerable<Employee> emps = JsonConvert.DeserializeObject<IEnumerable<Employee>>(strobj);
                return emps;
            }
            return null;
        }
        public async Task<Employee> GetById(int Id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:7162/api/Employees/GetById?id={Id}");
            if (response.IsSuccessStatusCode)
            {
                string strobj = await response.Content.ReadAsStringAsync();
                Employee emps = JsonConvert.DeserializeObject<Employee>(strobj);
                return emps;
            }
            return null;
        }
        public async Task<string> AddEdit(Employee emp)
        {
            if (emp.Id == 0)
            {
                StringContent contant = new StringContent(JsonConvert.SerializeObject(emp), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync("https://localhost:7162/api/Employees/insert", contant);
                if (response.IsSuccessStatusCode)
                {
                    //string strobj = await response.Content.ReadAsStringAsync();
                    
                    return "Done";
                }
                return null;
            }
            else
            {
                StringContent contant = new StringContent(JsonConvert.SerializeObject(emp), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync("https://localhost:7162/api/Employees/update", contant);
                if (response.IsSuccessStatusCode)
                {
                    //string strobj = await response.Content.ReadAsStringAsync();
                    //Employee emps = JsonConvert.DeserializeObject<Employee>(strobj);
                    return "Done";
                }
                return null;
            }
        }
        
    }
}
