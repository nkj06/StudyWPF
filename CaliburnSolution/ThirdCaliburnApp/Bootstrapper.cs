﻿using Caliburn.Micro;
using MvvmDialogs;
using System;
using System.Collections.Generic;
using System.Windows;
using ThirdCaliburnApp.Helpers;
using ThirdCaliburnApp.ViewModels;

namespace ThirdCaliburnApp
{
    class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer container;// SimpleContainer는 칼리번에 있음

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();
            container.Singleton<IWindowManager, WindowManager>();
            container.RegisterInstance(typeof(IDialogService), null, 
                new DialogService(dialogTypeLocator: new DialogTypeLocator()));
            container.PerRequest<MainViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
