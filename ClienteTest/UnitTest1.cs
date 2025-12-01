using ClienteAPI_Database.Data;
using ClienteAPI_Database.Data.Services;
using ClienteAPI_Database.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace ClienteTest
{
    public class Tests
    {
        private AppDbContext dbContext;
        private ClienteCommandServices commandServices;
        private ClienteQueryServices queryServices; 


        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("ClienteDatabseTest")
                .Options;

            dbContext = new AppDbContext(options);
            commandServices = new ClienteCommandServices(dbContext);
            queryServices =new ClienteQueryServices(dbContext);
        }

        [Test]
        public void InsertCliente()
        {
            commandServices.InsertCliente("Rick","Sanchez",30,"Alburquerque","EEUU","California",963852741,"rsanchez@gmail.com",41847596);
            var cliente=queryServices.GetCliente();
            Assert.AreEqual("Rick", cliente[0].nombreCliente);
        }

        [Test]
        public void GetCliente()
        {
            var cliente = new Cliente { nombreCliente="Fabricio",apellidoCliente="Espinoza",edad=18,direccion="AV.SON BORJA",pais="Chorrillos",ciudad="Lima",telefono=963852741,correo="fespinozagmail.com",DNI=74859612};
            dbContext.Cliente.Add(cliente);
            dbContext.SaveChanges();

        }

        [Test]
        public void UpdateCliente()
        {

        }

        [Test]
        public void DeleteCliente()
        {

        }

    }
}