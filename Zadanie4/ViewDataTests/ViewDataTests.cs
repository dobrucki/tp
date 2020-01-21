using System;
using System.Linq;
using DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewData;
using ViewData.ViewModel;

namespace ViewDataTests
{
    [TestClass]
    public class ViewDataTests
    {
        [TestMethod]
        public void AddLocationTest()
        {
            IPopupHelper mockPopuplHelper = new MockPopupHelper();
            MainViewModel viewModel = new MainViewModel();
            viewModel.PopupHelper = mockPopuplHelper;
            viewModel.Name = null;
            viewModel.AddLocationCommand.Execute(null);
            Assert.AreEqual(14, viewModel.DataLayer.GetAllLocations().ToList().Count);

        }

        [TestMethod]
        public void LoadLocationsTest()
        {
            MainViewModel viewModel = new MainViewModel();
            viewModel.DataLayer = null;
            viewModel.LoadDataCommand.Execute(null);
            Assert.AreEqual(14, viewModel.DataLayer.GetAllLocations().ToList().Count);
        }


        [TestMethod]
        public void UpdateLocationTest()
        {
            IPopupHelper mockPopuplHelper = new MockPopupHelper();
            MainViewModel viewModel = new MainViewModel();
            viewModel.PopupHelper = mockPopuplHelper;
            viewModel.Name = "";
            viewModel.ID = 1;
            viewModel.UpdateLocationCommand.Execute(null);
            Assert.AreEqual("Warsaw", viewModel.DataLayer.GetLocation(1).Name);
        }



        [TestMethod]
        public void RemoveLocationTest()
        {
            IPopupHelper mockPopuplHelper = new MockPopupHelper();
            MainViewModel viewModel = new MainViewModel();
            viewModel.PopupHelper = mockPopuplHelper;
            viewModel.RemoveLocationCommand.Execute(null);
            Assert.AreEqual(14, viewModel.DataLayer.GetAllLocations().ToList().Count);
        }
    }
}
