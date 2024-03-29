﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_CCSB.Models.ViewModels;
using Project_CCSB.Services;
using Project_CCSB.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project_CCSB.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentApiController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string loginUserId;
        private readonly string role;

        public AppointmentApiController(IAppointmentService appointmentService, IHttpContextAccessor httpContextAccessor)
        {
            _appointmentService = appointmentService;
            _httpContextAccessor = httpContextAccessor;
            loginUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);

        }
   

        [HttpGet]
        [Route("SaveCalendarDataById/{id}")]
        public IActionResult SaveCalendarDataById(int id)
        {
            CommonResponse<AppointmentViewModel> commonResponse = new CommonResponse<AppointmentViewModel>();
            try
            {
                commonResponse.Dataenum = _appointmentService.GetById(id);
                commonResponse.Status = Helper.Succes_code;
            }
            catch (Exception ex)
            {
                  commonResponse.Message = ex.Message;
                commonResponse.Status = Helper.Failure_code;
            }
            return Ok (commonResponse);
        }

        [HttpPost]
        [Route("SaveCalendarData")]
        public IActionResult SaveCalendarData(AppointmentViewModel data)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.Status = _appointmentService.AddUpdate(data).Result;
                if (commonResponse.Status == 1)
                {
                    //succesfull update
                    commonResponse.Message = Helper.AppointmentUpdated;
                }
                else if (commonResponse.Status == 2)
                {
                    //succesfull addition
                    commonResponse.Message = Helper.AppointmentAdded;
                }
            }
            catch (Exception ex)
            {
                commonResponse.Message = ex.Message;
                commonResponse.Status = Helper.Failure_code;
            }
            return Ok(commonResponse);
        }
    }
}
