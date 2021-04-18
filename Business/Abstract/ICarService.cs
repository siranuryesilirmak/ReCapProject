using Core.Ultilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetAllByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>>GetAllCarDetailByBrand(int brandId);
        IDataResult<List<CarDetailDto>> GetAllCarDetailByColor(int colorId);
        IDataResult<List<CarDetailDto>> GetAllCarDetailByCarId(int colorId);
        IResult Add(Car car);
        IResult Update(Car car);
        IDataResult<Car> GetById(int carId);
        IResult AddTransactionalTest(Car car);


    }
}
