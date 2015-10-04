using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Common.Core;
using SocietyMaster.Data.Contracts;
using System.ComponentModel.Composition;
using SocietyMaster.Entities;
using SocietyMaster.Bootstrapper;
using System.Collections.Generic;
using Core.Common.Contracts;

namespace SocietyMaster.Data.Tests
{
    [TestClass]
    public class DataLayerTests
    {
        [TestInitialize]
        public void Initialize()
        {
            EntityBase.Container = MEFLoader.Init();
        }

        [TestMethod]
        public void AddNewSociety()
        {
            SocietyRepositoryTestClass societyRepositoryTestClass = new SocietyRepositoryTestClass();
            Society newSociety = new Society()
            {
                Id = Guid.NewGuid(),
                City = "Pune",
                Description = "TestSocietyDesc",
                Address="Test Address",
                Disabled = false,
                Locality = "Aundh",
                Name = "TestSociety",
                State = "Maharashtra",
                ZipCode = "411020"
            };

            Society addedSociety = societyRepositoryTestClass.AddNewSociety(newSociety);
            Assert.IsTrue(addedSociety != null);
        }

        [TestMethod]
        public void AddNewSocietyWithBuildingAndHouse()
        {
            SocietyRepositoryTestClass societyRepositoryTestClass = new SocietyRepositoryTestClass();

            Society newSociety = new Society()
            {
                Id = Guid.NewGuid(),
                City = "Pune",
                Description = "TestSocietyDesc4",
                Address = "Test Address3",
                Disabled = false,
                Locality = "Aundh",
                Name = "TestSociety4",
                State = "Maharashtra",
                ZipCode = "411020"
            };
            newSociety.Buildings.Add(new Building()
            {
                Id = Guid.NewGuid(),
                Description = "A4",
                Name = "Test Building4"
            });

            Society addedSociety = societyRepositoryTestClass.AddNewSociety(newSociety);
            Assert.IsTrue(addedSociety != null);
        }

        [TestMethod]
        public void GetSocietyByCode()
        {
            SocietyRepositoryTestClass societyRepositoryTestClass = new SocietyRepositoryTestClass();
            Society society = societyRepositoryTestClass.GetSociety(1);
            Assert.IsTrue(society != null);
        }

        [TestMethod]
        public void GetSocietyDetails()
        {
            SocietyRepositoryTestClass societyRepositoryTestClass = new SocietyRepositoryTestClass();
            Society society = societyRepositoryTestClass.GetSocietyDetails(1);
            Assert.IsTrue(society != null);
        }
        
        [TestMethod]
         public void UpdateSociety()
        {
            SocietyRepositoryTestClass societyRepositoryTestClass = new SocietyRepositoryTestClass();
            Society society = societyRepositoryTestClass.GetSociety(1);
            society.City = "Bang";
            Society societyUpdated = societyRepositoryTestClass.UpdateSociety(society);
            Assert.IsTrue(society != null);
        }

        [TestMethod]
        public void UpdateSocietyDetails()
        {
            SocietyRepositoryTestClass societyRepositoryTestClass = new SocietyRepositoryTestClass();
            Society society = societyRepositoryTestClass.GetSocietyDetails(1);
            society.City = "kochi";
            society.ObjectState = ObjectState.Modified;

            // For Testing
            foreach(var building in society.Buildings)
            {
                building.ObjectState = ObjectState.Unchanged;
            }
            var b1=society.Buildings.Find(b => b.Description == "A1");
            b1.Name = "Test Building test A1";
            b1.ObjectState = ObjectState.Modified;

            var b2 = society.Buildings.Find(b => b.Description == "A-1");
            if(b2!=null)
            b2.ObjectState = ObjectState.Deleted;

            foreach (var house  in society.Houses)
            {
                house.ObjectState = ObjectState.Unchanged;
            }
            //For Testing...

            //var building = society.Buildings.ToArray();
            //if(building.Length>0)
            //{
            //    building[0].Name = "Updated1";
            //    building[0].ObjectState = ObjectState.Modified;
            //}

            Society societyUpdated = societyRepositoryTestClass.UpdateSociety(society);
            Assert.IsTrue(society != null);
        }



        [TestMethod]
        public void AddNewBuilding()
        {
            BuildingRepositoryTestClass buildingRepositoryTestClass = new BuildingRepositoryTestClass();
            Building building = new Building()
            {
                Id= Guid.NewGuid(),
                Description="A-11",
                Name="Test Building",
                SocietyId = new Guid("FDE8B053-600E-456F-9E17-8E712D8BD075")
            };

            Building addedBuilding = buildingRepositoryTestClass.AddNewBuilding(building);

            Assert.IsTrue(building != null);
        }

        [TestMethod]
        public void AddNewHouse()
        {
            HouseRepositoryTestClass houseRepositoryTestClass = new HouseRepositoryTestClass();
            House house = new House()
            {
                Id = Guid.NewGuid(),
                HouseNumber = "705",
                Description = "Testing",
                SocietyId = new Guid("FDE8B053-600E-456F-9E17-8E712D8BD075"),
                BuildingId = new Guid("13E00D80-C8D1-4392-A449-90E08D1B75B0")
            };

            House addedHouse = houseRepositoryTestClass.AddNewHouse(house);
            Assert.IsTrue(addedHouse != null);
        }

        [TestMethod]
        public void GetSocietyByCodeUsingFactory()
        {
            RepositoryFactoryTestClass repositoryFactoryTestClass = new RepositoryFactoryTestClass();
            Society society= repositoryFactoryTestClass.GetSociety(1);
            Assert.IsTrue(society!=null);
        }
    }


    public class SocietyRepositoryTestClass
    {
        public SocietyRepositoryTestClass()
        {
            EntityBase.Container.SatisfyImportsOnce(this);
        }

        public SocietyRepositoryTestClass(ISocietyRepository societyRepository)
        {
            _SocietyRepository = societyRepository;
        }

        [Import]
        ISocietyRepository _SocietyRepository;

        public Society AddNewSociety(Society newSociety)
        {
          Society society =  _SocietyRepository.Add(newSociety);
          return society;
        }

        public Society GetSociety(int societyCode)
        {
            Society society = _SocietyRepository.GetSocietyByCode(societyCode);
            return society;
        }

        public Society GetSocietyDetails(int societyCode)
        {
            Society society = _SocietyRepository.GetCompleteSocietyDetails(societyCode);
            return society;
        }

        public Society UpdateSociety(Society society)
        {
            Society updatedSociety = _SocietyRepository.Update(society);
            return updatedSociety;
        }
    }

    public class BuildingRepositoryTestClass
    {
        public BuildingRepositoryTestClass()
        {
            EntityBase.Container.SatisfyImportsOnce(this);
        }

        public BuildingRepositoryTestClass(IBuildingRepository buildingRepository)
        {
            _BuildingRepository = buildingRepository;
        }

        [Import]
        IBuildingRepository _BuildingRepository;

        public Building AddNewBuilding(Building newBuilding)
        {
            Building building = _BuildingRepository.Add(newBuilding);
            return building;
        }
    }

    public class HouseRepositoryTestClass
    {
        public HouseRepositoryTestClass()
        {
            EntityBase.Container.SatisfyImportsOnce(this);
        }

        public HouseRepositoryTestClass(IHouseRepository houseRepository)
        {
            _HouseRepository = houseRepository;
        }

        [Import]
        IHouseRepository _HouseRepository;

        public House AddNewHouse(House newHouse)
        {
            House house = _HouseRepository.Add(newHouse);
            return house;
        }
    }


    public class RepositoryFactoryTestClass
    {
        public RepositoryFactoryTestClass()
        {
            EntityBase.Container.SatisfyImportsOnce(this);
        }

        public RepositoryFactoryTestClass(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        [Import]
        IDataRepositoryFactory _DataRepositoryFactory;

        public Society GetSociety(int societyCode)
        {
            ISocietyRepository societyRepository = _DataRepositoryFactory.GetDataRepository<ISocietyRepository>();
            return societyRepository.GetSocietyByCode(societyCode);
        }
    }
}
