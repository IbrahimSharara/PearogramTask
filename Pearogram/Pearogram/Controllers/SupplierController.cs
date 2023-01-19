using Microsoft.AspNetCore.Mvc;

namespace Pearogram.Controllers
{
    public class SupplierController : Controller
    {
        public SupplierController(ISupplierRepository repository)
        {
            Repository = repository;
        }

        public ISupplierRepository Repository { get; }
        #region Show all Suppliers
        public IActionResult Index()
        {
            var supplier =  Repository.GetAll();
            return View(supplier);
        }
        #endregion
        #region Update
        public async Task<IActionResult> Update(int id)
        {
            Supplier supplier = await Repository.GetById(id); 
            return View(supplier);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Update(Supplier supplier)
        {
        if (ModelState.IsValid)
        {
            int x = await Repository.Update(supplier);
            return RedirectToAction(nameof(Index), Repository.GetAll());
            }
            return View(supplier);
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            Supplier s = await Repository.GetById(id);
            if (s != null)
            {
                Repository.Delete(s);
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
        public async Task<IActionResult> Insert(Supplier s)
        {
            if (ModelState.IsValid)
            {
                await Repository.Add(s); 
                return RedirectToAction(nameof(Index));
            }
            return View(s);
        }
        #endregion
        #region Remote Check unique Supplier Name
        public async Task<IActionResult> UniqueSupplier(string SupplierName)
        {
            Supplier s = await Repository.GetByName(SupplierName);
            if (s == null)
                return Json( true);
            return Json(false);
        }
        #endregion

    }
}
