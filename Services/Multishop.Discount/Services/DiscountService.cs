using Dapper;
using Multishop.Discount.Context;
using Multishop.Discount.Dtos;

namespace Multishop.Discount.Services;

public class DiscountService : IDiscountService
{
    private readonly DapperContext _context;
    public DiscountService(DapperContext context)
    {
        _context = context;
    }
    public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync()
    {
        string sql = "SELECT * FROM Coupons";
        using (var connection = _context.CreateConnection())
        {
           var values = await connection.QueryAsync<ResultDiscountCouponDto>(sql);
           return values.ToList();
        }
        
    }

    public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto)
    {
        string sql = "INSERT INTO Coupons (Code,Rate,isActive,ValidDate) VALUES ( @Code, @Rate, @isActive, @ValidDate )";
        var parameters = new DynamicParameters();
        parameters.Add("@Code", createDiscountCouponDto.Code);
        parameters.Add("@Rate", createDiscountCouponDto.Rate);
        parameters.Add("@isActive", createDiscountCouponDto.IsActive);
        parameters.Add("@ValidDate", createDiscountCouponDto.ValidDate);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
        }
        
    }

    public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto)
    {
        string sql = "UPDATE Coupons SET Code = @Code, Rate = @Rate, isActive = @isActive, ValidDate = @ValidDate WHERE CouponId = @CouponId";
        var parameters = new DynamicParameters();
        parameters.Add("@Code", updateDiscountCouponDto.Code);
        parameters.Add("@Rate", updateDiscountCouponDto.Rate);
        parameters.Add("@isActive", updateDiscountCouponDto.IsActive);
        parameters.Add("@ValidDate", updateDiscountCouponDto.ValidDate);
        parameters.Add("@CouponId", updateDiscountCouponDto.CouponId);
        using (var connection = _context.CreateConnection())
        {
             await connection.ExecuteAsync(sql, parameters);
        }
    }

    public async Task DeleteDiscountCouponAsync(int id)
    {
        string sql = "DELETE FROM Coupons WHERE CouponId = @CouponId";
        var parameters = new DynamicParameters();
        parameters.Add("@CouponId", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
        }
    }

    public async Task<GetByIdDiscountCouponDto?> GetByIdDiscountCouponAsync(int id)
    {
        string sql = "SELECT * FROM Coupons WHERE CouponId = @CouponId";
        var parameters = new DynamicParameters();
        parameters.Add("@CouponId", id);
        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(sql, parameters);
        }
    }
}