using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCoupon();   

        Task CreateDiscountCoupon(CreateDiscountCouponDto createCouponDto);

        Task UpdateDiscountCoupon(UpdateDiscountCouponDto updateCouponDto); 

        Task DeleteDiscountCoupon(int id);

        Task<ResultDiscountCouponDto> GetByIdDiscountCoupon(int id);
    }
}
