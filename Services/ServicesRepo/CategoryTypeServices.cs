using AutoMapper;
using DataAccess.Entity;
using DataAccess.IDataAcces;
using Services.DTOClass;

using Services.ServicesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesRepo
{
    public class CategoryTypeServices : ICategoryTypeServices
    {
        private readonly ICategory _category;
        private IMapper _mapper;
        public CategoryTypeServices(ICategory category, IMapper mapper)
        {
           _category = category;
            _mapper = mapper;
        }
        public async Task<string> AddOrUpdateCategory(CategoryTypeDTO categoryDTO)
        {
            var dtoToUser = _mapper.Map<CategoryTypeDTO, Category>(categoryDTO);

            var currencyData = await _category.AddOrUpdateCategory(dtoToUser);
            return currencyData;
        }

        public async Task<string> DeleteCategoryById(int id)
        {
            var deleteCategory=await _category.DeleteCategoryById(id);
            return deleteCategory;
        }

        public async Task<List<CategoryTypeDTO>> GetAllCategoryList()
        {
            var listOfCategory = await _category.CategoryList();
            var dtoToClass = _mapper.Map<List<Category>, List<CategoryTypeDTO>>(listOfCategory);
            return dtoToClass;
        }

        
    }
}
