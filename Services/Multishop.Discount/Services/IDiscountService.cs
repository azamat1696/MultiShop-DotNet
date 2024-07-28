using Multishop.Discount.Dtos;

namespace Multishop.Discount.Services;

public interface IDiscountService
{
    Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync();
    Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto);
    Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto);
    Task DeleteDiscountCouponAsync(int id);
    Task<GetByIdDiscountCouponDto?> GetByIdDiscountCouponAsync(int id);
}