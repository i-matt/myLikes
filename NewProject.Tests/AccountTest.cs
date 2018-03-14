using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewProject.Models.Domain;
using NewProject.Models.Requests;
using NewProject.Services;
using System.Collections.Generic;

namespace NewProject.Tests
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void Insert_Test()
        {
            AccountAddRequest model = new AccountAddRequest
            {
                Email = "unitTest@email.com",
                ModifiedBy = "Me"
            };

            AccountService svc = new AccountService();
            int result = svc.Insert(model);

            Assert.IsTrue(result > 0, "The insert failed!");
        }

        [TestMethod]
        public void Update_Test()
        {
            AccountUpdateRequest model = new AccountUpdateRequest
            {
                Id = 1,
                Email = "unitTest@email.com",
                ModifiedBy = "Me"
            };

            AccountService svc = new AccountService();
            int result = svc.Insert(model);

            Assert.IsTrue(result > 0, "The insert failed!");
        }

        [TestMethod]
        public void SelectAll_Test()
        {
            AccountService svc = new AccountService();
            List<Account> result = svc.GetAll();
            Assert.IsTrue(result.Count > 0, "Select All has failed");
        }
    }
}
