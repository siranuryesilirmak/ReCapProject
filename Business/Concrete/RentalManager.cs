using Business.Abstract;
using Business.Contants;
using Core.Aspects.Autofac.Transaction;
using Core.Ultilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<List<Rental>> GetAllByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(c => c.CustomerId == customerId));
        }

        public IDataResult<List<RentalDetailDto>> GetAllByRentalDetail(int rentalId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(c => c.RentalId == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetAllByRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));
        }

        public IResult Add(Rental rental)
        {
            var resultToCheckRented = _rentalDal.GetRentalDetails(
                    r => r.CarId == rental.CarId && DateTime.Compare(rental.RentDate, (DateTime)r.ReturnDate) < 0);


            if (resultToCheckRented.Count > 0)
            {
                return new ErrorResult(Messages.RentalAlreadyRented);
            }

            _rentalDal.Add(rental);

            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);

            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);

            return new SuccessResult(Messages.RentalDeleted);
        }

        [TransactionScopeAspect]
        public IResult CompleteRentalById(int id)
        {
            var updatedRental = _rentalDal.GetAll(r => r.RentalId == id).SingleOrDefault();

            if (updatedRental.ReturnDate != null)
            {
                return new ErrorResult(Messages.RentalAlreadyCompleted);
            }

            updatedRental.ReturnDate = DateTime.Now;
            _rentalDal.Update(updatedRental);

            return new SuccessResult(Messages.RentalCompleted);
        }


        public IResult RentalCarControl(int carId)//rent date
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null).Any();
            if (result)
            {
                return new SuccessResult();
                
            }
            return new ErrorResult(Messages.RentalNotDelivered);

        }

        public IResult CheckAvailableDate(Rental rental)
        {
            var result = _rentalDal.GetRentalDetails(r => r.CarId == rental.CarId).
                Where(r =>
                        ((r.RentDate == rental.RentDate) && (r.ReturnDate == rental.ReturnDate)) ||
                        ((rental.RentDate >= r.RentDate) && (rental.RentDate <= r.ReturnDate)) ||
                        ((rental.ReturnDate >= r.RentDate) && (rental.ReturnDate <= r.ReturnDate))
                     ).ToList();


            if (result.Count > 0)
            {
                string errorMessage = "This car already rented between " + result[0].RentDate + " and " + result[0].ReturnDate + " .";
                return new ErrorResult(errorMessage);
            }
            return new SuccessResult("where koşullarına takılmadı");
        }

    }
}
