using CleanArchMvc.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories(); //retorna uma lista de categorias através do método GetCategories(), usando Task porque é uma op. assincrona
        Task<Category> GetById(int? id); //retorna uma categoria pelo id, int? é um int nullable

        Task<Category> Create(Category category); //Cria uma categoria
        Task<Category> Update(Category category); //Atualiza uma categoria
        Task<Category> Remove(Category category); //Remove uma categoria

    }
}
