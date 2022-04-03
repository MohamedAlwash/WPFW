using Xunit;
using Moq;
using LeerlingAdministratie;

namespace test;

public class LeerlingTest
{
    [Fact]
    public void UpdateCijferTest()
    {
        //Arrange
        var administratieMock = new Mock<IAdministratie>();

        administratieMock.Setup(m => m.UpdateCijfers(It.IsAny<float>()));

        var sut = new Leerling(It.IsAny<string>(), administratieMock.Object);

        //Act
        sut.UpdateCijfers(It.IsAny<float>());

        //Assert
        administratieMock.Verify(m => m.UpdateCijfers(It.IsAny<float>()), Times.Once());
        administratieMock.Verify(m => m.UpdateBeoordeling(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void UpdateBeoordelingTest()
    {
        //Arrange
        var administratieMock = new Mock<IAdministratie>();

        administratieMock.Setup(m => m.UpdateBeoordeling(It.IsAny<string>()));

        var sut = new Leerling(It.IsAny<string>(), administratieMock.Object);

        //Act
        sut.UpdateBeoordeling(It.IsAny<string>());

        //Assert
        administratieMock.Verify(m => m.UpdateBeoordeling(It.IsAny<string>()), Times.Once());
        administratieMock.Verify(m => m.UpdateCijfers(It.IsAny<float>()), Times.Never);
    }

    [Fact]
    public void IsAfwezigTest()
    {

        //Arrange
        var administratieMock = new Mock<IAdministratie>();
        administratieMock.Setup(m => m.StuurDataNaarMinisterieVanOnderwijs(It.IsAny<string>(), It.IsAny<int>())).Returns(true);
        administratieMock.Setup(m => m.StuurDataNaarMinisterieVanOnderwijsAlsObject(It.IsAny<DataLeerling>())).Returns(true);

        var sut = new Leerling(It.IsAny<string>(), administratieMock.Object);

        //Act
        sut.IsAfwezig(It.IsAny<string>());

        //Assert
        administratieMock.Verify(m => m.StuurDataNaarMinisterieVanOnderwijs(It.IsAny<string>(), It.IsAny<int>()), Times.Once());
        administratieMock.Verify(m => m.StuurDataNaarMinisterieVanOnderwijsAlsObject(It.IsAny<DataLeerling>()), Times.Once());
    }

    [Fact]
    public void VraagDataOpVanMinisterieVanOnderwijsTest()
    {
        //Arrange
        var administratieMock = new Mock<IAdministratie>();
        // var dataLeerlingMock = new Mock<IDataLeerling>();

        var naam = administratieMock.Setup(m => m.VraagDataOpVanMinisterieVanOnderwijs(It.IsAny<string>())).Returns(It.IsAny<DataLeerling>());

        // dataLeerlingMock.SetupGet(m => m.AantalKerenAfwezig).Returns(It.IsAny<int>());
        // dataLeerlingMock.SetupGet(m => m.RedeVanLaatsteAfwezigheid).Returns(It.IsAny<string>());

        // var dataLeerling = new DataLeerling(){ AantalKerenAfwezig = It.IsAny<int>(), RedeVanLaatsteAfwezigheid = It.IsAny<string>()};
        var sut = new Leerling(It.IsAny<string>(), administratieMock.Object);

        //Act
        IDataLeerling result = sut.VraagDataOpVanMinisterieVanOnderwijs();

        //Assert
        administratieMock.Verify(m => m.VraagDataOpVanMinisterieVanOnderwijs(It.IsAny<string>()), Times.Once());

        // dataLeerlingMock.Verify(m => m.AantalKerenAfwezig, Times.Once());
        // dataLeerlingMock.Verify(m => m.RedeVanLaatsteAfwezigheid, Times.Once());

    }
}