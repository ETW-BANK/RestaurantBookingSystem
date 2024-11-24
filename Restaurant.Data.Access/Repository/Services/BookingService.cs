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
    private readonly IFoodMenuRepository _fooRepo;

    public BookingService(IBookngRepository bookingRepo, ITableRepository ?tableRepo, ICustomerRepository? customerRepo,IFoodMenuRepository fooRepo)
    {
        _bookingRepo = bookingRepo;
        _tableRepo = tableRepo;
        _customerRepo = customerRepo;
        _fooRepo = fooRepo; 
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

            if (!table.isAvialable)
            {
                response.Success = false;
                response.Message = Messages.BookingTableNotAvailable;
                return response;
            }

            var customer = await _customerRepo.GetSingleAsync(item.CustomerId);
            if (customer == null)
            {
                response.Success = false;
                response.Message = Messages.CustomerFailed;
                return response;
            }

            var foodMenu = await _fooRepo.GetSingleAsync(item.FoodMenuId);
            if (foodMenu == null)
            {
                response.Success = false;
                response.Message = Messages.MenuFailed;
                return response;
            }

            var newBooking = new Booking
            {
                BookingDate = item.BookingDate,
                NumberOfGuests = item.NumberOfGuests,
                CustomerId = item.CustomerId,
                TablesId = item.TablesId,
                FoodMenuId = item.FoodMenuId
            };

            if (newBooking.NumberOfGuests > table.NumberOfSeats)
            {
                response.Success = false;
                response.Message = Messages.BookingTableLimit;
                return response;
            }

            var result = _bookingRepo.AddItemAsync(newBooking);
            table.isAvialable = false;
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
        // Fetch all bookings with specified includes
        var bookingList = await _bookingRepo.GetAllAsync(b => b.Customer, b => b.Tables, b => b.FoodMenu);

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

                // Map Food Menu details
                FoodMenu = u.FoodMenu != null ? new FoodMenuDto
                {
                    Id = u.FoodMenu.Id,
                    Title = u.FoodMenu.Title,
                    ImageUrl = u.FoodMenu.ImageUrl,
                    price = u.FoodMenu.Price,
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



    public async Task<ServiceResponse<BookingDto>> GetSingleAsync(int id, params Expression<Func<Booking, object>>[] includes)
    {
        var response = new ServiceResponse<BookingDto>();

        try
        {
          
            var singleBooking = await _bookingRepo.GetSingleAsync(id, b => b.Customer, b => b.Tables, b => b.FoodMenu);

            if (singleBooking != null)
            {
                response.Data = new BookingDto
                {
                    Id = singleBooking.Id,
                    BookingDate = singleBooking.BookingDate,
                    TablesId = singleBooking.TablesId,
                    CustomerId = singleBooking.CustomerId,
                    NumberOfGuests = singleBooking.NumberOfGuests,

                  
                    Customer = singleBooking.Customer != null ? new CustomerDto
                    {
                        Id = singleBooking.Customer.Id,
                        FirstName = singleBooking.Customer.FirstName,
                        LasttName = singleBooking.Customer.LasttName,
                        Email = singleBooking.Customer.Email,
                        Phone = singleBooking.Customer.Phone
                    } : null,

                 
                    Tables = singleBooking.Tables != null ? new TablesDto
                    {
                        Id = singleBooking.Tables.Id,
                        TableNumber = singleBooking.Tables.TableNumber,
                        NumberOfSeats = singleBooking.Tables.NumberOfSeats,
                        isAvialable = singleBooking.Tables.isAvialable
                    } : null,

                    
                    FoodMenu = singleBooking.FoodMenu != null ? new FoodMenuDto
                    {
                        Id = singleBooking.FoodMenu.Id,
                        Title = singleBooking.FoodMenu.Title,
                        price = singleBooking.FoodMenu.Price,
                        ImageUrl = singleBooking.FoodMenu.ImageUrl,
                        IsAvailable = singleBooking.FoodMenu.IsAvailable
                    } : null
                };

                response.Success = true;
                response.Message = Messages.BookingRetrival;
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
            response.Message = $"{Messages.BookingFailed}: {ex.Message}";
        }

        return response;
    }




    public async Task<ServiceResponse<bool>> RemoveAsync(int id)
    {
        var response = new ServiceResponse<bool>();

        try
        {
            var bookingtodelete=await _bookingRepo.GetSingleAsync(id);
            if (bookingtodelete != null)
            {
                await _bookingRepo.RemoveAsync(id);
                await _bookingRepo.SaveAsync();
                response.Data = true;
                response.Success = true;
                response.Message = Messages.DataDelete;
            }

            else
            {
                response.Success = false;
                response.Message = Messages.NoData;
            }
         
        }
        catch 
        {
            response.Data = false;
            response.Success = false;
            response.Message = Messages.DFailDelete;
        }

        return response;
    }

    public async Task<ServiceResponse<bool>> UpdateBookingAsync(BookingCreateDto bookingDto)
    {
        var response = new ServiceResponse<bool>();

        try
        {
           
            var existingBooking = await _bookingRepo.GetSingleAsync(bookingDto.Id);
            var table = await _tableRepo.GetSingleAsync(bookingDto.TablesId); 
            var customer = await _customerRepo.GetSingleAsync(bookingDto.CustomerId);
            var foodmenu = await _fooRepo.GetSingleAsync(bookingDto.FoodMenuId); 

          
            if (existingBooking == null)
            {
                response.Success = false;
                response.Message = Messages.NoData;
                return response;
            }

         
            if (table == null)
            {
                response.Success = false;
                response.Message = Messages.BookingTableNotFound;
                return response;
            }

       
            if (customer == null)
            {
                response.Success = false;
                response.Message = Messages.BookingUpdateFailed;
                return response;
            }

            if (foodmenu == null)
            {
                response.Success = false;
                response.Message = Messages.BookingUpdateFailed;
                return response;
            }

           
            if (bookingDto.NumberOfGuests > table.NumberOfSeats)
            {
                response.Success = false;
                response.Message = Messages.BookingTableLimit;
                return response;
            }

            
            existingBooking.NumberOfGuests = bookingDto.NumberOfGuests;
            existingBooking.BookingDate = bookingDto.BookingDate;
            existingBooking.Tables = table;
            existingBooking.FoodMenu = foodmenu;
            existingBooking.Customer = customer;

           
            await _bookingRepo.UpdateBookingAsync(existingBooking);
            await _bookingRepo.SaveAsync();

            response.Data = true;
            response.Success = true;
            response.Message = Messages.BookingUpdateSucces;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"An error occurred: {ex.Message}";
        }

        return response;
    }


}
