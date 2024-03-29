﻿using System;
using System.Linq;
using System.Threading;
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
            viewModel.LoadDataCommand.Execute(null);
            viewModel.PopupHelper = mockPopuplHelper;
            viewModel.ErrorCollection.Add("Name", "Niepoprawny");
            viewModel.AddLocationCommand.Execute(null);
            Thread.Sleep(500);
            Assert.AreEqual(14, viewModel.DataLayer.GetAllLocations().ToList().Count);

        }

        [TestMethod]
        public void LoadLocationsTest()
        {
            MainViewModel viewModel = new MainViewModel();
            viewModel.DataLayer = null;
            viewModel.LoadDataCommand.Execute(null);
            Thread.Sleep(500);
            Assert.AreEqual(14, viewModel.DataLayer.GetAllLocations().ToList().Count);
        }


        [TestMethod]
        public void UpdateLocationTest()
        {
            IPopupHelper mockPopuplHelper = new MockPopupHelper();
            MainViewModel viewModel = new MainViewModel();
            viewModel.PopupHelper = mockPopuplHelper;
            viewModel.ErrorCollection.Add("Name", "Niepoprawny");
            viewModel.Name = "Lodz";
            viewModel.ID = 1;
            viewModel.UpdateLocationCommand.Execute(null);
            Thread.Sleep(500);
            Assert.AreEqual("Warsaw", viewModel.DataLayer.GetLocation(1).Name);
        }



        [TestMethod]
        public void RemoveLocationTest()
        {
            IPopupHelper mockPopuplHelper = new MockPopupHelper();
            MainViewModel viewModel = new MainViewModel();
            viewModel.PopupHelper = mockPopuplHelper;
            viewModel.ID = 0;
            viewModel.RemoveLocationCommand.Execute(null);
            Thread.Sleep(500);
            Assert.AreEqual(14, viewModel.DataLayer.GetAllLocations().ToList().Count);
        }
    }
}
