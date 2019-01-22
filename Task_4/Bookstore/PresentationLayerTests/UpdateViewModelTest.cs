using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.ViewModel;

namespace PresentationLayerTests
{
    [TestClass]
    public class UpdateViewModelTest
    {
        [TestMethod]
        public void CreatorTestMethod()
        {
            MainViewModel mvm = new MainViewModel();
            //SimpleIoc.Default.Register<MainViewModel>();
            ViewModelLocator loc = new ViewModelLocator();
            UpdateViewModel _vm = new UpdateViewModel();
            Assert.IsNotNull(_vm.UpdateBook);
            Assert.IsNull(_vm.ISBN);
            Assert.IsNull(_vm.Author);
            Assert.IsNull(_vm.Title);
            Assert.IsNull(_vm.Price);
        }
    }
}
