using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class CourseApiController : ApiController
    {
        CourseRep CREP = new CourseRep();

        [HttpGet]
        public List<CourseModel> getCourse()
        {
            List<CourseModel> CourseList = CREP.getCourse();
            return CourseList;
        }

        [HttpPost]
        public void insertCourse(string CID , string CName , int CDuration , int CFees)
        {
            CREP.insertCourse(CID , CName , CDuration , CFees);
        }

        [HttpDelete]
        public void deleteCourse(string CID)
        {
            CREP.deleteCourse(CID);
        }

        [HttpGet]
        public CourseModel getCourseByID(string CID)
        {
            CourseModel CMOD = CREP.getCourseByID(CID);
            return CMOD;
        }
    }
}
