
using DataAccess.Context;
using DataAccess.Entity;
using DataAccess.IDataAcces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataAccessRepo
{
    public class CategoryRepo : ICategory
    {
        private readonly Context.GneProjectContext _context;
        public CategoryRepo(Context.GneProjectContext context)
        {
            _context = context;
        }
        public async Task<string> AddOrUpdateCategory(Category category)
        {
            var categoryData = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryName == category.CategoryName);
            if (categoryData == null)
            {
                categoryData = new Category
                {
                    CategoryType = category.CategoryType,
                    CategoryName = category.CategoryName,

                };
                _context.Categories.Add(categoryData);

            }
            else
            {
                categoryData.CategoryType = category.CategoryType;
            }
            await _context.SaveChangesAsync();
            return (category.CategoryId == 0 ? "Added Succesfully......:)" : "Updated Successfully");

        }

        public async Task<List<Category>> CategoryList()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<string> DeleteCategoryById(int id)
        {
            var categoryById = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (categoryById == null)
                return ("Category Not Found");
            _context.Remove(categoryById);
            await _context.SaveChangesAsync();
            return ("Delete Succesfully......:)");

        }
    }
}
