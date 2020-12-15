using System;
using System.Collections.Generic;
using RestWebApi;
using RestWebApi.Interfaces;
using RestWebApi.Models;
using RestWebApi.Services;
using Xunit;

namespace XUnitTestDishes.L1
{
    public class DishesFixture : IDisposable
    {
        private IDishDatabaseSettings settings;
        public List<Dish> DishesToDelete { get; private set; }
        public ICrudService CrudService { get; private set; }
        public DishesFixture()
        {
            InitBeforeTests();
        }

        // Init before running all tests
        private void InitBeforeTests()
        {
            settings = new DishDatabaseSettings
            {
                ConnectionString = "mongodb://localhost:27017",
                DatabaseName = "DishesDb",
                DishCollectionName = "Dishes"
            };

            CrudService = new DishCrudService(settings);

            DishesToDelete = new List<Dish>();
        }

        // Cleaning after running all tests
        public void Dispose()
        {
            foreach (Dish dish in DishesToDelete)
            {
                CrudService.DeleteByDish(dish);
            }
        }
    }


    public class CrudServiceTest : IClassFixture<DishesFixture>
    {
        private DishesFixture fixture;
        private ICrudService crudService;

        public CrudServiceTest(DishesFixture fixture)
        {
            this.fixture = fixture;
            crudService = this.fixture.CrudService;
        }


        [Fact, 
         Trait("Priority", "1"),
         Trait("Author", "Sigalit Chavit"),
         Trait("Description", "CRUD - Create a Dish and add it to the db")
        ]
        public void TestCreate()
        {
            // Arrange
            var dish1 = new Dish
            (
                "Brötchen",
                "Small bread",
                1.5M,
                Category.Starter,
                TimeOfDay.Weekends,
                true,
                1
            );

            // Act
            var dish2 = crudService.Create(dish1);

            // Assert
            Assert.NotNull(dish2);
            Assert.IsType<Dish>(dish2);
            Assert.NotNull(dish2.Id);
            Assert.Equal(dish2.Name, dish1.Name);
            Assert.Equal(dish2.ShortDesc, dish1.ShortDesc);
            Assert.Equal(dish2.Category, dish1.Category);
            Assert.Equal(dish2.Availability, dish1.Availability);
            Assert.Equal(dish2.Price, dish1.Price);
            Assert.Equal(dish2.Active, dish1.Active);
            Assert.Equal(dish2.WaitingTime, dish1.WaitingTime);

            // For cleaning:
            fixture.DishesToDelete.Add(dish2);
        }
        [Fact]
        public void TestUpdate() // TODO: Wrong test  pls fic it, u cannot assume a hardcoded id
        {
            // Arrange
            var dish1 = new Dish(
                "Eis",
                "Ice cream",
                2.0M,
                Category.Dessert,
                TimeOfDay.Weekdays,
                true,
                2
            );

            var dish2 = crudService.Create(dish1);

            // Act
            dish2.Name = "Eis2";
            dish2.ShortDesc = "Ice cream2";
            dish2.Price = 3.0M;
            dish2.Category = Category.Starter;
            dish2.Availability = TimeOfDay.Breakfast;
            dish2.Active = false;
            dish2.WaitingTime = 3;
            crudService.Update(dish2.Id, dish2);
            
            // Assert
            var dish3 = crudService.ReadById(dish2.Id);
            Assert.NotNull(dish3);
            Assert.NotNull(dish3.Id);
            Assert.Equal(dish3.Name, dish2.Name);
            Assert.Equal(dish3.ShortDesc, dish2.ShortDesc);
            Assert.Equal(dish3.Category, dish2.Category);
            Assert.Equal(dish3.Availability, dish2.Availability);
            Assert.Equal(dish3.Price, dish2.Price);
            Assert.Equal(dish3.Active, dish2.Active);
            Assert.Equal(dish3.WaitingTime, dish2.WaitingTime);

            // Cleaning: 
            fixture.DishesToDelete.Add(dish3);
        }

        [Fact]
        public void TestDeleteById()
        {
            // Arrange
            var dish1 = new Dish(
                "Eis",
                "Ice cream",
                2.0M,
                Category.Dessert,
                TimeOfDay.Weekdays,
                true,
                2
            );

            var dish2 = crudService.Create(dish1);
            Assert.NotNull(dish2);

            // Act
            crudService.DeleteById(dish2.Id);

            // Assert
            var dish3 = crudService.ReadById(dish2.Id);
            Assert.Null(dish3);
        }

        [Fact]
        public void TestDeleteByDish()
        {
            // Arrange
            var dish1 = new Dish(
                "Eis",
                "Ice cream",
                2.0M,
                Category.Dessert,
                TimeOfDay.Weekdays,
                true,
                2
            );

            // Act
            var dish2 = crudService.Create(dish1);
            Assert.NotNull(dish2);
            crudService.DeleteByDish(dish2);

            // Assert
            var dish3 = crudService.ReadById(dish2.Id);
            Assert.Null(dish3);
        }

        [Fact]
        public void TestReadDishById()
        {
            // Arrange
            var dish1 = new Dish(
                "Eis",
                "Ice cream",
                2.0M,
                Category.Dessert,
                TimeOfDay.Weekdays,
                true,
                2
            );

            // Act
            var dish2 = crudService.Create(dish1);
            var dish3 = crudService.ReadById(dish2.Id);

            // Assert
            Assert.NotNull(dish3);
            Assert.NotNull(dish3.Id);
            Assert.Equal(dish3.Id, dish2.Id);
            Assert.IsType<Dish>(dish3);
            Assert.Equal(dish3.Name, dish2.Name);
            Assert.Equal(dish3.ShortDesc, dish2.ShortDesc);
            Assert.Equal(dish3.Category, dish2.Category);
            Assert.Equal(dish3.Availability, dish2.Availability);
            Assert.Equal(dish3.Price, dish2.Price);
            Assert.Equal(dish3.Active, dish2.Active);
            Assert.Equal(dish3.WaitingTime, dish2.WaitingTime);

            // For cleaning:
            fixture.DishesToDelete.Add(dish2);
        }
    }
}
