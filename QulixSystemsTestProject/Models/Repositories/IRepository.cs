﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QulixSystemsTestProject.Models.Repositories
{
    interface IRepository<T> 
        where T : class
    {
        IEnumerable<T> List();
        T Find(int id); 
        void Add(T item);
        void Update(T item); 
        void Delete(int id);
    }
}
