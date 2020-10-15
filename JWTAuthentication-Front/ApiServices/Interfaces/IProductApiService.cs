using System.Collections.Generic;
using System.Threading.Tasks;
using JWTAuthentication_Front.Models;

namespace JWTAuthentication_Front.ApiServices.Interfaces
{
    public interface IProductApiService
    {
        Task<List<ProductList>> GetAllAsync();
        Task AddAsync(ProductAdd productAdd);

        Task<ProductList> GetByIdAsync(int id);

        Task UpdateAsync(ProductList productList);

        Task DeleteAsync(int id);

    }
}