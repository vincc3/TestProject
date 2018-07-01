using NUnit.Framework;
using ProjectData.Models;
using ProjectData.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.IO;

namespace ProjectData.Tests.Controllers
{
    [TestFixture]
    class ContactControllerTest
    {
        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void Test_GetContact_BadRequest()
        {
            int Id = 0; // 

            var obj = new ContactsController();

            var actResult = obj.GetContact(Id);

            Assert.That(actResult.GetType().BaseType.Name, Is.EqualTo((new BadRequestResult(obj)).GetType().BaseType.Name));
        }
    }
}
