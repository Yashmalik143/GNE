using DataAccess.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IDataAcces
{
    public interface ICategory
    {
        public Task<List<Category>> CategoryList();
        public Task<string> AddOrUpdateCategory(Category category);

        public Task<string> DeleteCategoryById(int id);
    }
}
