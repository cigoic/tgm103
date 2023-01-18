using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WuliKaWu.Data;

namespace WuliKaWu.Controllers
{
    public class CartController : Controller
    {
        //public IActionResult AddCart(Data.Product product)
        //{
        //}

<<<<<<< HEAD
        // GET: Cart
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carts.ToListAsync());
        }

        // GET: Cart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carts == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Cart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cart cart)
        {
            //Cart crt = new Cart
            //{
            //    CartId = cart.CartId,
            //    Color = cart.Color,
            //    Coupon = cart.Coupon,
            //    Discount = cart.Discount,
            //    PicturePath = cart.PicturePath,
            //    Price = cart.Price,
            //    ProductName = cart.ProductName,
            //    Quantity = cart.Quantity,
            //    SellingPrice = cart.SellingPrice,
            //    Size = cart.Size
            //};

            //_context.Carts.Add(crt);
            //await _context.SaveChangesAsync();

            return View(cart);

            //if (ModelState.IsValid)
            //{
            //    _context.Add(cart);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(cart);
        }

        // GET: Cart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carts == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            return View(cart);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartId,ProductName,Size,Color,PicturePath,Quantity,Price,SellingPrice,Discount,Coupon,Total")] Cart cart)
        {
            if (id != cart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cart);
        }

        // GET: Cart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carts == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carts == null)
            {
                return Problem("Entity set 'ShopContext.Carts'  is null.");
            }
            var cart = await _context.Carts.FindAsync(id);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
            return _context.Carts.Any(e => e.Id == id);
        }
=======
        //    private readonly ShopContext _context;

        //    public CartController(ShopContext context)
        //    {
        //        _context = context;
        //    }

        //    // GET: Orders
        //    public async Task<IActionResult> Index()
        //    {
        //        return View(await _context.Orders.ToListAsync());
        //    }

        //    //  TODO GET: Cart

        //    public async Task<IActionResult> GetCartDetailsAsync()
        //    {
        //        //var cvm = _context.Carts.Where(
        //        //    vm => vm.Id == id).Select(vm => new CartViewModel

        //        //    {
        //        //        //Id = vm.Id,
        //        //        Conutry = vm.Conutry,
        //        //        State = vm.State,
        //        //        City = vm.City,
        //        //        PostalCode = vm.PostalCode,
        //        //        Picture = vm.Picture,
        //        //        ProductName = vm.ProductName,
        //        //        Price = vm.Price,
        //        //        Quantity = vm.Quantity,
        //        //        CouponDiscount = vm.CouponDiscount,
        //        //    });

        //        return View();
        //    }

        //    //public async Task<IActionResult> GetCartDetailsAsync(int pid, int oid)
        //    //{
        //    //    var cvm = new CartViewModel();
        //    //    var product = await _context.Products.Where(p => p.ProductId == pid).FirstOrDefaultAsync();
        //    //    cvm.ProductName = product.ProductName;
        //    //    var order = await _context.Orders.Where(o => o.OrderId == oid).FirstOrDefaultAsync();
        //    //    cvm.Price = order.UnitPrice;

        //    //    return View(cvm);
        //    //}

        //    // GET: Orders/Details/5
        //    public async Task<IActionResult> Details(int? id)
        //    {
        //        if (id == null || _context.Orders == null)
        //        {
        //            return NotFound();
        //        }

        //        var orders = await _context.Orders
        //            .FirstOrDefaultAsync(m => m.OrderId == id);
        //        if (orders == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(orders);
        //    }

        //    // GET: Orders/Create
        //    public IActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: Orders/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Create([Bind("OrderId,ProductName,Amount,UnitPrice,Discount,ShippingAddress,Memo")] Orders orders)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.Add(orders);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(orders);
        //    }

        //    // GET: Orders/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null || _context.Orders == null)
        //        {
        //            return NotFound();
        //        }

        //        var orders = await _context.Orders.FindAsync(id);
        //        if (orders == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(orders);
        //    }

        //    // POST: Orders/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("OrderId,ProductName,Amount,UnitPrice,Discount,ShippingAddress,Memo")] Orders orders)
        //    {
        //        if (id != orders.OrderId)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(orders);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!OrdersExists(orders.OrderId))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(orders);
        //    }

        //    // GET: Orders/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null || _context.Orders == null)
        //        {
        //            return NotFound();
        //        }

        //        var orders = await _context.Orders
        //            .FirstOrDefaultAsync(m => m.OrderId == id);
        //        if (orders == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(orders);
        //    }

        //    // POST: Orders/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        if (_context.Orders == null)
        //        {
        //            return Problem("Entity set 'ShopContext.Orders'  is null.");
        //        }
        //        var orders = await _context.Orders.FindAsync(id);
        //        if (orders != null)
        //        {
        //            _context.Orders.Remove(orders);
        //        }

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool OrdersExists(int id)
        //    {
        //        return _context.Orders.Any(e => e.OrderId == id);
        //    }
>>>>>>> Merge branch 'development' of https://github.com/cigoic/tgm103 into development
    }
}