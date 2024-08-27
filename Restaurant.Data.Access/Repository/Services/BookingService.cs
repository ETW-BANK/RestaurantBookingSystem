using Restaurant.Data.Access.Repository.IRepository;
using Restaurant.Data.Access.Repository.Services.IServices;
using Restaurant.Models.DTOs;
using Restaurant.Models;
using Restaurant.Utility;
using System.Linq.Expressions;

public class BookingService : IBookingService
{
    private readonly IBookngRepository _bookingRepo;
    private readonly ITableRepository _tableRepo;
    private readonly ICustomerRepository _customerRepo;

    public BookingService(IBookngRepository bookingRepo, ITableRepository tableRepo,ICustomerRepository customerRepo)
    {
        _bookingRepo = bookingRepo;
        _tableRepo = tableRepo;
        _customerRepo = customerRepo;
    }


    public async Task<ServiceResponse<string>> AddItemAsync(BookingCreateDto item)
    {
        var response = new ServiceResponse<string>();

        try
        {
          
            var table = await _tableRepo.GetSingleAsync(item.TablesId);
            if (table == null)
            {
                response.Success = false;
                response.Message = Messages.BookingTableNotFound;
                return response;
            }
        

            var newBooking = new Booking
            {
                Id = item.Id,
                FoodMenuId = item.FoodMenuId,
                CustomerId = item.CustomerId,
                TablesId = item.TablesId,
                BookingDate = item.BookingDate,
                NumberOfGuests = item.NumberOfGuests,
                Tables = table
            };

            if ( newBooking.NumberOfGuests > newBooking.Tables.NumberOfSeats)
            {
                response.Success = false;
                response.Message = Messages.BookingTableLimit;
                return response;
            }

            await _bookingRepo.AddItemAsync(newBooking);
            await _bookingRepo.SaveAsync();

            response.Data = newBooking.Id.ToString();
            response.Success = true;
            response.Message = Messages.BookingSucces;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }

        return response;
    }




    public async Task<ServiceResponse<IEnumerable<BookingDto>>> GetAllAsync(params Expression<Func<Booking, object>>[] includes)
    {
        var response = new ServiceResponse<IEnumerable<BookingDto>>();

        try
        {
            var bookingList = await _bookingRepo.GetAllAsync( b => b.Customer,
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

    public async Task<ServiceResponse<BookingDto>> GetSingleAsync(int id, params Expression<Func<Booking, object>>[]? includes)
    {
        var response = new ServiceResponse<BookingDto>();

        try
        {
            var singlebooking = await _bookingRepo.GetSingleAsync(id, b => b.Customer,
         b => b.Tables,
         b => b.FoodMenu);

            if (singlebooking != null)
            {
                response.Data = new BookingDto
                {
                    Id = singlebooking.Id,
                    BookingDate = singlebooking.BookingDate,
                    TablesId = singlebooking.TablesId,
                    CustomerId = singlebooking.CustomerId,

                    Customer = singlebooking.Customer != null ? new CustomerDto
                    {
                        Id = singlebooking.Customer.Id,
                        FirstName = singlebooking.Customer.FirstName,
                        LasttName = singlebooking.Customer.LasttName,
                    } : null,
                };
                response.Success = true;
                response.Message =Messages.BookingRetrival;
            }
            else
            {
                response.Success = false;
                response.Message = Messages.NoData;
            }
        }
        catch 
        {
          

            response.Success = false;
            response.Message = Messages.BookingFailed;
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
        throw new NotImplementedException();
    }
}
