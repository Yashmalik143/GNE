using Services.DTOClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ICategoryType
    {
        public Task<List<CategoryTypeDTO>> GetAllCategoryTypeList();
        public Task<string> AddOrUpdateCategory(CategoryTypeDTO categoryDTO);
        public Task<string> DeleteCategoryById(int id);
    }
}
