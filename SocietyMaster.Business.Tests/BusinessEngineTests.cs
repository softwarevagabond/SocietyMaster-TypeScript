using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Common.Core;
using System.ComponentModel.Composition;
using SocietyMaster.Business.Contracts;
using SocietyMaster.Entities;
using SocietyMaster.Bootstrapper;
namespace SocietyMaster.Business.Tests
{
    [TestClass]
    public class BusinessEngineTests
    {
        [TestInitialize]
        public void Initialize()
        {
            EntityBase.Container = MEFLoader.Init();
        }

        [TestMethod]
        public void GetSocietyByCode()
        {
           SocietyEngineTestClass societyEngineTestClass = new SocietyEngineTestClass();
           Society society= societyEngineTestClass.GetSocietyByCode(1);
           Assert.IsTrue(society != null);
        }
    }

    public class SocietyEngineTestClass
    {
        public SocietyEngineTestClass()
        {
            EntityBase.Container.SatisfyImportsOnce(this);
        }

        public SocietyEngineTestClass(ISocietyEngine societyEngine)
        {
            _SocietyEngine = societyEngine;
        }

        [Import]
        ISocietyEngine _SocietyEngine;

       public Society GetSocietyByCode(int societyCode)
        {
            return _SocietyEngine.GetSocietyByCode(societyCode);
        }
    }
}
