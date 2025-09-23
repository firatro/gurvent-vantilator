using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly AppDbContext _context;

        public TestimonialRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Testimonial>> GetAllAsync()
        {
            return await _context.Testimonials.ToListAsync();
        }

        public async Task<Testimonial?> GetByIdAsync(int id)
        {
            return await _context.Testimonials
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Testimonial testimonial)
        {
            await _context.Testimonials.AddAsync(testimonial);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Testimonial testimonial)
        {
            _context.Testimonials.Update(testimonial);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Testimonial testimonial)
        {
            _context.Testimonials.Remove(testimonial);
            await _context.SaveChangesAsync();
        }
    }
}
