using ApiJobs.Models;
namespace ApiJobs.Services;

public class CategoryService : ICategoryService
{

    JobsContext context;

    public CategoryService(JobsContext dbcontext)
    {
       context = dbcontext;
    }


    public IEnumerable<Category> Get()
    {
        return context.Categories;
    }

    public async Task Save(Category category)
    {
        context.Categories.Add(category);
        await context.SaveChangesAsync();
    }


    
    public async Task Update(Guid id, Category category)
    {
        var currentCategory = context.Categories.Find(id);

        if(currentCategory != null){
            currentCategory.Name = category.Name;
            currentCategory.Description = category.Description;

            await context.SaveChangesAsync();
        }


    }


    public async Task Delete(Guid id)
    {
        var currentCategory = context.Categories.Find(id);

        if(currentCategory != null){
            context.Categories.Remove(currentCategory);
            await context.SaveChangesAsync();
        }


    }





}



public interface ICategoryService
{
    IEnumerable<Category> Get();
    Task Save(Category category);
    Task Update(Guid id, Category category);
    Task Delete(Guid id);

}