using DoAnCoSo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace DoAnCoSo.Services
{
	public class ServiceBase
	{
		#region Properties
		protected readonly string KEY = "Id";
		protected DoAnCoSoDbContext db;
		#endregion
		#region Constructor
		public ServiceBase()
		{
			db = new DoAnCoSoDbContext();
		}

		public ServiceBase(DoAnCoSoDbContext _db)
		{
			db = _db;
		}
		#endregion

		#region Methods

		public bool Any<Table>(Expression<Func<Table, bool>> expression) where Table : class
		{
			var x = db.Set<Table>();
			return db.Set<Table>().Any(expression);
		}

		// get all infomation from table database
		public Table Get<Table>(object primaryKey) where Table : class
		{
			return db.Set<Table>().Find(primaryKey);
		}

		public TModel Get<TTable, TModel>(int id) where TTable : class where TModel : class
		{
			var data = db.Set<TTable>()
				.AsNoTracking().Where(KEY + " == " + id)
				.Select(this.GetSelectedFields<TModel>())
				.SingleOrDefault();
			return CastTo<TModel>(data);
		}

		public TModel CastTo<TModel>(object data, bool replaceWithNull = true) where TModel : class
		{
			var stype = data.GetType();
			var dtype = typeof(TModel);

			var dataObject = Activator.CreateInstance<TModel>();
			bool isNotUpdate = false;

			foreach(var item in stype.GetProperties())
			{
				var attribute = item.GetCustomAttributes();
				 foreach(var attr in attribute)
				{
					if(attribute.ToString() == "Not Clone")
					{
						isNotUpdate = true;
					}
					if(isNotUpdate)
					{
						isNotUpdate = !isNotUpdate;
					}
					object value = null;
					try
					{
						value = item.GetValue(data);
					}
					catch
					{
						continue;
					}
					if(value == null && !replaceWithNull)
					{
						continue;
					}
					dtype.GetProperty(item.Name)?.SetValue(dataObject, value);
				}
			}
			return dataObject;
		}

		protected string GetSelectedFields<TObject>()
		{
			string query = "new {";
			var type = typeof(TObject);

			bool isNotUpdate = false;
			// GetProperties giúp lấy all thuộc tính của 1 class
			foreach (var item in type.GetProperties())
			{
				var attributes = item.GetCustomAttributes(true);
				foreach (var attr in attributes)
				{
					if (attr.ToString() == "Not Clone")
					{
						isNotUpdate = true;
					}
					if (isNotUpdate)
					{
						isNotUpdate = !isNotUpdate;
						continue;
					}
				}
				query += item.Name + ",";
			}
			return query.Remove(query.Length - 1, 1) + "}";
		}

		public PagedResult GetPagedList<TTable>(int page, int size) where TTable : class
		{
			return db.Set<TTable>().AsNoTracking()
				.OrderBy("Id")
				.PageResult(page, size);
		}

		public PagedResult GetPagedList<TTable, TModel>(int page, int size) where TTable : class where TModel : class
		{
			var result = db.Set<TTable>()
						.AsNoTracking()
						.Select(this.GetSelectedFields<TModel>())
						.OrderBy("Id")
						.PageResult(page, size);
			result.Queryable = CastToList<TModel>(result);
			return result;
		}

		public IQueryable CastToList<TModel>(PagedResult result) where TModel : class
		{
			var pageResult = new List<TModel>();
			foreach(var item in result.Queryable)
			{
				pageResult.Add(CastTo<TModel>(item));
			}
			return pageResult.AsQueryable();
		}
		#endregion
	}
}
