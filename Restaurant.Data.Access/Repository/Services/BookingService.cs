using Restaurant.Data.Access.Repository.IRepository;
using Restaurant.Data.Access.Repository.Services.IServices;
using Restaurant.Models.DTOs;
using Restaurant.Models;
using Restaurant.Utility;
using System.Linq.Expressions;

public class BookingService : IBookingService
{
    private readonly IBookngRepository _bookingRepo;

    public BookingService(IBookngRepository bookingRepo)
    {
        _bookingRepo = bookingRepo;
    }

    public async Task<ServiceResponse<string>> AddItemAsync(BookingDto item)
    {
        var response = new ServiceResponse<string>();

        try
        {
            var booking = new Booking
            {
                // Map properties from BookingDto to Booking
                // e.g., Id = item.Id, etc.
            };

            await _bookingRepo.AddItemAsync(booking);
            await _bookingRepo.SaveAsync();

            response.Data = "Booking added successfully!";
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }

        return response;
    }

    public async Task<ServiceResponse<BookingDto>> GetSingleAsync(int id)
    {
        var response = new ServiceResponse<BookingDto>();

        try
        {
            var booking = await _bookingRepo.GetSingleAsync(id);

            if (booking != null)
            {
                response.Data = new BookingDto
                {
                    // Map properties from Booking to BookingDto
                };
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "Booking not found.";
            }
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }

        return response;
    }

   

    public async Task<ServiceResponse<IEnumerable<BookingDto>>> GetAllbookingAsync(params Expression<Func<Booking, object>>[] includes)
    {
        var response = new ServiceResponse<IEnumerable<BookingDto>>();

        try
        {
            var bookingList = await _bookingRepo.GetAllBookingAsync(b => b.Customer,
                b => b.Tables,
                b => b.FoodMenu);

            if (bookingList != null && bookingList.Any())
            {
                response.Data = bookingList.Select(u => new BookingDto
                {
                    Id = u.Id,
                    BookingDate = u.BookingDate,
                    NumberOfGuests = u.NumberOfGuests,
                    TablesId = u.Tables?.Id ?? 0,
                    CustomerId = u.Customer?.Id ?? 0,
                    FoodMenuId = u.FoodMenu?.Id ?? 0,
                    Customer = u.Customer != null ? new CustomerDto
                    {
                        Id = u.Customer.Id,
                        FirstName = u.Customer.FirstName,
                        LasttName = u.Customer.LasttName,
                        Email = u.Customer.Email,
                        Phone = u.Customer.Phone
                    } : null,
                    Tables = u.Tables != null ? new TablesDto
                    {
                        Id = u.Tables.Id,
                        TableNumber = u.Tables.TableNumber,
                        NumberOfSeats = u.Tables.NumberOfSeats,
                        isAvialable = u.Tables.isAvialable
                    } : null,
                    FoodMenu = u.FoodMenu != null ? new FoodMenuDto
                    {
                        Id = u.FoodMenu.Id,
                        Title = u.FoodMenu.Title,
                        ImageUrl = u.FoodMenu.ImageUrl,
                        IsAvailable = u.FoodMenu.IsAvailable
                    } : null
                }).ToList();
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = Messages.NoData;
            }
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
          
        }

        return response;
    }

    public async Task<ServiceResponse<bool>> RemoveAsync(int id)
    {
        var response = new ServiceResponse<bool>();

        try
        {
            await _bookingRepo.RemoveAsync(id);
            await _bookingRepo.SaveAsync();
            response.Data = true;
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.Data = false;
            response.Success = false;
            response.Message = ex.Message;
        }

        return response;
    }

    public async Task<ServiceResponse<bool>> UpdateBookingAsync(BookingDto bookingDto)
    {
        var response = new ServiceResponse<bool>();

        try
        {
            var booking = new Booking
            {
                // Map properties from BookingDto to Booking
            };

            await _bookingRepo.UpdateBookingAsync(booking);
            response.Data = true;
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.Data = false;
            response.Success = false;
            response.Message = ex.Message;
        }

        return response;
    }
}
