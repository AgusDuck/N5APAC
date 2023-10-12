namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;
using PAC.IDataAccess;
using PAC.BusinessLogic;

[TestClass]
public class StudentControllerTest
{
    private Mock<IStudentLogic> _mock;
    private StudentController _studentController;
    private Student _student;

        [TestInitialize]
        public void InitTest()
        {
            _mock = new Mock<IStudentLogic>();
            _studentController = new StudentController(_mock.Object);
            _student = new Student()
            {
                Id = 1,
                Name = "Test"
            };
        }

    [TestMethod]
    public void PostStudentOk()
    {
        _mock.Setup(m => m.InsertStudents(_student));
        var result = _studentController.PostStudent(_student);
        var objectResult = result as ObjectResult;
        var statusCode = objectResult.StatusCode;

        _mock.VerifyAll();
        Assert.AreEqual(statusCode, 200);
    }

    [TestMethod]
    public void PostStudentFail()
    {
        _student.Id = 0;
        var result = _studentController.PostStudent(_student);
        var objectResult = result as ObjectResult;
        var statusCode = objectResult.StatusCode;

        _mock.VerifyAll();
        Assert.AreEqual(statusCode, 400);
    }
}
