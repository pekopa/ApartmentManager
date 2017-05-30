
using System;
using ApartmentManager.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApartmentManagerUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ApartmentViewModel model = new ApartmentViewModel();
            model.UserSingleton.CurrentUser.ApartmentId = 1;
            model.NewResident.FirstName = "asd";
            model.NewResident.LastName = "lopas";
            model.ApartmentHandler.GetApartmentResidents();
            var currentDefects = model.CatalogSingleton.Residents.Count;
            //test//
            model.ApartmentHandler.CreateResident();
            Assert.AreNotEqual(currentDefects, model.CatalogSingleton.Residents);
            
        }
        [TestMethod]
        public void TestMethod2()
        {
            
            ApartmentViewModel model = new ApartmentViewModel();
            model.UserSingleton.CurrentUser.ApartmentId = 0;
            model.NewResident.FirstName = "asd";
            model.NewResident.LastName = "lopas";
            model.ApartmentHandler.GetApartmentResidents();
            var currentDefects = model.CatalogSingleton.Residents.Count;
            //test//
            model.ApartmentHandler.CreateResident();
            Assert.AreNotEqual(currentDefects, model.CatalogSingleton.Residents);

        }
    }
}
