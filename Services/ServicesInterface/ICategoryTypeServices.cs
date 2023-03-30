using Services.DTOClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesInterface
{
    public interface ICategoryTypeServices
    {
        public Task<string> AddOrUpdateCategory(CategoryTypeDTO categoryDTO);
        public Task<string> DeleteCategoryById(int id);
        public Task<List<CategoryTypeDTO>> GetAllCategoryList();
    }
}
