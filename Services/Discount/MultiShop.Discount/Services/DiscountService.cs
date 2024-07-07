using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService

    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateDiscountCoupon(CreateDiscountCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values(@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("isActive", createCouponDto.IsActive);
            parameters.Add("validDate", createCouponDto.ValidDate);
            using(var connection=_dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task DeleteDiscountCoupon(int id)
        {
            string query = "Delete from Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);
            using(var conn= _dapperContext.CreateConnection())
            {
               await conn.ExecuteAsync(query,parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCoupon()
        {
            string query = "Select * from Coupons";
            using(var conn = _dapperContext.CreateConnection())
            {
                var values=await conn.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }

        }

        public async Task<ResultDiscountCouponDto> GetByIdDiscountCoupon(int id)
        {
            string query = "Select * from Coupons where CouponId=@couponId";
            var parameters= new DynamicParameters();
            parameters.Add("@couponId",id);
            using(var conn = _dapperContext.CreateConnection())
            {
                var value = await conn.QueryFirstOrDefaultAsync<ResultDiscountCouponDto>(query);
                return value;
            }
        }

        public async Task UpdateDiscountCoupon(UpdateDiscountCouponDto updateCouponDto) 
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            using(var connection= _dapperContext.CreateConnection()) 
            {
                var value=await connection.ExecuteAsync(query,parameters);
            }
        }
    }
}
