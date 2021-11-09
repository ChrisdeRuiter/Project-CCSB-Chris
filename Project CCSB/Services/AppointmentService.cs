using Project_CCSB.Models;
using Project_CCSB.Models.ViewModels;
using Project_CCSB.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


namespace Project_CCSB.Services
{
    public class AppointmentService : IAppointmentService
    {
        private ApplicationDbContext _db;
        public AppointmentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> AddUpdate(AppointmentViewModel model)
        {
            var timeAndMoment = DateTime.Parse(Convert.ToString(model.TimeAndMoment), CultureInfo.CreateSpecificCulture("nl-NL"));
            if (model != null && model.AppointmentId > 0)
            {
                //TODO: Add code for update appointment
                return 1;
            }
            else
            {
                // Create appointment based on view model
                Appointment appointment = new Appointment()
                {
                    OphalenId = model.OphalenId,
                    AppointmentId = model.AppointmentId,
                    TimeAndMoment = model.TimeAndMoment,
                    Action = model.Action
                };
                _db.Appointments.Add(appointment);
                await _db.SaveChangesAsync();
                return 2;
            }
        }
        public AppointmentViewModel GetById(int id)
        {
            return _db.Appointments.Where(a => a.Id == id).ToList().Select(
               c => new AppointmentViewModel()
               {
                   Id = c.Id,
                   OphalenId = c.OphalenId,
                   AppointmentId = c.AppointmentId,
                   StartDate= c.StartDate.ToString("d-MM-yyyy HH:mm"),
                   EndDate= c.EndDate.ToString("d-M-yyyy HH: mm"),
                Action = c.Action,
                   CustomerName = _db.Users.Where(u => u.Id == c.CustomerId).Select(u => u.FullName).FirstOrDefault(),

               }).SingleOrDefault();
        }
        public List<AdminViewModel> GetAdminList()
        {

            var admins = (from user in _db.Users
                          join userRole in _db.UserRoles on user.Id equals userRole.UserId
                          join role in _db.Roles.Where(x => x.Name == Helper.Admin) on userRole.RoleId equals role.Id

                          select new AdminViewModel
                          {
                              Id = user.Id,
                              Name = string.IsNullOrEmpty(user.MiddleName) ?
                              user.FirstName + " " + user.LastName :
                              user.FirstName + " " + user.MiddleName + " " + user.LastName
                          }
                             ).OrderBy(u => u.Name).ToList();
            return admins;
        }
        public List<CustomerViewModel> GetCustomerList()
        {

            var customers = (from user in _db.Users
                             join userRole in _db.UserRoles on user.Id equals userRole.UserId
                             join role in _db.Roles.Where(x => x.Name == Helper.Customer) on userRole.RoleId equals role.Id

                             select new CustomerViewModel
                             {
                                 Id = user.Id,
                                 Name = string.IsNullOrEmpty(user.MiddleName) ?
                                 user.FirstName + " " + user.LastName :
                                 user.FirstName + " " + user.MiddleName + " " + user.LastName
                             }
                             ).OrderBy(u => u.Name).ToList();
            return customers;
        }

        public List<CustomerViewModel> AdminAppointments(string adminid)
        {
            throw new NotImplementedException();
        }

        public List<AdminViewModel> CustomerAppointments(string costumerid)
        {
            throw new NotImplementedException();
        }
    }
};
