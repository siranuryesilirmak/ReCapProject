﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, RentACarContext>, IBrandDal
    {
        public Brand GetByName(string name)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Brands.SingleOrDefault(b => b.Name.Equals(name));
            }
        }
    }
}
