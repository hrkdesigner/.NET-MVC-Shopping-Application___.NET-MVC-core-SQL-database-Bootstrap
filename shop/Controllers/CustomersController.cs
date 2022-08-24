using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.Models.DataAccess;

namespace shop.Controllers
{
    public class CustomersController : Controller
    {
        private readonly dbfinalContext _context;
        const string authKey = "_Auth";
        public CustomersController(dbfinalContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("auth") != null) 
            {
                return _context.Customers != null ?
                          View(await _context.Products.ToListAsync()) :
                          Problem("Entity set 'dbfinalContext.Customers'  is null.");
            }
            else
            {
                return View("/Views/Customers/Login.cshtml");

            }
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("auth") != null)
            {
                return RedirectToAction(nameof(Index));
            }
            else {
            return View();
            }
        }
        public IActionResult Logout()
        {
            string view;
            if (HttpContext.Session.GetInt32("auth")!=null) 
            {
                 view = "/Views/Customers/Login.cshtml";
            }
            else
            {
                 view = "/Views/Products/adminLogin.cshtml";

            }
            HttpContext.Session.Remove("auth");
            HttpContext.Session.Remove("authAdmin");
            return View(view);

        }
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("auth") != null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var name = HttpContext.Session.GetInt32("auth");
                ViewBag.suc = name;
                return View();

            }
            
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,Password")] Customer customer)
        {
            if (HttpContext.Session.GetInt32("auth") != null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var pass1 = Request.Form["Password"];
                var pass2 = Request.Form["PasswordConfirm"];
                customer.Id = _context.Customers.Count();

                if (ModelState.IsValid && pass1 == pass2)
                {
                    _context.Add(customer);
                    await _context.SaveChangesAsync();
                    HttpContext.Session.SetInt32("auth", customer.Id);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    ModelState.AddModelError("", "Password Doesn't Match");
                    return View(customer);


                }

            }
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        public async Task<IActionResult> Subs(int? id)
        {
            var auth = HttpContext.Session.GetInt32("auth");
            


            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            var customer = await _context.Customers.FindAsync(auth);
            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                var newSub = new CustomerHasProduct();
                newSub.ProductId = product.Id;
                newSub.CustomerId = customer.Id;
                _context.Add(newSub);
                await _context.SaveChangesAsync();
                TempData["ResultMessage"] = "Subscribed Successfully!";
                return RedirectToAction(nameof(Index));

            }
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            return View(customer);
        }
         [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] Customer customer)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    Customer c = _context.Customers.First(c => c.Email == customer.Email);
                    if (c.Password == customer.Password)
                    {
                        HttpContext.Session.SetInt32("auth", c.Id);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Wrong username or password!");
                    }
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Wrong username or password!");
                }
                   
            }
            return View(customer);


        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        public async Task<IActionResult> Cancel(int id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'dbfinalContext.Customers'  is null.");
            }
            var customer = await _context.CustomerHasProducts.FindAsync(id);
            if (customer != null)
            {
                _context.CustomerHasProducts.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'dbfinalContext.Customers'  is null.");
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
          return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
