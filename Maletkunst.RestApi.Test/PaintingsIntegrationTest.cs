using Maletkunst.RestApi.DAL.DataAccess;

namespace Maletkunst.RestApi.Test;

public class Tests
{

    IPaintingDAO _paintingDAO = new PaintingDAO();

    [SetUp]
    public void Setup()
    {
        // CREATE PAINTING AND STORE IN DATABASE HERE
    }

    [Test]
    public void GetAllTest()
    {
        // ARRANGE
        var _paintings = _paintingDAO.GetAll().Take(10);

        // ACT

        // ASSERT
        Assert.That(_paintings.Any(), "Yeehaa!");
    }

    [TearDown]
    public void TearDown()
    {
        // REMOVE PAINTINGS FROM DATABASE
    }
}