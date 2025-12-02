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

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        [Test]
        public void InsertCliente()
        {
            commandServices.InsertCliente("Fabricio", "Espinoza", 18, "AV.SON BORJA", "Chorrillos", "Lima", 963852741, "fespinozagmail.com", 74859612);
            var cliente=queryServices.GetCliente();
            Assert.AreEqual("Rick", cliente[0].nombreCliente);
        }

        [Test]
        public void GetCliente()
        {
            var cliente = new Cliente { nombreCliente="Fabricio",apellidoCliente="Espinoza",edad=18,direccion="AV.SON BORJA",pais="Chorrillos",ciudad="Lima",telefono=963852741,correo="fespinozagmail.com",DNI=74859612};
            dbContext.Cliente.Add(cliente);
            dbContext.SaveChanges();

            var resultado=queryServices.GetCliente().ToList();

            Assert.AreEqual("Fabricio", resultado[0].nombreCliente);
        }

        [Test]
        public void UpdateCliente()
        {
            var cliente = new Cliente { nombreCliente = "Fabricio", apellidoCliente = "Espinoza", edad = 18, direccion = "AV.SON BORJA", pais = "Chorrillos", ciudad = "Lima", telefono = 963852741, correo = "fespinozagmail.com", DNI = 74859612 };
            dbContext.Cliente.Add(cliente);
            dbContext.SaveChanges();

            commandServices.EditCliente(cliente.clienteId,"Omar","Zavaleta",20,"av.san isidro","peru","lima",963741852,"ozavaleta@gmail.com",74859632);

            var actulizado = queryServices.GetCliente().ToList();

            Assert.AreEqual("Omar", actulizado[0].nombreCliente);
        }

        [Test]
        public void DeleteCliente()
        {
            var cliente = new Cliente { nombreCliente = "Fabricio", apellidoCliente = "Espinoza", edad = 18, direccion = "AV.SON BORJA", pais = "Chorrillos", ciudad = "Lima", telefono = 963852741, correo = "fespinozagmail.com", DNI = 74859612 };
            dbContext.Cliente.Add(cliente);
            dbContext.SaveChanges();

            commandServices.DeleteCliente(cliente.clienteId);

            var resultado = queryServices.GetCliente();
            Assert.AreEqual(0, resultado.Count);    
        }

    }
}