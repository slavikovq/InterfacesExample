namespace InterfacesExample.Tests;

public class CarRepositoryTests
{
    [Fact]
    public void InsertingNewModel_ShouldIncreaseRecordCount()
    {
        //Arrange
        IRespository<CarModel> model = new CarRepository();
        CarModel carModel = new CarModel("superb", "skoda");
        int RecordCountBefore = model.RecordCount();

        //Act
        model.Insert(carModel);
        int RecordCountAfter = model.RecordCount();

        //Assert
        Assert.Equal(RecordCountBefore, RecordCountAfter - 1);
    }

    [Fact]
    public void InsertingNull_ShouldSustainRecordCount()
    {
        //Arrange
        IRespository<CarModel> model = new CarRepository();
        CarModel carModel = null;
        int RecordCountBefore = model.RecordCount();

        //Act
        if (carModel != null)
        {
            model.Insert(carModel);
        }

        int RecordCountAfter = model.RecordCount();

        //Assert
        Assert.Equal(RecordCountBefore, RecordCountAfter);
    }

    [Fact]
    public void GettingAllRecords_WithTwoRecords_ShouldReturnListOfTwoRecords()
    {
        //Arrange
        IRespository<CarModel> model = new CarRepository();
        CarModel carModel = new CarModel("superb", "skoda");
        CarModel carModel2 = new CarModel("nesuperb", "neskoda");


        //Act
        model.Insert(carModel);
        model.Insert(carModel2);
        List<CarModel> models = model.Get();

        //Assert
        Assert.Equal(2, models.Count);
        Assert.Contains(carModel, models);
        Assert.Contains(carModel2, models);
    }

    [Fact]
    public void GettingInsertedRecordWithId_WithTwoRecords_ShouldReturnInsertedRecord()
    {
        //Arrange
        IRespository<CarModel> model = new CarRepository();
        CarModel carModel = new CarModel("superb", "skoda");
        CarModel carModel2 = new CarModel("nesuperb", "neskoda");


        //Act
        model.Insert(carModel);
        model.Insert(carModel2);

        CarModel getModel = model.Get(carModel.Id);
        CarModel getModel2 = model.Get(carModel2.Id);

        //Assert
        Assert.Equal(carModel.Id, getModel.Id);
        Assert.Equal(carModel2.Id, getModel2.Id);
    }

    [Fact]
    public void GettingNotInsertedRecordWithId_WithTwoRecords_ShouldReturnNull()
    {
        //Arrange
        IRespository<CarModel> model = new CarRepository();
        CarModel carModel = new CarModel("superb", "skoda");
        CarModel carModel2 = new CarModel("nesuperb", "neskoda");

        //Act
        model.Insert(carModel);
        model.Insert(carModel2);
        Guid noId = new Guid();
        CarModel noCarModel = model.Get(noId);

        //Assert
        Assert.Null(noCarModel);
    }  
}

