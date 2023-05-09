using Maletkunst.DAL.Interfaces;
using Maletkunst.DAL.SQL;

namespace Maletkunst.RestApi.Test;

public class Tests
{

    IPaintingsDataAccess _client = new PaintingsSqlDataAccess();

    [SetUp]
    public void Setup()
    {
        // CREATE PAINTING AND STORE IN DATABASE HERE
    }

    [Test]
    public void GetAllTest()
    {
        // ARRANGE
        var _paintings = _client.GetAllAvailablePaintings().Take(10);

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