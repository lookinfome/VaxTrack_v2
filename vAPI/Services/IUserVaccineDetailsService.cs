using Microsoft.AspNetCore.Identity;
using vAPI.Models;
using vAPI.Dto;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Mvc;

namespace vAPI.Services
{
    // interface: to expose the services
    public interface IUserVaccineDetailsService
    {
        public UserVaccineDetailsDto_UserVaccinationReport FetchUserVaccinationReportById (string userid);
    }

    // class: to define the implementation of services
    public class UserVaccineDetailsService : IUserVaccineDetailsService
    {
        // variable: to operate with SQLite DB
        private readonly AppDbContext _v2Context;

        // contructor: to initialize the class variables
        public UserVaccineDetailsService(AppDbContext v2Context)
        {
            _v2Context = v2Context;
        }

        //service: fetch user full vaccination details by user id 
        public UserVaccineDetailsDto_UserVaccinationReport FetchUserVaccinationReportById(string userid)
        {
            var userVaccinationReport = (from vaccineRecord in _v2Context.UserVaccineDetails
                                        join bookingRecord in _v2Context.BookingDetails
                                        on vaccineRecord.UserVaccinationId equals bookingRecord.UserVaccinationId
                                        select new UserVaccineDetailsDto_UserVaccinationReport
                                        {
                                            UserId = vaccineRecord.UserId,
                                            UserVaccinationStatus = vaccineRecord.UserVaccinationStatus,
                                            BookingId = bookingRecord.BookingId,
                                            Dose1Date = bookingRecord.Dose1Date,
                                            D1HospitalName = bookingRecord.D1HospitalName,
                                            D1SlotNumber = bookingRecord.D1SlotNumber,
                                            Dose2Date = bookingRecord.Dose2Date,
                                            D2HospitalName = bookingRecord.D2HospitalName,
                                            D2SlotNumber = bookingRecord.D2SlotNumber
                                        }).Where(record=>record.UserId == userid).FirstOrDefault();

            return userVaccinationReport != null ? userVaccinationReport : new UserVaccineDetailsDto_UserVaccinationReport {};
        }


    }
}