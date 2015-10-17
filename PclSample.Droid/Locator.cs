using System;
using PclSample.Core;

namespace PclSample.Droid
{
    internal static class Locator
    {
        private static readonly Lazy<ViewModelLocator> _locator = new Lazy<ViewModelLocator>(() => new ViewModelLocator());
        public static ViewModelLocator Instance => _locator.Value;
    }
}