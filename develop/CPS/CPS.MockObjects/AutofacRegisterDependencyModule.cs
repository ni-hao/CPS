using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Integration.Mvc;
using CPS.Abstract.BridgePay;
using Moq;

namespace CPS.MockObjects
{
    public class AutofacRegisterDependencyModule : Autofac.Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register<IBridgePayWS>(ctx =>
            {
                var moqBridgePayWS = new Mock<IBridgePayWS>();
                
                moqBridgePayWS.Setup(b => b.CPSGetAccountPackages(It.IsAny<String>(), It.IsAny<String>()))
                    .Returns(MockData.CPSGetAccountPackages());

                moqBridgePayWS.Setup(b => b.CPSGetCurrentAccountPackage(It.IsAny<String>(), It.IsAny<String>()))
                    .Returns(MockData.CPSGetCurrentAccountPackage());

                moqBridgePayWS.Setup(
                    b => b.CPSGetAvailableAddOns(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>()))
                    .Returns(MockData.CPSGetAvailableAddOns());

                moqBridgePayWS.Setup(
                    b => b.ListCountries()
                    ).Returns(MockData.ListCountries());

                moqBridgePayWS.Setup(b => b.ListIndustries()).Returns(MockData.ListIndustries());

                moqBridgePayWS.Setup(b => b.CPSGetContactInfo(It.IsAny<String>(), It.IsAny<String>()))
                    .Returns(MockData.CPSGetContactInfo());
                return moqBridgePayWS.Object;
            }).InstancePerHttpRequest();

        }
    }
}
