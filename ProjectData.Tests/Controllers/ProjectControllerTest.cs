using NUnit.Framework;
using ProjectData.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace ProjectData.Tests.Controllers
{
    [TestFixture]
    class ProjectControllerTest
    {
        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void Test_GetProduct_BadRequest()
        {
            int Id = 0; // 

            var obj = new ProjectsController();

            var actResult = obj.GetProject(Id);

            Assert.That(actResult.GetType().BaseType.Name, Is.EqualTo((new BadRequestResult(obj)).GetType().BaseType.Name));
        }

    }
}
