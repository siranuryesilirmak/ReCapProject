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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from cu in filter is null ? context.Customers : context.Customers.Where(filter)
                             join u in context.Users
                             on cu.UsersId equals u.Id
                             

                             select new CustomerDetailDto
                             {
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                CompanyName = cu.CompanyName,
                                CustomerId = cu.CustomerId,
                                UsersId = u.Id

                             };
                return result.ToList();
            }
        }
    }
}
