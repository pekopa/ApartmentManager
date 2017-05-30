
using System;
using ApartmentManager.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApartmentManagerUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateResidentFail()
        {
            //// try to add Resident without appartment ID it has to fail ////
            ApartmentViewModel model = new ApartmentViewModel();
            model.UserSingleton.CurrentUser.ApartmentId = 0;
            model.NewResident.FirstName = "asd";
            model.NewResident.LastName = "lopas";
            model.ApartmentHandler.GetApartmentResidents();
            int residentsBefore = model.CatalogSingleton.Residents.Count;
            //test//
            model.ApartmentHandler.CreateResident();
            Assert.AreNotEqual(residentsBefore, model.CatalogSingleton.Residents.Count);
        }
        [TestMethod]
        public void TestCreateResidentPass()
        {
            //// try to add Resident with appartment ID it has to pass ////
            ApartmentViewModel model = new ApartmentViewModel();
            model.UserSingleton.CurrentUser.ApartmentId = 1;
            model.NewResident.FirstName = "asd";
            model.NewResident.LastName = "lopas";
            model.ApartmentHandler.GetApartmentResidents();
            int residentsBefore = model.CatalogSingleton.Residents.Count;
            //test//
            model.ApartmentHandler.CreateResident();
            Assert.AreNotEqual(residentsBefore, model.CatalogSingleton.Residents.Count);  
        }
        [TestMethod]
        public void TestUpdateResidentFail()
        {
            //// try to update Resident with wrong ID it has to fail ////
            ApartmentViewModel model = new ApartmentViewModel();
            model.UserSingleton.CurrentUser.ApartmentId = 1;
            model.ApartmentHandler.GetApartmentResidents();
            string residentsBefore = model.CatalogSingleton.Residents[0].FirstName;
            model.NewResident.ResidentId = 999;
            model.NewResident.FirstName = "jonny";
            //test//
            model.ApartmentHandler.UpdateResident();
            Assert.AreNotEqual(residentsBefore, model.CatalogSingleton.Residents[0].FirstName);
        }
        [TestMethod]
        public void TestUpdateResidentPass()
        {
            //// try to update Resident with wrong ID it has to fail ////
            ApartmentViewModel model = new ApartmentViewModel();
            model.UserSingleton.CurrentUser.ApartmentId = 1;
            model.ApartmentHandler.GetApartmentResidents();
            string residentsBefore = model.CatalogSingleton.Residents[0].FirstName;
            model.NewResident.ResidentId = model.CatalogSingleton.Residents[0].ResidentId;
            model.NewResident.FirstName = "jonny";

            //test//
            model.ApartmentHandler.UpdateResident();
            Assert.AreNotEqual(residentsBefore, model.CatalogSingleton.Residents[0].FirstName);
        }
        [TestMethod]
        public void TestDeleteResidentFail()
        {
            //// try to delete Resident with wrong ID it has to fail ////
            ApartmentViewModel model = new ApartmentViewModel();
            model.UserSingleton.CurrentUser.ApartmentId = 1;
            model.ApartmentHandler.GetApartmentResidents();
            int residentsBefore = model.CatalogSingleton.Residents.Count;
            model.NewResident.ResidentId = 999;

            //test//
            model.ApartmentHandler.DeleteResident();
            Assert.AreNotEqual(residentsBefore, model.CatalogSingleton.Residents.Count);
        }
        [TestMethod]
        public void TestDeleteResidentPass()
        {
            //// try to delete Resident with good ID it has to pass ////
            ApartmentViewModel model = new ApartmentViewModel();
            model.UserSingleton.CurrentUser.ApartmentId = 1;
            model.ApartmentHandler.GetApartmentResidents();
            int residentsBefore = model.CatalogSingleton.Residents.Count;
            model.NewResident.ResidentId = model.CatalogSingleton.Residents[0].ResidentId;
            //test//
            model.ApartmentHandler.DeleteResident();
            Assert.AreNotEqual(residentsBefore, model.CatalogSingleton.Residents.Count);
        }
    }
}
