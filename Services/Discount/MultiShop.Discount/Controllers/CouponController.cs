using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public CouponController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList() 
        {
            var values = await _discountService.GetAllDiscountCoupon();
            return Ok(values);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetbyIdDiscountCoupon(int id) 
        {
            var value = await _discountService.GetByIdDiscountCoupon(id);
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateCouponDto) 
        {
            await _discountService.UpdateDiscountCoupon(updateCouponDto);
            return Ok("Kupon Basarı ile Güncellendi");
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createCouponDto) 
        {
            await _discountService.CreateDiscountCoupon(createCouponDto);
            return Ok("Kupon Basarı ile Olusturuldu");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id) 
        {
            await _discountService.DeleteDiscountCoupon(id);
            return Ok("Kupon Basarı ile Silindi");
        }
    }
}
