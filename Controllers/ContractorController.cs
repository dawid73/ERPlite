using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using erplite.Models;
using Microsoft.EntityFrameworkCore;

namespace erplite.Controllers
{
    public class ContractorController : Controller
    {
        
        private readonly AplicationDbContext _db;

        public ContractorController(AplicationDbContext db)
        {
            _db = db;
        }

        // [GET] ../ 
        public IActionResult Index()
        {
            var displaydata = _db.Contractors.ToList();
            return View(displaydata);
        }

        // [GET] ../create
        public IActionResult Create()
        {
            return View();
        }

        // [POST] ../create
        // tworzenie nowego contraktor-a
        // funckja przyjmuje obiekt klasy NewContractorClass
        [HttpPost]
        public async Task<IActionResult> Create(NewContractorClass ncc)
        {
            //weryfikacja poprawności obiektu ncc
            if (ModelState.IsValid)
            {
                _db.Add(ncc);
                await _db.SaveChangesAsync();
                //przekierowanie na index jeżeli jest wszystko ok
                // TODO: dodanie infomracji o poprawnym dodaniu nowego contractora
                return RedirectToAction("Index");
            }
            // jeżeli model nie jest poprawny przekierowanie z powrotem na create i przekazanie obieku ncc
            return View(ncc);
        }

        // [GET] ../edit/{id}
        // wyświetlenie edycji contractora
        // jako parametr pobiera id z URL
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            //pobranie daych na podstawie id i przekazanie wyniku do widoku
            var getcontractordetails = await _db.Contractors.FindAsync(id);
            return View(getcontractordetails);
        }

        // [POST] ../edit/
        // edycja danych w DB 
        // funkcja przyjmuje obiekt klasy NewContractorClass
        [HttpPost]
        public async Task<IActionResult> Edit(NewContractorClass ncc)
        {
            if (ModelState.IsValid)
            {
                _db.Update(ncc);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ncc);
        }

        // [GET] ../details/
        // wyswietlenie szczegółów contractora
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var getcontractordetails = await _db.Contractors.FindAsync(id);
            return View(getcontractordetails);
        }


        // [GET] ../delete/{id}
        // wyświetlenie potwierdzenie usunięcia (funckja jeszcze NIE usuwa z DB)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var getcontractordetails = await _db.Contractors.FindAsync(id);
            return View(getcontractordetails);
        }

        // [POST] ../delete/{id}
        // usunięcie z DB na podstawie przekazanego ID w parametrze URL 
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var getcontractordetails = await _db.Contractors.FindAsync(id);
            _db.Contractors.Remove(getcontractordetails);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
            
        }

    }
}