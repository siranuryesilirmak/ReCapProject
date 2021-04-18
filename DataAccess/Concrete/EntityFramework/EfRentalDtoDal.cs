using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDtoDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join c  in context.Cars
                             on r.CarId  equals c.Id
                             join brand in context.Brands
                             on c.BrandId equals brand.Id
                             join user in context.Users
                             on cu.UsersId equals user.Id

                             select new RentalDetailDto
                             {
                                 BrandName= brand.Name,
                                 RentalId =r.RentalId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 CompanyName =cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }

        
        

    }
}  

