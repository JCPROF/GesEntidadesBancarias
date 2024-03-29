﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
	public interface IRepositoryBase<T>
	{
		IQueryable<T> GetAll();
		IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
		void Create(T entity);
		Task SaveAsync();
	}
}
