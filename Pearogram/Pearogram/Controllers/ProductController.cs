using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Pearogram.Controllers
{
    public class ProductController : Controller
    {
        public ProductController(IProductRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public IProductRepository Repository { get; }
        public IMapper Mapper { get; }
        #region Show all products
        public IActionResult Index()
        {
            var produts = Repository.GetAll();
            return View(produts);
        }
        #endregion
        #region Update
        public async Task<IActionResult> Update(int id)
        {
            Product product = await Repository.GetById(id);
            return View(product);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            int x = await Repository.Update(product);
            return RedirectToAction(nameof(Index), Repository.GetAll());
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            Product p = await Repository.GetById(id);
            if (p != null)
            {
                Repository.Delete(p);
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Insert
        public IActionResult Insert()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Insert(Product p)
        {
            if (ModelState.IsValid)
            {
                await Repository.Add(p);
                return RedirectToAction(nameof(Index));
            }
            return View(p);
        }
        #endregion

        #region Validation
        public async Task< IActionResult >IsExists(string productName , int SupplierID)
        {
            Product p =await Repository.GetByName(productName);
            if (p != null && p.SupplierID == SupplierID)
                return Json(false);
            return Json(true);
        }
        #endregion
    }
}
