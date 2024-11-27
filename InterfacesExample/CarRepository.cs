namespace InterfacesExample;

public class CarRepository : IRespository<CarModel>
{
    public List<CarModel> CarList = new(); 
    public CarModel? Get(Guid Id)
    {
        foreach (var carModel in CarList)
        {
            if (carModel.Id == Id)
            {
                return carModel;
            }
        }

        return null;
    }

    public List<CarModel> Get()
    {
        return CarList;
    }

    public void Insert(CarModel model)
    {
        if (model != null)
        {
            CarList.Add(model);
        }
    }

    public void Update(CarModel model)
    {
        CarModel existingModel = Get(model.Id);
        if (existingModel != null)
        {
            existingModel.Name = model.Name;
            existingModel.Brand = model.Brand;
        }
    }

    public void Delete(Guid Id)
    {
        CarModel DeleteCar = Get(Id);
        if (DeleteCar != null)
        {
            CarList.Remove(DeleteCar);
        }
    }

    public int RecordCount()
    {
        return CarList.Count;
    }
}