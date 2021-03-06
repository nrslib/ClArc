﻿using System;
using ClArc.Builder;
using ClArc.Tests.Module;
using ClArc.Tests.Sync;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClArc.Tests
{
    [TestClass]
    public class SyncUseCaseBusTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestMethod]
        public void TestThrowsException()
        {
            var serviceRegistration = new TestServiceRegistration();
            var busBuilder = new SyncUseCaseBusBuilder(serviceRegistration);
            busBuilder.RegisterUseCase<InputData, ThrowsExceptionInteractor>();
            var bus = busBuilder.Build();
            var request = new InputData();
            try
            {
                var response = bus.Handle(request);
                Assert.Fail();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        [TestMethod]
        public void TestNormal()
        {
            var serviceRegistration = new TestServiceRegistration();
            var busBuilder = new SyncUseCaseBusBuilder(serviceRegistration);
            busBuilder.RegisterUseCase<InputData, NormalInteractor>();
            var bus = busBuilder.Build();
            var request = new InputData();
            var response = bus.Handle(request);
        }

        [TestMethod]
        public void TestDefinedInterface()
        {
            var serviceRegistration = new TestServiceRegistration();
            var busBuilder = new SyncUseCaseBusBuilder(serviceRegistration);
            busBuilder.RegisterUseCase<InputData, DefinedInterfaceInteractor>();
            var bus = busBuilder.Build();
            var request = new InputData();
            var response = bus.Handle(request);
        }
    }
}