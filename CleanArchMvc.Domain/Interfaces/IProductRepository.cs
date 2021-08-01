using CleanArchMvc.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync(); //retorna uma lista de produtos através do método GetProductsAsync(), usando Task porque é uma op. assincrona
        Task<Product> GetByIdAsync(int? id); //retorna um produto pelo id, int? é um int nullable

        Task<Product> GetProductCategoryAsync(int? id); //retorna os produtos pelo Id de uma categoria
        Task<Product> CreateAsync(Product product); //Cria um produto
        Task<Product> UpdateAsync(Product product); //Atualiza um produto
        Task<Product> RemoveAsync(Product product); //Remove um produto

    }
}
