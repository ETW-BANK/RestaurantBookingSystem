﻿using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Access.Data;
using Restaurant.Data.Access.Repository.IRepository;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Access.Repository.Services
{
    public class BookingRepository : Repository<Booking>, IBookngRepository
    {
        private readonly RestaurantDbContext _context;

        public BookingRepository(RestaurantDbContext context):base(context) 
        {
            _context = context;
        }
        public async Task UpdateBookingAsync(Booking booking)
        {
           var existingbooking= await GetSingleAsync(booking.Id);

            if (existingbooking != null)
            {
                _context.Bookings.Update(booking);    
            }

            await _context.SaveChangesAsync();
        }
     


    }
}
