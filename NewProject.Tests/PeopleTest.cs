using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewProject.Models.Domain;
using NewProject.Models.Requests;
using NewProject.Services;

namespace NewProject.Tests
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void Insert_Test()
        {
            PersonAddRequest model = new PersonAddRequest
            {
                AccountId = 25,
                Username = "Batman",
                PhotoId = 5,
                Gender = true,
                ModifiedBy = "Me"
            };

            PersonService svc = new PersonService();
            int result = svc.Insert(model);

            Assert.IsTrue(result > 0, "The insert failed!");
        }

        [TestMethod]
        public void SelectAll_Test()
        {
            PersonService svc = new PersonService();
            List<Person> result = svc.GetAll();
            Assert.IsTrue(result.Count > 0, "Select All has failed");
        }
    }
}
