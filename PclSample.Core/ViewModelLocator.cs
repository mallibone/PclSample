using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PclSample.Core.Services;
using PclSample.Core.Services.Impl;
using PclSample.Core.ViewModels;

namespace PclSample.Core
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IPersonService, PersonService>();
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();
    }
}
