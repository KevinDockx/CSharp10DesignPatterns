using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    /// <summary>
    /// Abstraction
    /// </summary>
    public abstract class Menu
    {
        public readonly ICoupon _coupon;
        public abstract int CalculatePrice();

        public Menu(ICoupon coupon)
        {
            _coupon = coupon;
        }
    }


    /// <summary>
    /// RefinedAbstraction
    /// </summary>
    public class VegetarianMenu : Menu
    { 
        public VegetarianMenu(ICoupon coupon): base(coupon)
        { 
        }
        public override int CalculatePrice()
        {
            return 20 - _coupon.CouponValue;
        }
    }

    /// <summary>
    /// RefinedAbstraction
    /// </summary>
    public class MeatBasedMenu : Menu
    {
        public MeatBasedMenu(ICoupon coupon) : base(coupon)
        {
        }
        public override int CalculatePrice()
        {
            return 30 - _coupon.CouponValue;
        }
    }


    /// <summary>
    /// Implementor
    /// </summary>
    public interface ICoupon
    {
        int CouponValue { get; }
    }


    /// <summary>
    /// ConcreteImplementor
    /// </summary>
    public class NoCoupon : ICoupon
    {
        public int CouponValue { get => 0; }
    }

    /// <summary>
    /// ConcreteImplementor
    /// </summary>
    public class OneEuroCoupon : ICoupon
    {
        public int CouponValue { get => 1; }
    }

    /// <summary>
    /// ConcreteImplementor
    /// </summary>
    public class TwoEuroCoupon : ICoupon
    {
        public int CouponValue { get => 2; }
    }
}