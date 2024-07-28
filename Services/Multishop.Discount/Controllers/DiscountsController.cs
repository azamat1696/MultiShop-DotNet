using Microsoft.AspNetCore.Mvc;
using Multishop.Discount.Dtos;
using Multishop.Discount.Services;

namespace Multishop.Discount.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscountsController : ControllerBase
{
    private readonly IDiscountService _discountService;
    
    public DiscountsController(IDiscountService discountService)
    {
        _discountService = discountService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllDiscountCoupons()
    {
        var coupons = await _discountService.GetAllDiscountCouponsAsync();
        return Ok(coupons);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createDiscountCouponDto)
    {
        await _discountService.CreateDiscountCouponAsync(createDiscountCouponDto);
        return Ok("Coupon created");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdDiscountCoupon(int id)
    {
        var coupon = await _discountService.GetByIdDiscountCouponAsync(id);
        if (coupon == null)
        {
            return NotFound("Coupon not found");
        }
        return Ok(coupon);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateDiscountCouponDto)
    {
        await _discountService.UpdateDiscountCouponAsync(updateDiscountCouponDto);
        return Ok("Coupon updated");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDiscountCoupon(int id)
    {
        await _discountService.DeleteDiscountCouponAsync(id);
        return Ok("Coupon deleted");
    }
}