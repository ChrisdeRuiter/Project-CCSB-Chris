using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_CCSB.Models.ViewModels;

namespace Project_CCSB.Services
{
    public interface IAppointmentService
    {
        public List<CustomerViewModel> GetCustomerList();
        public List<AdminViewModel> GetAdminList();
        public Task<int> AddUpdate(AppointmentViewModel model);
        public List<CustomerViewModel> AdminAppointments(string adminid);
        public List<AdminViewModel> CustomerAppointments(string costumerid);
        public AppointmentViewModel GetById(int id);
    }
}