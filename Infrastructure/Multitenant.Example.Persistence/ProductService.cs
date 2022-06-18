using Microsoft.EntityFrameworkCore;
using Multitenant.Example.Application.Abstractions;
using Multitenant.Example.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Example.Persistence
{
    public class ProductService : IProductService
    {
        readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(string name, string description, int rate)
        {
            Product product = new(name, description, rate);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IReadOnlyList<Product>> GetAllAsnyc()
            => await _context.Products.ToListAsync();

        public async Task<Product> GetByIdAsync(int id)
            => await _context.Products.FindAsync(id);
    }
}
