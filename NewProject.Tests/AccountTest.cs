using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewProject.Models.Domain;
using NewProject.Models.Requests;
using NewProject.Models.Response;
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

            Assert.IsTrue(result > 0, "Insert failed!");
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
            svc.Update(model);
            Assert.IsTrue(model.Id > 0, "Update failed!");
        }

        [TestMethod]
        public void Delete_Test()
        {
            AccountService svc = new AccountService();
            svc.Delete(6);
            Account result = svc.GetById(6);
            Assert.IsTrue(result.Id== 0, "Delete has failed");
        }

        [TestMethod]
        public void SelectAll_Test()
        {
            AccountService svc = new AccountService();
            List<Account> result = svc.GetAll();
            Assert.IsTrue(result.Count > 0, "Select All has failed");
        }

        [TestMethod]
        public void SelectById_Test()
        {
            AccountService svc = new AccountService();
            Account result = svc.GetById(4);
            Assert.IsTrue(result.Id > 0, "Select By Id has failed");
        }
    }
}
